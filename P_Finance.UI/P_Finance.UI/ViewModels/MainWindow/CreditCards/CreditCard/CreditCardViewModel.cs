using P_Finance.UI.Commands;
using P_Finance.UI.Stores;
using P_Finance.Core.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace P_Finance.UI.ViewModels;

public class CreditCardViewModel : ViewModelBase
{
    private readonly CreditCardModel _creditCard;
    public CreditCardModel CreditCard => _creditCard;


    private readonly ObservableCollection<PurchaseViewModel> _purchases;
    public IEnumerable<PurchaseViewModel> Purchases => _purchases.OrderByDescending(purchase => purchase.Id);



    public ObservableCollection<string>? Months { get; private set; }
    public ObservableCollection<string>? Years { get; private set; }



    private readonly ObservableCollection<AmountStore> _balanceTotalCollection;
    public IEnumerable<AmountStore> BalanceTotalCollection => _balanceTotalCollection.Reverse();


    public string? CardName => _creditCard.CardName;
    public int Id => _creditCard.Id;

    private decimal _balanceTotal;
    public decimal BalanceTotal
    {
        get => _balanceTotal;
        set
        {
            _balanceTotal = value;
            OnPropertyChanged(nameof(BalanceTotal));
        }
    }

    private string? _selectedMonth = "Month";
    public string? SelectedMonth
    {
        get => _selectedMonth;
        set
        {
            if (_selectedMonth != value)
            {
                _selectedMonth = value;
                OnPropertyChanged(nameof(SelectedMonth));
                RefreshData();
            }
        }
    }

    private string? _selectedYear = "Year";
    public string? SelectedYear
    {
        get => _selectedYear;
        set
        {
            if (_selectedYear != value)
            {
                _selectedYear = value;
                OnPropertyChanged(nameof(SelectedYear));
                RefreshData();
            }
        }
    }


    public ICommand? ViewCardPurchasesCommand { get; set; }



    public CreditCardViewModel(CreditCardModel creditCard)
    {
        _creditCard = creditCard;
        _purchases = [];
        _balanceTotalCollection = [];
        Months = [];
        Years = [];

        PopulateData();

        NewPurchaseCommand.PurchaseCreated += RefreshData;
        CardRefundCommand.RefundCreated += RefreshData;
        NewCreditCardCommand.NewCardCreated += RefreshData;
        RemoveCardCommand.CardRemoved += RefreshData;
    }



    private bool _isRefreshing;

    private void PopulateData()
    {
        if (_isRefreshing) return;

        _isRefreshing = true;

        _purchases.Clear();
        _balanceTotalCollection!.Clear();
        _balanceTotal = 0;

        foreach (PurchaseModel purchase in _creditCard.Purchases)
        {
            if (PurchaseFilter(purchase))
            {
                _purchases.Add(new PurchaseViewModel(purchase));

                if (purchase.CategoryId != 5 && purchase.CategoryId != 6)
                {
                    _balanceTotal += purchase.Amount;
                    _balanceTotalCollection!.Add(new AmountStore(_balanceTotal));
                }
                if (purchase.CategoryId == 5 || purchase.CategoryId == 6)
                {
                    _balanceTotal -= purchase.Amount;
                    _balanceTotalCollection!.Add(new AmountStore(_balanceTotal));
                }
            }           
        }

        OnPropertyChanged(nameof(Purchases));
        OnPropertyChanged(nameof(BalanceTotal));

        PopulateDropDowns();

        UpdateTopCategories();

        _isRefreshing = false;
    }


    private void PopulateDropDowns()
    {
        PopulateMonthDropDown();
        PopulateYearDropDown();
    }


    private void PopulateMonthDropDown()
    {
        if (Months?.Count == 0)
        {
            var months = _creditCard.Purchases.Select(purchase => purchase.Date.ToString("MM")).Distinct().OrderBy(month => month).ToList();

            Months = new ObservableCollection<string>(new[] { "Month", "All" }.Concat(months));

            OnPropertyChanged(nameof(Months));
        }
    }

    private void PopulateYearDropDown()
    {
        if (Years?.Count == 0)
        {
            var years = _creditCard.Purchases.Select(_purchase => _purchase.Date.ToString("yyyy")).Distinct().OrderBy(years => years).ToList();

            Years = new ObservableCollection<string>(new[] { "Year", "All" }.Concat(years));

            OnPropertyChanged(nameof(Years));
        }
    }

    private bool PurchaseFilter(PurchaseModel purchase)
    {
        bool includeMonth = SelectedMonth == "Month" || SelectedMonth == "All" || purchase.Date.ToString("MM") == SelectedMonth;
        bool includeYear = SelectedYear == "Year" || SelectedYear == "All" || purchase.Date.ToString("yyyy") == SelectedYear;

        return includeMonth && includeYear;
    }

    public void RefreshData()
    {
        if (_isRefreshing) return;
        PopulateData();
    }

    public Dictionary<string, ObservableCollection<PurchaseViewModel>> GetPurchasesByCategory()
    {
        return _purchases.Where(purchase => purchase.CategoryId != 5 &&  purchase.CategoryId != 6).GroupBy(purchase => purchase.CategoryName!).ToDictionary(group => group.Key, group => new ObservableCollection<PurchaseViewModel>(group.Reverse().ToList()));
    }

    public ObservableCollection<KeyValuePair<string, ObservableCollection<PurchaseViewModel>>>? TopCategories { get; set; }

    private void UpdateTopCategories()
    {
        var purchasesByCategory = GetPurchasesByCategory();
        
        var totalAmounts = purchasesByCategory.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Sum(purchase => purchase.Amount));

        var topCategoryNames = totalAmounts.OrderByDescending(kvp => kvp.Value).Take(4).Select(kvp => kvp.Key).ToList();

        TopCategories = new ObservableCollection<KeyValuePair<string, ObservableCollection<PurchaseViewModel>>>(topCategoryNames.Select(name => new KeyValuePair<string, ObservableCollection<PurchaseViewModel>>(name, purchasesByCategory[name])));
        OnPropertyChanged(nameof(TopCategories));
    }
}
