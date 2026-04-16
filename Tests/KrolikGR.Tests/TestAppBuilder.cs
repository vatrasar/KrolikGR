using Avalonia;
using Avalonia.Headless;
using KrolikGR;

[assembly: AvaloniaTestApplication(typeof(KrolikGR.Tests.TestAppBuilder))]

namespace KrolikGR.Tests;

public static class TestAppBuilder
{
    public static AppBuilder BuildAvaloniaApp() =>
        AppBuilder.Configure<App>()
            .UseHeadless(new AvaloniaHeadlessPlatformOptions
            {
                UseHeadlessDrawing = true
            });
}