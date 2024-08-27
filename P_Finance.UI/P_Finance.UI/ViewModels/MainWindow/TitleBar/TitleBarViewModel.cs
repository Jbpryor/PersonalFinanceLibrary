namespace P_Finance.UI.ViewModels;

public class TitleBarViewModel : ViewModelBase
{
    public TitleBarNavViewModel TitleBarNavViewModel { get; }

    public TitleBarViewModel(TitleBarNavViewModel titleBarNavViewModel)
    {
        TitleBarNavViewModel = titleBarNavViewModel;
    }
}