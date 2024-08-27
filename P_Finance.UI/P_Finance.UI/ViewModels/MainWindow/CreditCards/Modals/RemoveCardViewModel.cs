using P_Finance.UI.Commands;
using P_Finance.UI.Services;
using P_Finance.UI.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace P_Finance.UI.ViewModels;

public class RemoveCardViewModel : ViewModelBase
{
    private readonly CreditCardService _creditCardService;
    public ObservableCollection<CreditCardViewModel> CreditCards => _creditCardService.CreditCards;

    private readonly ModalNavStore _modalNavStore;



    private CreditCardViewModel? _selectedCard;
    public CreditCardViewModel? SelectedCard
    {
        get { return _selectedCard; }
        set
        {
            _selectedCard = value;
            OnPropertyChanged(nameof(SelectedCard));
            OnPropertyChanged(nameof(CanRemoveCard));
        }
    }


    public AsyncCommandBase DeleteCardCommand { get; }
    public ICommand CloseModalCommand { get; }

    public RemoveCardViewModel(ModalNavStore modalNavStore)
    {
        _creditCardService = CreditCardService.CardService;
        _modalNavStore = modalNavStore;

        DeleteCardCommand = new RemoveCardCommand(this, _modalNavStore);
        CloseModalCommand = new CloseModalCommand(_modalNavStore);

        PopulateData();
    }


    public async void PopulateData()
    {
        await _creditCardService.GetCreditCards();
    }

    public bool CanRemoveCard => HasSelectedCard;
    private bool HasSelectedCard => SelectedCard != null && !string.IsNullOrEmpty(SelectedCard.CardName);

    public bool ConfirmRemove()
    {
        System.Windows.MessageBoxResult result = System.Windows.MessageBox.Show(
            "Are you sure you want to delete this credit card?",
            "Confirm Delete",
            System.Windows.MessageBoxButton.YesNo,
            System.Windows.MessageBoxImage.Question);

        return result == System.Windows.MessageBoxResult.Yes;
    }
}
