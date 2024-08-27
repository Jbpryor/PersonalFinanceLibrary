using P_Finance.UI.Commands;
using P_Finance.UI.Services;
using P_Finance.UI.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace P_Finance.UI.ViewModels;

public class CreditCardsViewModel : ViewModelBase
{
    private readonly CreditCardService _creditCardService;
    private readonly NavStore? _navStore;

    private readonly ParamNavService<CreditCardViewModel, CreditCardViewModel> _paramNavService;

    public ObservableCollection<CreditCardViewModel> CreditCards => _creditCardService.CreditCards;



    public ICommand? ViewCardPurchasesCommand { get; }



    public CreditCardsViewModel(NavStore navStore)
    {
        _creditCardService = CreditCardService.CardService;
        _navStore = navStore;

        ParamNavService<CreditCardViewModel, CreditCardViewModel> paramNavService = new ParamNavService<CreditCardViewModel, CreditCardViewModel>(_navStore, vm => new CreditCardViewModel(vm.CreditCard));

        _paramNavService = paramNavService;

        Task? task = PopulateCreditCards(paramNavService);
    }

    private bool _isRefreshing;

    public async Task PopulateCreditCards(ParamNavService<CreditCardViewModel, CreditCardViewModel> paramNavService)
    {
        if (_isRefreshing) return;

        _isRefreshing = true;

        await _creditCardService.GetCreditCards();

        foreach (var cardViewModel in CreditCards)
        {
            cardViewModel.ViewCardPurchasesCommand = new ViewCardPurchasesCommand(cardViewModel, paramNavService);
        }

        _isRefreshing = false;
    }

    public void RefreshData()
    {
        if (_isRefreshing) return;
        _ = PopulateCreditCards(_paramNavService);
    }
}

