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
        void CreateDeposit(DepositModel model);
        void CreateCreditCard(CreditCardModel model);
        void CreatePurchase(PurchaseModel model);
        void DeleteCreditCard(CreditCardModel model);
        void CreateDashboard(DashboardModel model);
        void UpdateDashboard(DashboardModel model);
        List<CreditCardModel> CreditCards_GetAll();
        DashboardModel DashboardData_Get();
    }

    // To populate the dashboard...

    // need to store full deposit balance in a variable and update the value each time there is a deposit

    // need to store full purchase balance in a variable and update the value each time there is a purchase unless category is gas or grocery

    // need to store gas total in a variable

    // need to store grocery total in a variable

}
