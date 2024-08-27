using P_Finance.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Finance.Core.DataAccess
{
    public interface IDataConnection
    {
        Task CreateDeposit(DepositModel model);
        Task CreateCreditCard(CreditCardModel model);
        Task CreatePurchase(PurchaseModel model);
        Task DeleteCreditCard(CreditCardModel model);
        Task CreateDashboard(DashboardModel model);
        //Task UpdateDashboard(DashboardModel model);
        Task<List<CreditCardModel>> CreditCards_GetAll();
        Task<List<DashboardModel>> DashboardData_GetAll();
        Task<DashboardModel> DashboardData_Get();
        Task<List<DepositModel>> Deposits_GetAll();
    }
}
