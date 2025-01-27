using System.Net.WebSockets;
using System.Text;
using Ardalis.Result;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace WebScanner;

internal static class WebSocketServer
{
    internal static WebApplication RunServer()
    {
        var builder = WebApplication.CreateBuilder();

        var app = builder.Build();

        app.UseWebSockets();

        app.Map("/scan", async (HttpContext context) =>
        {
            var webSocket = await context.WebSockets.AcceptWebSocketAsync();

            Result<string>? result = null;
            await Program.StartForm.InvokeAsync(new Action(() => { result = FrmSplashScreen.ShowScanForm(); }));

            if (result is { IsSuccess: true })
            {
                await webSocket.SendAsync(
                    Encoding.ASCII.GetBytes(result.Value),
                    WebSocketMessageType.Text,
                    endOfMessage: true,
                    CancellationToken.None
                );
            }
            else
            {
                await webSocket.SendAsync(
                    Encoding.ASCII.GetBytes("Error"),
                    WebSocketMessageType.Text,
                    endOfMessage: true,
                    CancellationToken.None
                );
            }
        });

        return app;
    }
}