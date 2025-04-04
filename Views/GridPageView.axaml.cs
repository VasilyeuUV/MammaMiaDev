using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace MammaMiaDev.Views;

public partial class GridPageView : UserControl
{
    private const int Rows = 10;
    private const int Cols = 10;

    private readonly IBrush _baseColor = Brushes.LightGray;
    private bool _stop = true;

    public GridPageView()
    {
        InitializeComponent();
        InitGrid();
    }

    private void InitGrid()
    {
        MainGrid.Height = 500;
        MainGrid.Width = 500;
        MainGrid.ShowGridLines = true;

        for (int i = 0; i < Rows; i++)
        {
            MainGrid.RowDefinitions.Add(new RowDefinition(GridLength.Star));
            MainGrid.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));

            for (int j = 0; j < Cols; j++)
            {
                var child = new Rectangle
                {
                    Width = 40,
                    Height = 40,
                    Margin = new Thickness(1),
                    Fill = _baseColor,
                };
                MainGrid.Children.Add(child);
                Grid.SetRow(child, i);
                Grid.SetColumn(child, j);
            }
        }
    }

    private async void ClickButtonStart(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _stop = false;
        Rectangle? previous = null;

        foreach (var child in MainGrid.Children)
        {
            if (_stop)
            {
                break;
            }

            if (child is not Rectangle rect)
            {
                continue;
            }

            if (previous is not null)
            {
                previous.Fill = _baseColor;
            }

            rect.Fill = Brushes.MediumSeaGreen;
            previous = rect;
            await Task.Delay(100);
        }

        if (previous is not null)
        {
            previous.Fill = _baseColor;
        }

        if (!_stop)
        {
            ClickButtonStart(sender, e);
        }
    }

    private void ClickButtonStop(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _stop = true;
        foreach (var child in MainGrid.Children)
        {
            if (child is not Rectangle rect)
            {
                continue;
            }
            rect.Fill = _baseColor;
        }
    }
}