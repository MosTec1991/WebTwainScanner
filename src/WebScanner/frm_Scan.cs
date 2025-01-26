using System.ComponentModel;
using Ardalis.Result;
using NAPS2.Images;
using NAPS2.Images.Gdi;
using NAPS2.Scan;

namespace WebScanner;

public partial class FrmScan : Form
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Result<List<byte[]>> ScanImages { get; set; } = Result.NoContent();
    
    private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
    private void CancelPreviousRequest()
    {
        _cancellationTokenSource.Cancel();
        _cancellationTokenSource = new CancellationTokenSource();
    }

    private ScanController? _scanController;

    // ReSharper disable once NotAccessedPositionalProperty.Global
    public record ScanFeedOption(PaperSource PaperSource, string Name);

    // ReSharper disable once NotAccessedPositionalProperty.Global
    public record ScanColorOption(BitDepth BitDepth, string Name);
    
    private PictureBox? SelectedPictureBox
    {
        get => _selectedPictureBox;
        set
        {
            if (value != null)
            {
                _selectedPictureBox = value;
                EnableControlButton();
            }
            else
            {
                _selectedPictureBox = null;
                DisableControlButton();
            }
        }
    }
    private PictureBox? _selectedPictureBox;

    public FrmScan()
    {
        InitializeComponent();
        _ = InitializeScannerWorkerAsync();
    }

    private async Task InitializeScannerWorkerAsync()
    {
        try
        {
#pragma warning disable CA1416
            using var scanningContext = new ScanningContext(new GdiImageContext());
#pragma warning restore CA1416
            scanningContext.SetUpWin32Worker();
            _scanController = new ScanController(scanningContext);
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

        await GetScannerDevicesAsync();
    }

    private async Task GetScannerDevicesAsync()
    {
        ClearDeviceCaps();
        btnDeviceRefresh.Enabled = false;
        try
        {
            List<ScanDevice> devicesList = [];
            if (_scanController != null)
            {
                devicesList = await _scanController.GetDeviceList(Driver.Twain);
                cboDevice.DataSource = devicesList;
                cboDevice.DisplayMember = "Name";
            }

            if (Properties.Settings.Default.KeepLastUsedOption &&
                !string.IsNullOrEmpty(Properties.Settings.Default.LastDeviceName))
            {
                var lastDevice = devicesList.FirstOrDefault(x => x.Name == Properties.Settings.Default.LastDeviceName);
                cboDevice.SelectedIndex = lastDevice != null ? devicesList.IndexOf(lastDevice) : 0;
            }
            else
            {
                cboDevice.SelectedIndex = 0;
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

        btnDeviceRefresh.Enabled = true;
    }

    private void ClearDeviceCaps()
    {
        btnScan.Enabled = false;
        cboColor.DataSource = null;
        cboDpi.DataSource = null;
        cboFeeder.DataSource = null;
    }

    private void btnDeviceRefresh_Click(object sender, EventArgs e)
    {
        _ = GetScannerDevicesAsync();
    }

    private async Task GetDeviceCapsAsync(CancellationToken ct)
    {
       
        btnScan.Enabled = false;
        try
        {
            if (cboDevice.SelectedItem is not ScanDevice device)
            {
                return;
            }

            if (_scanController is null)
            {
                return;
            }

            
            var deviceCape = await _scanController.GetCaps(device,ct);

            //TODO: Check why CancellationToken not work in GetCaps()
            //First time get Initialized if last used scanner is not first in list.
            //cboDevice_SelectedIndexChanged event fired twice in row.
            //some how CancellationToken not work in GetCaps() so need to check here if request has been cancelle

            if (ct.IsCancellationRequested)
            {
                return;
            }

            this.Text = device.Name;
            
            List<int> commonDpi = [];
            List<ScanFeedOption> feedOptions = [new(PaperSource.Auto, "Auto")];
            List<ScanColorOption> colorOptions = [];

            if (deviceCape.FeederCaps?.DpiCaps?.CommonValues != null)
            {
                commonDpi = deviceCape.FeederCaps.DpiCaps.CommonValues.ToList();
                cboDpi.DataSource = commonDpi;
            }


            if (deviceCape.PaperSourceCaps is { SupportsDuplex: true })
            {
                feedOptions.Add(new ScanFeedOption(PaperSource.Duplex, "Duplex"));
            }

            if (deviceCape.PaperSourceCaps is { SupportsFeeder: true })
            {
                feedOptions.Add(new ScanFeedOption(PaperSource.Feeder, "Feeder"));
            }

            if (deviceCape.PaperSourceCaps is { SupportsFlatbed: true })
            {
                feedOptions.Add(new ScanFeedOption(PaperSource.Flatbed, "Flatbed"));
            }

            cboFeeder.DataSource = feedOptions;
            cboFeeder.DisplayMember = "Name";
            cboFeeder.SelectedIndex = 0;

            if (deviceCape.FeederCaps?.BitDepthCaps is { SupportsColor: true })
            {
                colorOptions.Add(new ScanColorOption(BitDepth.Color, "Color"));
            }

            if (deviceCape.FeederCaps?.BitDepthCaps is { SupportsGrayscale: true })
            {
                colorOptions.Add(new ScanColorOption(BitDepth.Grayscale, "Grayscale"));
            }

            if (deviceCape.FeederCaps?.BitDepthCaps is { SupportsBlackAndWhite: true })
            {
                colorOptions.Add(new ScanColorOption(BitDepth.BlackAndWhite, "Black & White"));
            }

            cboColor.DataSource = colorOptions;
            cboColor.DisplayMember = "Name";
            cboColor.SelectedIndex = 0;

            if (Properties.Settings.Default.KeepLastUsedOption && (cboDevice.SelectedItem as ScanDevice)?.Name == Properties.Settings.Default.LastDeviceName)
            {
                var dpiIndex = commonDpi.IndexOf(Properties.Settings.Default.LastDPI);
                if (dpiIndex != -1)
                {
                    cboDpi.SelectedIndex = dpiIndex;
                }

                var lastUsedFeeder = feedOptions.SingleOrDefault(q =>
                    q.PaperSource == (PaperSource)Properties.Settings.Default.LastFeeder);

                if (lastUsedFeeder != null)
                {
                    var feederIndex = feedOptions.IndexOf(lastUsedFeeder);
                    if (feederIndex != -1)
                    {
                        cboFeeder.SelectedIndex = feederIndex;
                    }
                }

                var lastUsedColor =
                    colorOptions.SingleOrDefault(q => q.BitDepth == (BitDepth)Properties.Settings.Default.LastColor);
                if (lastUsedColor != null)
                {
                    var colorIndex = colorOptions.IndexOf(lastUsedColor);
                    if (colorIndex != -1)
                    {
                        cboColor.SelectedIndex = colorIndex;
                    }
                }
            }

            btnScan.Enabled = true;
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }

    private void btnScan_Click(object sender, EventArgs e)
    { 
        SaveLastUsedOption();
        _ = ScanDocumentAsync();
    }
    
    private void  SaveLastUsedOption()
    {
        Properties.Settings.Default.LastDeviceName = (cboDevice.SelectedItem as ScanDevice)!.Name;
        Properties.Settings.Default.LastFeeder = (int)(cboFeeder.SelectedItem as ScanFeedOption)!.PaperSource;
        Properties.Settings.Default.LastColor = (int)(cboColor.SelectedItem as ScanColorOption)!.BitDepth;
        Properties.Settings.Default.LastDPI = (int)cboDpi.SelectedItem!;
        Properties.Settings.Default.Save();
    }

    private async Task ScanDocumentAsync()
    {
        List<MemoryStream> imageStream = [];
        btnScan.Enabled = false;
        
        try
        {
            var scanOption = new ScanOptions()
            {
                AutoDeskew = true,
                BitDepth = ((ScanColorOption)cboColor.SelectedItem!).BitDepth,
                PaperSource = ((ScanFeedOption)cboFeeder.SelectedItem!).PaperSource,
                Dpi = (int)cboDpi.SelectedItem!,
                Device = (ScanDevice)cboDevice.SelectedItem!
            };
            await foreach (var image in _scanController!.Scan(scanOption))
            {
                imageStream.Add(image.SaveToMemoryStream(ImageFileFormat.Bmp));
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
        DisplayThumbnails(imageStream);
    }

    private void DisplayThumbnails(List<MemoryStream> imageStream)
    {
        if (imageStream.Count == 0)
        {
            return;
        }

        foreach (var image in imageStream)
        {
            var bitmap = new Bitmap(image);
            PictureBox thumbnail = new PictureBox
            {
                Image = bitmap.GetThumbnailImage(93, 134, null, IntPtr.Zero),
                SizeMode = PictureBoxSizeMode.Zoom,
                Width = 93,
                Height = 134,
                Tag = bitmap
            };

            thumbnail.Click += Thumbnail_Click!;
            pnlScanedPages.Controls.Add(thumbnail);
            Thumbnail_Click(thumbnail, EventArgs.Empty);
        }
        btnScan.Enabled = true;
        btnSend.Enabled = true;
    }
    
    private void Thumbnail_Click(object sender, EventArgs e)
    {
        if (sender is not PictureBox thumbnail) return;
        SelectedPictureBox = thumbnail;
        var fullSizeImage = thumbnail.Tag as Bitmap;
        pbViewScannedPage.Image = fullSizeImage;
    }
    
    private void DisableControlButton()
    {
        btnDeletePage.Enabled = false;
        btnRotateLeft.Enabled = false;
        btnRotateRight.Enabled = false;
    }

    private void EnableControlButton()
    {
        btnDeletePage.Enabled = true;
        btnRotateLeft.Enabled = true;
        btnRotateRight.Enabled = true;
    }
    private void btnSend_Click(object sender, EventArgs e)
    {
        var scanImages = new List<byte[]>();
        foreach (var image in pnlScanedPages.Controls)
        {
            var bitmap = (image as PictureBox)?.Tag as Bitmap;
            using var stream = new MemoryStream();
            bitmap?.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            stream.Position = 0;
            scanImages.Add(stream.ToArray());
        }
        ScanImages = Result.Success(scanImages);
        this.DialogResult = DialogResult.OK;
    }

    private void btnBack_Click(object sender, EventArgs e)
    {

        
        ScanImages = Result.NoContent();
        this.DialogResult = DialogResult.OK;
    }

    private void btnDeletePage_Click(object sender, EventArgs e)
    {
        if (SelectedPictureBox is not null)
        {
            pnlScanedPages.Controls.Remove(SelectedPictureBox);
            SelectedPictureBox = null;
            pbViewScannedPage.Image = null;
            DisableControlButton();
        }

        if (pnlScanedPages.Controls.Count == 0)
        {
            btnSend.Enabled = false;
        }
    }

    private void btnRotateLeft_Click(object sender, EventArgs e)
    {
        if (SelectedPictureBox is null) return;
        (SelectedPictureBox.Tag as Bitmap)?.RotateFlip(RotateFlipType.Rotate270FlipNone);
        var fullSizeImage = SelectedPictureBox.Tag as Bitmap;
        pbViewScannedPage.Image = fullSizeImage;
        SelectedPictureBox.Image = fullSizeImage?.GetThumbnailImage(93, 134, null, IntPtr.Zero);
    }

    private void btnRotateRight_Click(object sender, EventArgs e)
    {
        if (SelectedPictureBox is null) return;
        (SelectedPictureBox.Tag as Bitmap)?.RotateFlip(RotateFlipType.Rotate90FlipNone);
        var fullSizeImage = SelectedPictureBox.Tag as Bitmap;
        pbViewScannedPage.Image = fullSizeImage;
        SelectedPictureBox.Image = fullSizeImage?.GetThumbnailImage(93, 134, null, IntPtr.Zero);
    }

    private void cboDevice_SelectedIndexChanged(object sender, EventArgs e)
    {
        CancelPreviousRequest();
        ClearDeviceCaps();
        _ = GetDeviceCapsAsync(_cancellationTokenSource.Token);
    }
}