using P_Finance.UI.Commands;
using P_Finance.UI.Services;
using P_Finance.UI.Stores;
using P_Finance.UI.ViewModels;
using System.Collections.ObjectModel;

public class TitleBarNavViewModel : ViewModelBase
{
    private readonly NavStore _navStore;
    private readonly ModalNavStore _modalNavStore;
    public ViewModelBase? CurrentViewModel => _navStore.CurrentViewModel;


    private readonly Dictionary<Type, List<NavLinkStore>> _navLinks;
    public ObservableCollection<NavLinkStore> NavLinksContainer { get; }


    public TitleBarNavViewModel(NavStore navStore, ModalNavStore modalNavStore)
    {
        _navStore = navStore;
        _modalNavStore = modalNavStore;

        _navStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        NavLinksContainer = [];

        _navLinks = InitializeNavLinks(_modalNavStore);
    }


    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
        UpdateNavLinks(CurrentViewModel!);
    }


    public void UpdateNavLinks(ViewModelBase currentView)
    {
        NavLinksContainer.Clear();
        var navLinks = GetNavLinks(currentView.GetType());

        foreach (var navLinkData in navLinks)
        {
            NavLinksContainer.Add(navLinkData);
        }
    }


    private static Dictionary<Type, List<NavLinkStore>> InitializeNavLinks(ModalNavStore modalNavStore)
    {
        return new Dictionary<Type, List<NavLinkStore>>
        {
            {
                typeof(DepositsViewModel), new List<NavLinkStore>
                {
                    new("New Deposit", new ModalCommand<NewDepositViewModel>(new ModalNavService<NewDepositViewModel>(modalNavStore, () => new NewDepositViewModel(modalNavStore)))),
                }
            },
            {
                typeof(CreditCardViewModel), new List<NavLinkStore>
                {
                    new("New Purchase", new ModalCommand<NewPurchaseViewModel>(new ModalNavService<NewPurchaseViewModel>(modalNavStore, () => new NewPurchaseViewModel(modalNavStore))))
                }
            },
            {
                typeof(CreditCardsViewModel), new List<NavLinkStore>
                {
                    new("New Card", new ModalCommand<NewCardViewModel>(new ModalNavService<NewCardViewModel>(modalNavStore, () => new NewCardViewModel(modalNavStore)))),
                    new("Card Payment", new ModalCommand<CardPaymentViewModel>(new ModalNavService<CardPaymentViewModel>(modalNavStore, () => new CardPaymentViewModel(modalNavStore)))),
                    new("Card Refund", new ModalCommand<CardRefundViewModel>(new ModalNavService<CardRefundViewModel>(modalNavStore, () => new CardRefundViewModel(modalNavStore)))),
                    new("Remove Card", new ModalCommand<RemoveCardViewModel>(new ModalNavService<RemoveCardViewModel>(modalNavStore, () => new RemoveCardViewModel(modalNavStore))))
                }
            }
        };
    }


    public List<NavLinkStore> GetNavLinks(Type viewType) => _navLinks.TryGetValue(viewType, out var links) ? links : [];
}
