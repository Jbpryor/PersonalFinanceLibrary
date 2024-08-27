using P_Finance.UI.Stores;
using P_Finance.UI.ViewModels;

namespace P_Finance.UI.Services
{
    public class NavService<TViewModel> : INavigationService where TViewModel : ViewModelBase
    {
        private readonly NavStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public NavService(NavStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}

