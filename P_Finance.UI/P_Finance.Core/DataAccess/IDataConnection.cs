using P_Finance.Core.Models;

namespace P_Finance.Core.DataAccess
{
    public interface IDataConnection
    {
        Task CreateDeposit(DepositModel model);
        Task CreateCreditCard(CreditCardModel model);
        Task CreatePurchase(PurchaseModel model);
        Task CreateDashboard(DashboardModel model);
        Task DeleteCreditCard(CreditCardModel model);
        //Task UpdateDashboard(DashboardModel model);
        Task<DashboardModel> DashboardData_Get();
        Task<List<CreditCardModel>> CreditCards_GetAll();
        Task<List<DashboardModel>> DashboardData_GetAll();
        Task<List<DepositModel>> Deposits_GetAll();
        Task<List<PurchaseModel>> Purchases_GetAll();
    }
}
