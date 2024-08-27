using P_Finance.UI.Commands;
using P_Finance.UI.Services;
using P_Finance.UI.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace P_Finance.UI.ViewModels;

public class CardPaymentViewModel : ViewModelBase
{

    private readonly CreditCardService _creditCardService;
    public ObservableCollection<CreditCardViewModel> CreditCards => _creditCardService.CreditCards;

    private readonly ModalNavStore _modalNavStore;


    private decimal _amount;
    public decimal Amount
    {
        get
        {
            return _amount;
        }
        set
        {
            _amount = value;
            OnPropertyChanged(nameof(Amount));
        }
    }


    private CreditCardViewModel? _selectedCard;
    public CreditCardViewModel? SelectedCard
    {
        get { return _selectedCard; }
        set
        {
            _selectedCard = value;
            OnPropertyChanged(nameof(SelectedCard));
            OnPropertyChanged(nameof(CanMakePayment));
        }
    }


    public AsyncCommandBase PaymentCommand { get; }
    public ICommand CloseModalCommand { get; }


    public CardPaymentViewModel(ModalNavStore modalNavStore)
    {
        _creditCardService = CreditCardService.CardService;
        _modalNavStore = modalNavStore;

        PaymentCommand = new CardPaymentCommand(this, _modalNavStore);
        CloseModalCommand = new CloseModalCommand(_modalNavStore);
        PopulateData();
    }


    private async void PopulateData()
    {
        await _creditCardService.GetCreditCards();
    }


    public bool CanMakePayment => HasSelectedCard && HasAmountGreaterThanZero;
    private bool HasSelectedCard => SelectedCard != null && !string.IsNullOrEmpty(SelectedCard.CardName);
    private bool HasAmountGreaterThanZero => Amount > 0;
}
