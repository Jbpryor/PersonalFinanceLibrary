using P_Finance.UI.Stores;

namespace P_Finance.UI.Services
{
    public class CloseModalNavService : INavigationService
    {
        private readonly ModalNavStore _navStore;

        public CloseModalNavService(ModalNavStore navStore)
        {
            _navStore = navStore;
        }

        public void Navigate()
        {
            _navStore.CloseModal();
        }
    }
}
