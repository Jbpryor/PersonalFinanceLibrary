using P_Finance.UI.Stores;
using P_Finance.UI.ViewModels;

namespace P_Finance.UI.Services;

public class ModalNavService<TViewModel> where TViewModel : ViewModelBase
{
    private readonly ModalNavStore _navStore;
    private readonly Func<TViewModel> _createViewModel;

    public ModalNavService(ModalNavStore navStore, Func<TViewModel> createViewModel)
    {
        _navStore = navStore;
        _createViewModel = createViewModel;
    }

    public void Navigate()
    {
        _navStore.CurrentViewModel = _createViewModel();
    }
}
