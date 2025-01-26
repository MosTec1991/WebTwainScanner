using System.Text.Json;
using Ardalis.Result;

namespace WebScanner;

public partial class FrmSplashScreen : Form
{
    public FrmSplashScreen()
    {
        InitializeComponent();
    }
    
    public static Result<string> ShowScanForm()
    {
        using var scanForm = new FrmScan();
        var result = scanForm.ShowDialog();
        if (result != DialogResult.OK)
        {
            return Result.Error();
        }
        var imagesResult = scanForm.ScanImages;

        if (!imagesResult.IsSuccess)
        {
            return Result.Error();
        }

        var imagesBase64 = imagesResult.Value.Select(image => Convert.ToBase64String(image)).ToList();

        return Result.Success(JsonSerializer.Serialize(imagesBase64));
    }
}