using PersonalFinanceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceLibrary.DataAccess
{
    public interface IDataConnection
    {
        Task CreateDeposit(DepositModel model);
        Task CreateCreditCard(CreditCardModel model);
        Task CreatePurchase(PurchaseModel model);
        Task DeleteCreditCard(CreditCardModel model);
        Task CreateDashboard(DashboardModel model);
        Task UpdateDashboard(DashboardModel model);
        Task<List<CreditCardModel>> CreditCards_GetAll();
        Task<DashboardModel> DashboardData_Get();
        Task<List<DepositModel>> Deposits_GetAll();
    }

    // To populate the dashboard...

    // need to store full deposit balance in a variable and update the value each time there is a deposit

    // need to store full purchase balance in a variable and update the value each time there is a purchase unless category is gas or grocery

    // need to store gas total in a variable

    // need to store grocery total in a variable

}
