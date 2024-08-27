using P_Finance.Core.Models;
using P_Finance.Core;
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


    public DashboardViewModel(IDataConnection connection)
    {
        _connection = connection;
        _ = PopulateData();
    }


    private string? _dateUpdated;
    private string? _totalSpendingPower;
    private string? _gasSpendingPower;
    private string? _groceriesSpendingPower;
    private string? _totalBillsPerCheck;

    public string? DateUpdated
    {
        get => _dateUpdated;
        set
        {
            if (_dateUpdated != value)
            {
                _dateUpdated = value;
                OnPropertyChanged(nameof(DateUpdated));
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

    private async Task PopulateData()
    {
        DashboardModel dashboard = await _connection.DashboardData_Get();

        DateUpdated = dashboard.DateUpdated.ToString("MM/dd/yyyy");
        TotalSpendingPower = dashboard.TotalBalance.ToString("N2");
        GasSpendingPower = dashboard.GasBalance.ToString("N2");
        GroceriesSpendingPower = dashboard.GroceriesBalance.ToString("N2");
        TotalBillsPerCheck = dashboard.BillsTotal.ToString("N2");

        await PopulateDashboards();
    }

    public async Task PopulateDashboards()
    {
        _totalBalanceCollection.Clear();
        _gasBalanceCollection.Clear();
        _groceriesBalanceCollection.Clear();
        _billsTotalCollection.Clear();

        var dashboardsFromDatabase = (await _connection.DashboardData_GetAll());

        foreach (DashboardModel dashboard in dashboardsFromDatabase)
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
