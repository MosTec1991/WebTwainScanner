namespace WebScanner;

static class Program
{
    
    public static FrmSplashScreen StartForm { get; private set; } = null!;
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        WebSocketServer.RunServer().RunAsync();
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        StartForm = new FrmSplashScreen();
        Application.Run(StartForm);
    }
}