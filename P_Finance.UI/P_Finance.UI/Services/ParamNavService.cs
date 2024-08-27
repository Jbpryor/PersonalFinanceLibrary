using P_Finance.UI.Stores;
using P_Finance.UI.ViewModels;

namespace P_Finance.UI.Services;

public class ParamNavService<TParam, TViewModel> where TViewModel : ViewModelBase
{
    private readonly NavStore _navStore;
    private readonly Func<TParam, TViewModel> _createViewModel;

    public ParamNavService(NavStore navStore, Func<TParam, TViewModel> createViewModel)
    {
        _navStore = navStore;
        _createViewModel = createViewModel;
    }
    public void Navigate(TParam param)
    {
        _navStore.CurrentViewModel = _createViewModel(param);
    }
}