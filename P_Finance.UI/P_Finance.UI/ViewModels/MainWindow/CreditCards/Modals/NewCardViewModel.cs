using P_Finance.UI.Commands;
using P_Finance.UI.Services;
using P_Finance.UI.Stores;
using System.Windows.Input;

namespace P_Finance.UI.ViewModels;

public class NewCardViewModel : ViewModelBase
{

    private readonly CreditCardService _creditCardService;
    private readonly ModalNavStore _modalNavStore;

    private string? _cardName;

    public string? CardName
    {
        get => _cardName;
        set
        {
            _cardName = value;
            OnPropertyChanged(nameof(CardName));
            OnPropertyChanged(nameof(CanCreateNewCard));
        }
    }


    public AsyncCommandBase CreateCardCommand { get; }
    public ICommand CloseModalCommand { get; }

    public NewCardViewModel(ModalNavStore modalNavStore)
    {
        _creditCardService = CreditCardService.CardService;
        _modalNavStore = modalNavStore;

        CreateCardCommand = new NewCreditCardCommand(this, _modalNavStore);
        CloseModalCommand = new CloseModalCommand(_modalNavStore);

        PopulateData();
    }


    public async void PopulateData()
    {
        await _creditCardService.GetCreditCards();
    }


    public bool CanCreateNewCard => HasCardName;
    private bool HasCardName => !string.IsNullOrEmpty(CardName);

}



