using System.Windows.Controls;
using System.Collections.ObjectModel;
using LiveCharts.Wpf;
using LiveCharts;
using P_Finance.Core.Models;
using P_Finance.Core;
using P_Finance.UI.Stores;
using System.Windows.Media;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using System.ComponentModel;

namespace P_Finance.UI.Components
{
    public partial class BarChart : UserControl, INotifyPropertyChanged
    {
        private readonly ObservableCollection<DashboardModel> _dashboardsFromDb = [];
        public IEnumerable<DashboardModel> DashboardsFromDb => _dashboardsFromDb.OrderBy(d => d.Date);
        private readonly ObservableCollection<AmountStore> _dashboards = new ObservableCollection<AmountStore>();
        public IEnumerable<AmountStore> Dashboards => _dashboards.OrderBy(d => d.Date);
        private readonly ObservableCollection<AmountStore> _purchases = new ObservableCollection<AmountStore>();
        public IEnumerable<AmountStore> Purchases => _purchases.OrderBy(p => p.Date);
        private readonly ObservableCollection<AmountStore> _spendingPowers = [];
        public IEnumerable<AmountStore> SpendingPowers => _spendingPowers.OrderBy(sp => sp.Date);

        private readonly ObservableCollection<AmountStore> _filteredDashboards = new ObservableCollection<AmountStore>();
        public IEnumerable<AmountStore> FilteredDashboards => _filteredDashboards.OrderBy(d => d.Date);
        private readonly ObservableCollection<AmountStore> _filteredPurchases = new ObservableCollection<AmountStore>();
        public IEnumerable<AmountStore> FilteredPurchases => _filteredPurchases.OrderBy(p => p.Date);
        private readonly ObservableCollection<AmountStore> _filteredSpendingPowers = [];
        public IEnumerable<AmountStore> FilteredSpendingPowers => _filteredSpendingPowers.OrderBy(sp => sp.Date);
        public SeriesCollection SeriesCollection { get; set; }
        public string[]? Labels { get; set; }

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
                    UpdateFilteredData();
                }
            }
        }

        public BarChart()
        {
            InitializeComponent();
            DataContext = this;
            SeriesCollection = new SeriesCollection();

            Years = [];


            PopulateCollections();
        }

        private bool _isRefreshing;

        public async void PopulateCollections()
        {
            if (_isRefreshing) return;

            _isRefreshing = true;

            _dashboards.Clear();
            _purchases.Clear();

            var dashboardsFromDb = (await GlobalConfig.Connection!.DashboardData_GetAll());
            var purchasesFromDb = (await GlobalConfig.Connection!.Purchases_GetAll());
            var depositsFromDb = (await GlobalConfig.Connection!.Deposits_GetAll());


            foreach (DashboardModel dashboard in dashboardsFromDb)
            {
                _dashboardsFromDb.Add(dashboard);
            }

            var purchasePowers = CreatePurchasingPowerObjects(depositsFromDb);


            var groupedPurchases = purchasesFromDb
                .OrderBy(purchase => purchase.Date)
                .Where(purchase => purchase.CategoryId != 4 && purchase.CategoryId != 5)
                .GroupBy(purchase => new { purchase.Date.Year, purchase.Date.Month })
                .Select(group => new
                {
                    Year = group.Key.Year,
                    Month = group.Key.Month,
                    PurchaseTotal = group.Sum(purchase => purchase.CategoryId == 6 ? -purchase.Amount : purchase.Amount)
                })
                .ToList();

            var groupedDashboards = dashboardsFromDb
                .OrderBy(dashboard => dashboard.Date)
                .GroupBy(dashboard => new { dashboard.Date.Year, dashboard.Date.Month })
                .Select(group => new
                {
                    Year = group.Key.Year,
                    Month = group.Key.Month,
                    DashboardTotal = group.Last().TotalBalance
                })
                .ToList();

            var groupedPurchasePowers = purchasePowers
                .OrderBy(P => P.Date)
                .GroupBy(p => new { p.Date.Year, p.Date.Month })
                .Select(group => new
                {
                    Year = group.Key.Year,
                    Month = group.Key.Month,
                    PurchasPowerTotal = group.Sum(pw => pw.Amount)
                })
                .ToList();

            var allGroups = groupedPurchases
                .Select(g => new { g.Year, g.Month })
                .Union(groupedDashboards.Select(g => new { g.Year, g.Month }))
                .Union(groupedPurchasePowers.Select(g => new { g.Year, g.Month }))
                .Distinct()
                .OrderBy(g => g.Year).ThenBy(g => g.Month)
                .ToList();


            foreach (var group in allGroups)
            {
                var purchase = groupedPurchases.FirstOrDefault(g => g.Year == group.Year && g.Month == group.Month);
                var dashboard = groupedDashboards.FirstOrDefault(g => g.Year == group.Year && g.Month == group.Month);
                var purchasePower = groupedPurchasePowers.FirstOrDefault(g => g.Year == group.Year && g.Month == group.Month);

                _purchases.Add(new AmountStore(purchase?.PurchaseTotal ?? 0, new DateTime(group.Year, group.Month, 1)));
                _dashboards.Add(new AmountStore(dashboard?.DashboardTotal ?? 0, new DateTime(group.Year, group.Month, 1)));
                _spendingPowers.Add(new AmountStore(purchasePower?.PurchasPowerTotal ?? 0, new DateTime(group.Year, group.Month, 1)));
            }

            PopulateYearDropDown();

            PopulateChartData();

            _isRefreshing = false;
        }

        private ObservableCollection<AmountStore> CreatePurchasingPowerObjects(List<DepositModel> depositsFromDb)
        {
            var purchasingPowerObjects = new ObservableCollection<AmountStore>();

            for (int i = 1; i < DashboardsFromDb.Count(); i++)
            {
                var currentDashboard = DashboardsFromDb.ElementAt(i);
                var previousDashboard = DashboardsFromDb.ElementAt(i - 1);

                var matchingDeposits = depositsFromDb
                    .OrderBy(deposit => deposit.Date)
                    .Where(deposit => deposit.Date.Year == currentDashboard.Date.Year &&
                                      deposit.Date.Month == currentDashboard.Date.Month &&
                                      deposit.Date.Hour == currentDashboard.Date.Hour);

                if (Math.Abs(currentDashboard.GasBalance - 100.00M) < 0.0001M && Math.Abs(currentDashboard.GroceriesBalance - 125.00M) < 0.0001M && matchingDeposits.Any())
                {
                    var newObject = new AmountStore(
                        currentDashboard.TotalBalance - previousDashboard.TotalBalance,
                        currentDashboard.Date
                    );

                    purchasingPowerObjects.Add(newObject);
                }
            }

            return purchasingPowerObjects;
        }

        private void PopulateChartData()
        {
            SeriesCollection.Clear();

            Labels = _purchases
                .Select(purchase => purchase.Date.ToString("MMM yyyy"))
                .ToArray();

            if (_purchases.Any())
            {
                var purchaseValues = _purchases.Select(purchase => (double)purchase.Amount);

                SeriesCollection.Add(new ColumnSeries
                {
                    Title = "Purchases",
                    Values = new ChartValues<double>(purchaseValues),
                    PointGeometry = null,
                    StrokeThickness = 1,
                    Fill = new SolidColorBrush(Color.FromRgb(227, 0, 255)),
                    Stroke = new SolidColorBrush(Color.FromRgb(227, 0, 255)),
                });
            }
            if (_spendingPowers.Any())
            {
                var spValues = _spendingPowers.Select(sp => (double)sp.Amount);

                SeriesCollection.Add(new ColumnSeries
                {
                    Title = "Spending Power",
                    Values = new ChartValues<double>(spValues),
                    PointGeometry = null,
                    StrokeThickness = 1,
                    Fill = new SolidColorBrush(Color.FromRgb(45, 174, 253)),
                    Stroke = new SolidColorBrush(Color.FromRgb(45, 174, 253)),
                });
            }
            if (_purchases.Any())
            {
                var dashboardValues = _dashboards.Select(dashboard => (double)dashboard.Amount);

                SeriesCollection.Add(new ColumnSeries
                {
                    Title = "Balance",
                    Values = new ChartValues<double>(dashboardValues),
                    PointGeometry = null,
                    StrokeThickness = 1,
                    Fill = new SolidColorBrush(Color.FromRgb(73, 247, 112)),
                    Stroke = new SolidColorBrush(Color.FromRgb(73, 247, 112)),
                });
            }
        }

        private void PopulateYearDropDown()
        {
            if (Years?.Count == 0)
            {
                var allYears = _spendingPowers.Select(sp => sp.Date.ToString("yyyy"))
                    .Concat(_purchases.Select(p => p.Date.ToString("yyyy")))
                    .Concat(_dashboards.Select(d => d.Date.ToString("yyyy")))
                    .Concat(_spendingPowers.Select(sp => sp.Date.ToString("yyyy")))
                    .Distinct()
                    .OrderBy(year => year)
                    .ToList();

                Years = new ObservableCollection<string>(new[] { "Year", "All" }.Concat(allYears));

                OnPropertyChanged(nameof(Years));
            }
        }

        private void FilterCollection<T>(
            ObservableCollection<T> filteredCollection,
            IEnumerable<T> sourceCollection,
            Func<T, DateTime> dateSelector)
        {
            filteredCollection.Clear();

            var filteredItems = sourceCollection.Where(item => SelectedYear == "Year" || SelectedYear == "All" || dateSelector(item).ToString("yyyy") == SelectedYear).ToList();

            foreach (var item in filteredItems)
            {
                filteredCollection.Add(item);
            }
        }

        private void UpdateFilteredData()
        {
            FilterCollection(_filteredSpendingPowers, _spendingPowers, spendingPower => spendingPower.Date);
            FilterCollection(_filteredDashboards, _dashboards, dashboard => dashboard.Date);
            FilterCollection(_filteredPurchases, _purchases, purchase => purchase.Date);

            PopulateChartData();
        }


        private bool CollectionFilter(DepositModel deposit)
        {
            bool includeYear = SelectedYear == "Year" || SelectedYear == "All" || deposit.Date.ToString("yyyy") == SelectedYear;

            return includeYear;
        }

        public void RefreshData()
        {
            if (_isRefreshing) return;
            PopulateCollections();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

