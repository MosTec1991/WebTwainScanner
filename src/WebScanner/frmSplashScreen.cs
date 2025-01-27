using System.ComponentModel;
using System.Text.Json;
using Ardalis.Result;
using Microsoft.Win32;

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

    private void FrmSplashScreen_Load(object sender, EventArgs e)
    {
        runAtStartupToolStripMenuItem.Checked = Properties.Settings.Default.RunAppStartUp;
        useLastUsedOptionToolStripMenuItem.Checked = Properties.Settings.Default.KeepLastUsedOption;
        _ = HideSplashScreenAsync();
        RegisterInStartup(Properties.Settings.Default.RunAppStartUp);
    }
    
    private async Task HideSplashScreenAsync()
    {
        await Task.Delay(TimeSpan.FromSeconds(2));
        this.Hide();
    }

    private void runAtStartupToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Properties.Settings.Default.RunAppStartUp = !Properties.Settings.Default.RunAppStartUp;
        Properties.Settings.Default.Save();
        runAtStartupToolStripMenuItem.Checked = Properties.Settings.Default.RunAppStartUp;
        RegisterInStartup(Properties.Settings.Default.RunAppStartUp);
    }

    private void useLastUsedOptionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Properties.Settings.Default.KeepLastUsedOption = !Properties.Settings.Default.KeepLastUsedOption;
        Properties.Settings.Default.Save();
        runAtStartupToolStripMenuItem.Checked = Properties.Settings.Default.KeepLastUsedOption;
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
    
    private void RegisterInStartup(bool isChecked)
    {
        var runKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        using RegistryKey? key = Registry.CurrentUser.OpenSubKey(runKey, true);
        if (key is null)
        {
            MessageBox.Show("Unable to open registry to setup startup.", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        if (isChecked)
        {
            key.SetValue("TwainScanApp", Application.ExecutablePath);
        }
        else
        {
            key.DeleteValue("TwainScanApp", false);
        }
    }
}
