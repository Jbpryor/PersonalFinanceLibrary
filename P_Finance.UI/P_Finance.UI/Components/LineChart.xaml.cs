﻿using LiveCharts.Wpf;
using LiveCharts;
using System.Windows.Controls;
using System.Windows.Media;
using P_Finance.Core.Models;
using System.Collections.ObjectModel;
using System.Linq;
using P_Finance.UI.Stores;
using P_Finance.UI.Utilities;
using P_Finance.Core;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace P_Finance.UI.Components
{
    /// <summary>
    /// Interaction logic for LineChart.xaml
    /// </summary>
    public partial class LineChart : UserControl
    {
        private readonly ObservableCollection<DashboardModel> _dashboardsFromDb = [];
        public IEnumerable<DashboardModel> DashboardsFromDb => _dashboardsFromDb.OrderBy(d => d.Date);
        private readonly ObservableCollection<AmountStore> _dashboards = new ObservableCollection<AmountStore>();
        public IEnumerable<AmountStore> Dashboards => _dashboards.OrderBy(d => d.Date);
        private readonly ObservableCollection<AmountStore> _purchases = new ObservableCollection<AmountStore>();
        public IEnumerable<AmountStore> Purchases => _purchases.OrderBy(p => p.Date);
        private readonly ObservableCollection<AmountStore> _spendingPowers = [];
        public IEnumerable<AmountStore> SpendingPowers => _spendingPowers.OrderBy(sp => sp.Date);
        public SeriesCollection SeriesCollection { get; set; }
        public string[]? Labels { get; set; }

        public LineChart()
        {
            InitializeComponent();
            DataContext = this;
            SeriesCollection = new SeriesCollection();


            SetPurchases();
        }

        public async void SetPurchases()
        {
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
                .GroupBy(dashboard => new { dashboard.Date.Year, dashboard.Date.Month })
                .Select(group => new
                {
                    Year = group.Key.Year,
                    Month = group.Key.Month,
                    DashboardTotal = group.Last().TotalBalance
                })
                .ToList();
            
            var groupedPurchasePowers = purchasePowers
                .GroupBy(p => new { p.Date.Year, p.Date.Month })
                .Select(group => new
                {
                    Year = group.Key.Year,
                    Month = group.Key.Month,
                    PurchasPowerTotal = group.Sum(pw => pw.Amount)
                })
                .ToList();

            var allMonths = groupedPurchases
                .Select(g => new { g.Year, g.Month })
                .Union(groupedDashboards.Select(g => new { g.Year, g.Month }))
                .Union(groupedPurchasePowers.Select(g => new { g.Year, g.Month }))
                .Distinct()
                .OrderBy(g => g.Year).ThenBy(g => g.Month)
                .ToList();


            foreach (var month in allMonths)
            {
                var purchase = groupedPurchases.FirstOrDefault(g => g.Year == month.Year && g.Month == month.Month);
                var dashboard = groupedDashboards.FirstOrDefault(g => g.Year == month.Year && g.Month == month.Month);
                var purchasePower = groupedPurchasePowers.FirstOrDefault(g => g.Year == month.Year && g.Month == month.Month);

                _purchases.Add(new AmountStore(purchase?.PurchaseTotal ?? 0, new DateTime(month.Year, month.Month, 1)));
                _dashboards.Add(new AmountStore(dashboard?.DashboardTotal ?? 0, new DateTime(month.Year, month.Month, 1)));
                _spendingPowers.Add(new AmountStore(purchasePower?.PurchasPowerTotal ?? 0, new DateTime(month.Year, month.Month, 1)));
            }            

            PopulateChartData();
        }

        private ObservableCollection<AmountStore> CreatePurchasingPowerObjects(List<DepositModel> depositsFromDb)
        {
            var purchasingPowerObjects = new ObservableCollection<AmountStore>();            

            for (int i = 1; i < DashboardsFromDb.Count(); i++)
            {
                var currentDashboard = DashboardsFromDb.ElementAt(i);
                var previousDashboard = DashboardsFromDb.ElementAt(i - 1);

                var matchingDeposits = depositsFromDb
                    .Where(deposit => (deposit.CategoryId == 2 || deposit.CategoryId == 4) &&
                                      deposit.Date.Year == currentDashboard.Date.Year &&
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
            
            // TODO - NEED TO FIGURE OUT HOW TO ADD OTHER DEPOSITS LIKE BONUSES
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
    }
}
