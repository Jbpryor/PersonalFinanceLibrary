using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media;
using P_Finance.UI.Commands;


namespace P_Finance.UI.Views;

/// <summary>
/// Interaction logic for TitleBarView.xaml
/// </summary>
public partial class TitleBarView : UserControl
{

    public ICommand MinimizeWindowCommand { get; }
    public ICommand MaximizeRestoreWindowCommand { get; }
    public ICommand CloseWindowCommand { get; }

    public TitleBarView()
    {
        InitializeComponent();

        MinimizeWindowCommand = new RelayCommand(p => MinimizeWindow());
        MaximizeRestoreWindowCommand = new RelayCommand(p => MaximizeRestoreWindow());
        CloseWindowCommand = new RelayCommand(p => CloseWindow());

        StartRotationAnimation();
    }

    private void StartRotationAnimation()
    {
        DoubleAnimation rotateAnimation = new DoubleAnimation
        {
            From = 0,
            To = 360,
            Duration = new Duration(TimeSpan.FromSeconds(5)),
            RepeatBehavior = RepeatBehavior.Forever
        };

        RotateTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);
    }

    private void MinimizeWindow()
    {
        Application.Current.MainWindow.WindowState = WindowState.Minimized;
    }

    private void MaximizeRestoreWindow()
    {
        Application.Current.MainWindow.WindowState = Application.Current.MainWindow.WindowState == WindowState.Maximized
            ? WindowState.Normal
            : WindowState.Maximized;
    }

    private void CloseWindow()
    {
        Application.Current.Shutdown();
    }
}
