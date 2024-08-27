using System.Windows;
using System.Windows.Input;

namespace P_Finance.UI.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var window = this;

        if (e.ClickCount == 2)
        {
            if (this != null)
            {
                this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            }
        }
        else
        {
            this?.DragMove();
        }
    }

    private void Window_StateChanged(object sender, EventArgs e)
    {
        if (this.WindowState == WindowState.Maximized)
        {
            this.MaxHeight = SystemParameters.WorkArea.Height + 10;
            this.MaxWidth = SystemParameters.WorkArea.Width + 10;
        }
        else
        {
            this.MaxHeight = double.PositiveInfinity;
            this.MaxWidth = double.PositiveInfinity;
        }
    }
}
