using P_Finance.UI.Commands;
using P_Finance.UI.Services;
using P_Finance.UI.Stores;
using P_Finance.Core.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace P_Finance.UI.ViewModels;

public class NewPurchaseViewModel : ViewModelBase
{

    private readonly ObservableCollection<PurchaseCategoryModel> _categories;
    public IEnumerable<PurchaseCategoryModel> Categories => _categories;


    private readonly CreditCardService _creditCardService;
    public ObservableCollection<CreditCardViewModel> CreditCards => [.. _creditCardService.CreditCards.OrderByDescending(card => card.Id)];


    private readonly ModalNavStore _modalNavStore;



    private string? _name;
    public string? Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    
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
            OnPropertyChanged(nameof(CanMakePurchase));
        }
    }

    
    private PurchaseCategoryModel? _selectedCategory;
    public PurchaseCategoryModel? SelectedCategory
    {
        get { return _selectedCategory; }
        set
        {
            _selectedCategory = value;
            OnPropertyChanged(nameof(SelectedCategory));
            OnPropertyChanged(nameof(CanMakePurchase));
        }
    }


    public AsyncCommandBase NewPurchaseCommand { get; }
    public ICommand CloseModalCommand { get; }


    public NewPurchaseViewModel(ModalNavStore modalNavStore)
    {
        _creditCardService = CreditCardService.CardService;
        _modalNavStore = modalNavStore;
        _categories = [];

        NewPurchaseCommand = new NewPurchaseCommand(this, _modalNavStore);
        CloseModalCommand = new CloseModalCommand(_modalNavStore);

        PopulateData();
        PopulateCategories();
        _selectedCard = CreditCards.First();
    }


    private void PopulateCategories()
    {
        List<PurchaseCategoryModel> _categoryList = [.. PurchaseCategoryModel.Categories().Where(category => category.Id != 5 && category.Id != 6).OrderBy(category => category.Name)];

        foreach (PurchaseCategoryModel category in _categoryList)
        {
            _categories.Add(category);
        }
    }


    private async void PopulateData()
    {
        await _creditCardService.GetCreditCards();
    }

    public bool CanMakePurchase => HasSelectedCard && HasEnteredName && HasAmountGreaterThanZero && HasSelectedCategory;
    private bool HasSelectedCard => SelectedCard != null;
    private bool HasEnteredName => !string.IsNullOrEmpty(SelectedCard!.CardName);
    private bool HasAmountGreaterThanZero => Amount > 0;
    private bool HasSelectedCategory => SelectedCategory != null;
}
