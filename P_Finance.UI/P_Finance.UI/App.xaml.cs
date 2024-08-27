using Microsoft.Extensions.DependencyInjection;
using P_Finance.UI.Services;
using P_Finance.UI.Stores;
using P_Finance.UI.ViewModels;
using P_Finance.UI.Views;
using P_Finance.Core;
using P_Finance.Core.DataAccess;
using System.Windows;

namespace P_Finance.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly IServiceProvider _serviceProvider;
        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            GlobalConfig.CreateConnection();
            services.AddSingleton<IDataConnection>(GlobalConfig.Connection!);
            services.AddSingleton<CreditCardService>();
            services.AddSingleton<ModalNavStore>();
            services.AddSingleton<NavStore>();

            services.AddSingleton<INavigationService>(s => CreateDashboardNavService(s));

            services.AddTransient<MainWindowViewModel>(s => CreateMainWindowViewModel(s));
            services.AddTransient<CreditCardsViewModel>(s => new CreditCardsViewModel(s.GetRequiredService<NavStore>()));
            services.AddTransient<DashboardViewModel>();
            services.AddTransient<DepositsViewModel>();
            services.AddTransient<DepositViewModel>();
            services.AddTransient<CreditCardsViewModel>();
            services.AddTransient<PurchaseViewModel>();
            services.AddTransient<CreditCardViewModel>();
            services.AddTransient<RemoveCardViewModel>();
            services.AddTransient<CardPaymentViewModel>();
            services.AddTransient<CardRefundViewModel>();
            services.AddTransient<NewDepositViewModel>();

            services.AddTransient<NewCardViewModel>();
            services.AddTransient<TitleBarNavViewModel>(s => new TitleBarNavViewModel(s.GetRequiredService<NavStore>(), s.GetRequiredService<ModalNavStore>()));
            services.AddTransient<TitleBarViewModel>(s => new TitleBarViewModel(s.GetRequiredService<TitleBarNavViewModel>()));

            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainWindowViewModel>()
            });
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _ = InitializeDashboardData();
            INavigationService initialNavigationService = _serviceProvider.GetRequiredService<INavigationService>();
            initialNavigationService.Navigate();

            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }

        private static async Task InitializeDashboardData() => await UpdateDashboardData.InitializeData();


        private INavigationService CreateDashboardNavService(IServiceProvider serviceProvider)
        {
            return new NavService<DashboardViewModel>(
                serviceProvider.GetRequiredService<NavStore>(),
                () => serviceProvider.GetRequiredService<DashboardViewModel>());
        }

        private INavigationService CreateDepositsNavService(IServiceProvider serviceProvider)
        {
            return new NavService<DepositsViewModel>(
                serviceProvider.GetRequiredService<NavStore>(),
                () => serviceProvider.GetRequiredService<DepositsViewModel>());
        }
        private INavigationService CreateCreditCardsNavService(IServiceProvider serviceProvider)
        {
            return new NavService<CreditCardsViewModel>(
                serviceProvider.GetRequiredService<NavStore>(),
                () => serviceProvider.GetRequiredService<CreditCardsViewModel>());
        }

        private MainWindowViewModel CreateMainWindowViewModel(IServiceProvider serviceProvider)
        {
            return new MainWindowViewModel(
                CreateDashboardNavService(serviceProvider),
                CreateDepositsNavService(serviceProvider),
                CreateCreditCardsNavService(serviceProvider),
                serviceProvider.GetRequiredService<NavStore>(),
                serviceProvider.GetRequiredService<ModalNavStore>(),
                serviceProvider.GetRequiredService<TitleBarViewModel>());
        }
    }
}
