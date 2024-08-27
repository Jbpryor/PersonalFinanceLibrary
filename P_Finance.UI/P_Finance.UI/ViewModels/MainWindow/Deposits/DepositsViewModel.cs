using P_Finance.Core.Models;
using P_Finance.Core;
using System.Collections.ObjectModel;
using P_Finance.UI.Commands;


namespace P_Finance.UI.ViewModels;

public class DepositsViewModel : ViewModelBase
{
    private readonly ObservableCollection<DepositViewModel> _deposits;
    public IEnumerable<DepositViewModel> Deposits => _deposits;

    public ObservableCollection<string>? Months { get; private set; }
    public ObservableCollection<string>? Years { get; private set; }


    private decimal? _depositsTotal;
    public decimal? DepositsTotal
    {
        get => _depositsTotal;
        set
        {
            _depositsTotal = value;
            OnPropertyChanged(nameof(DepositsTotal));
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
    public DepositsViewModel()
    {
        _deposits = [];

        Months = [];
        Years = [];

        PopulateData();

        NewDepositCommand.DepositCreated += RefreshData;

    }


    private bool _isRefreshing;

    private async void PopulateData()
    {
        if (_isRefreshing) return;

        _isRefreshing = true;

        _deposits.Clear();
        _depositsTotal = 0;

        var depositsFromDatabase = (await GlobalConfig.Connection!.Deposits_GetAll()).OrderByDescending(deposit => deposit.Id);

        foreach (DepositModel deposit in depositsFromDatabase)
        {
            if (DepositFilter(deposit))
            {

                _deposits.Add(new DepositViewModel(deposit));

                _depositsTotal += deposit.Amount;
            }
        }


        OnPropertyChanged(nameof(Deposits));
        OnPropertyChanged(nameof(DepositsTotal));

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
            var months = _deposits.Select(deposit => deposit.Date.ToString("MM")).Distinct().OrderBy(month => month).ToList();

            Months = new ObservableCollection<string>(new[] { "Month", "All" }.Concat(months));

            OnPropertyChanged(nameof(Months));
        }
    }
    private void PopulateYearDropDown()
    {
        if (Years?.Count == 0)
        {
            var years = _deposits.Select(deposit => deposit.Date.ToString("yyyy")).Distinct().OrderBy(years => years).ToList();

            Years = new ObservableCollection<string>(new[] { "Year", "All" }.Concat(years));

            OnPropertyChanged(nameof(Years));
        }
    }

    private bool DepositFilter(DepositModel deposit)
    {
        bool includeMonth = SelectedMonth == "Month" || SelectedMonth == "All" || deposit.Date.ToString("MM") == SelectedMonth;
        bool includeYear = SelectedYear == "Year" || SelectedYear == "All" || deposit.Date.ToString("yyyy") == SelectedYear;

        return includeMonth && includeYear;
    }

    public void RefreshData()
    {
        if (_isRefreshing) return;
        PopulateData();
    }

    public Dictionary<string, ObservableCollection<DepositViewModel>> GetDepositsByCategory()
    {
        return _deposits.GroupBy(deposit => deposit.CategoryName!).ToDictionary(group => group.Key, group => new ObservableCollection<DepositViewModel>(group.ToList()));
    }

    public ObservableCollection<KeyValuePair<string, ObservableCollection<DepositViewModel>>>? TopCategories { get; set; }

    private void UpdateTopCategories()
    {
        var depositsByCategory = GetDepositsByCategory();

        var totalAmounts = depositsByCategory.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Sum(deposit => deposit.Amount));

        var topCategoryNames = totalAmounts.OrderByDescending(kvp => kvp.Value).Take(4).Select(kvp => kvp.Key).ToList();

        TopCategories = new ObservableCollection<KeyValuePair<string, ObservableCollection<DepositViewModel>>>(topCategoryNames.Select(name => new KeyValuePair<string, ObservableCollection<DepositViewModel>>(name, depositsByCategory[name])));

        OnPropertyChanged(nameof(TopCategories));
    }
}
