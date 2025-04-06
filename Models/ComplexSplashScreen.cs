using System.Threading;
using System.Threading.Tasks;
using Avalonia.Media;
using FluentAvalonia.UI.Windowing;
using MammaMiaDev.Views;

namespace MammaMiaDev.Models;

public class ComplexSplashScreen : IApplicationSplashScreen
{
    public ComplexSplashScreen()
    {
        SplashScreenContent = new SplashScreenView();
    }

    public string AppName => "";

    public IImage? AppIcon => null;

    public object SplashScreenContent { get; }

    public int MinimumShowTime => 0;

    public async Task RunTasks(CancellationToken token)
    {
        await ((SplashScreenView)SplashScreenContent).InitApp();
    }
}
