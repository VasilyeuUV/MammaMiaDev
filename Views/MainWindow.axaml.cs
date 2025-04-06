using FluentAvalonia.UI.Windowing;
using MammaMiaDev.Models;

namespace MammaMiaDev.Views
{
    public partial class MainWindow : AppWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            TitleBar.ExtendsContentIntoTitleBar = true;
            TitleBar.TitleBarHitTestType = TitleBarHitTestType.Complex;

            SplashScreen = new ComplexSplashScreen();
        }
    }
}