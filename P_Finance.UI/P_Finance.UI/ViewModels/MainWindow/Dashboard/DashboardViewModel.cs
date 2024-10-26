using P_Finance.Core.Models;
using System.Collections.ObjectModel;
using P_Finance.UI.Stores;
using P_Finance.Core.DataAccess;


namespace P_Finance.UI.ViewModels;

public class DashboardViewModel : ViewModelBase
{
    private readonly IDataConnection _connection;

    private readonly ObservableCollection<AmountStore> _totalBalanceCollection = [];
    public IEnumerable<AmountStore> TotalBalanceCollection => _totalBalanceCollection.Reverse();

    private readonly ObservableCollection<AmountStore> _gasBalanceCollection = [];
    public IEnumerable<AmountStore> GasBalanceCollection => _gasBalanceCollection.Reverse();

    private readonly ObservableCollection<AmountStore> _groceriesBalanceCollection = [];
    public IEnumerable<AmountStore> GroceriesBalanceCollection => _groceriesBalanceCollection.Reverse();

    private readonly ObservableCollection<AmountStore> _billsTotalCollection = [];
    public IEnumerable<AmountStore> BillsTotalCollection => _billsTotalCollection.Reverse();

    private readonly ObservableCollection<DashboardModel> _dashboards = [];
    public IEnumerable<DashboardModel> Dashboards => _dashboards.OrderBy(d => d.Date);


    public DashboardViewModel(IDataConnection connection)
    {
        _connection = connection;

        Years = [];

        PopulateData();
    }


    private string? _dateUpdated;
    private string? _totalSpendingPower;
    private string? _gasSpendingPower;
    private string? _groceriesSpendingPower;
    private string? _totalBillsPerCheck;

    public string? Date
    {
        get => _dateUpdated;
        set
        {
            if (_dateUpdated != value)
            {
                _dateUpdated = value;
                OnPropertyChanged(nameof(Date));
            }
        }
    }

    public string? TotalSpendingPower
    {
        get => _totalSpendingPower;
        set
        {
            if (_totalSpendingPower != value)
            {
                _totalSpendingPower = value;
                OnPropertyChanged(nameof(TotalSpendingPower));
            }
        }
    }

    public string? GasSpendingPower
    {
        get => _gasSpendingPower;
        set
        {
            if (_gasSpendingPower != value)
            {
                _gasSpendingPower = value;
                OnPropertyChanged(nameof(GasSpendingPower));
            }
        }
    }

    public string? GroceriesSpendingPower
    {
        get => _groceriesSpendingPower;
        set
        {
            if (_groceriesSpendingPower != value)
            {
                _groceriesSpendingPower = value;
                OnPropertyChanged(nameof(GroceriesSpendingPower));
            }
        }
    }

    public string? TotalBillsPerCheck
    {
        get => _totalBillsPerCheck;
        set
        {
            if (_totalBillsPerCheck != value)
            {
                _totalBillsPerCheck = value;
                OnPropertyChanged(nameof(TotalBillsPerCheck));
            }
        }
    }
    public ObservableCollection<string>? Years { get; private set; }


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
            }
        }
    }

    private bool _isRefreshing;

    private async void PopulateData()
    {
        if (_isRefreshing) return;
        _isRefreshing = true;

        DashboardModel dashboard = await _connection.DashboardData_Get();

        Date = dashboard.Date.ToString("MM/dd/yyyy");
        TotalSpendingPower = dashboard.TotalBalance.ToString("N2");
        GasSpendingPower = dashboard.GasBalance.ToString("N2");
        GroceriesSpendingPower = dashboard.GroceriesBalance.ToString("N2");
        TotalBillsPerCheck = dashboard.BillsTotal.ToString("N2");

        PopulateDashboardCollection();

        _isRefreshing = false;
    }

    public async void PopulateDashboardCollection()
    {
        _dashboards.Clear();

        var dashboardsFromDb = (await _connection.DashboardData_GetAll());

        foreach (DashboardModel dashboard in dashboardsFromDb)
        {
            _dashboards.Add(dashboard);
        }

        PopulateLineChartData();

        OnPropertyChanged(nameof(Dashboards));
    }

    public void PopulateLineChartData()
    {
        _totalBalanceCollection.Clear();
        _gasBalanceCollection.Clear();
        _groceriesBalanceCollection.Clear();
        _billsTotalCollection.Clear();

        foreach (DashboardModel dashboard in _dashboards)
        {
            _totalBalanceCollection.Add(new AmountStore(dashboard.TotalBalance));
            _gasBalanceCollection.Add(new AmountStore(dashboard.GasBalance));
            _groceriesBalanceCollection.Add(new AmountStore(dashboard.GroceriesBalance));
            _billsTotalCollection.Add(new AmountStore(dashboard.BillsTotal));
        }

        OnPropertyChanged(nameof(TotalBalanceCollection));
        OnPropertyChanged(nameof(GasBalanceCollection));
        OnPropertyChanged(nameof(GroceriesBalanceCollection));
        OnPropertyChanged(nameof(BillsTotalCollection));
    }
}