using P_Finance.UI.Commands;
using P_Finance.UI.Services;
using P_Finance.UI.Stores;
using System.Windows.Input;

namespace P_Finance.UI.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly NavStore _navStore;
    private readonly ModalNavStore _modalNavStore;


    public TitleBarViewModel TitleBarViewModel { get; }
    public TitleBarNavViewModel? TitleBarNavViewModel { get; }
    public ViewModelBase? CurrentViewModel => _navStore.CurrentViewModel;
    public ViewModelBase? CurrentModalViewModel => _modalNavStore.CurrentViewModel;
    public bool IsModalOpen => _modalNavStore.IsOpen;


    public ICommand NavigateDashboardCommand { get; }
    public ICommand NavigateDepositsCommand { get; }
    public ICommand NavigateCreditCardsCommand { get; }



    public MainWindowViewModel(INavigationService dashboardNavService, INavigationService depositsNavService, INavigationService creditCardsNavService, NavStore navStore, ModalNavStore modalNavStore, TitleBarViewModel titleBarViewModel)
    {
        _navStore = navStore;
        _modalNavStore = modalNavStore;

        _navStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        _modalNavStore.CurrentViewModelChanged += OnCurrentModalViewModelChanged;

        NavigateDashboardCommand = new NavigateCommand(dashboardNavService);
        NavigateDepositsCommand = new NavigateCommand(depositsNavService);
        NavigateCreditCardsCommand = new NavigateCommand(creditCardsNavService);

        TitleBarViewModel = titleBarViewModel;
    }



    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }

    private void OnCurrentModalViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentModalViewModel));
        OnPropertyChanged(nameof(IsModalOpen));
    }
}
