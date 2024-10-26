using P_Finance.Core.DataAccess;
using P_Finance.Core.Models;

namespace P_Finance.Core
{
    public class UpdateDashboardData
    {
        private static DashboardModel dashboard;
        private static BillsModel bills;

        public static async Task InitializeData()
        {
            dashboard = await GlobalConfig.Connection!.DashboardData_Get();

            bills = ExcelProcessor.ConvertToBillsModel(ExcelProcessor.FullFilePath(GlobalConfig.ExcelFile));

            if (dashboard.BillsTotal != bills.BillsTotal)
            {
                dashboard.BillsTotal = bills.BillsTotal;

                dashboard.Date = DateTime.Now;

                await GlobalConfig.Connection.CreateDashboard(dashboard);
            }
        }

        public static async Task HandleDeposit(DepositModel deposit)
        {
            if (deposit.CategoryId == 1)
            {
                dashboard.TotalBalance += deposit.Amount;
            }
            if (deposit.CategoryId == 2)
            {
                dashboard.TotalBalance += HandlePaycheckDeposit(deposit.Amount);
                dashboard.GasBalance = 100;
                dashboard.GroceriesBalance = 125;
            }
            if (deposit.CategoryId == 3)
            {
                dashboard.TotalBalance += HandleBonusDeposit(deposit.Amount);
            }
            // Extra Paycheck (3 in a month)
            if (deposit.CategoryId == 4)
            {
                dashboard.TotalBalance += HandlePaycheckDeposit(deposit.Amount) + bills.BillsTotal;
                dashboard.GasBalance = 100;
                dashboard.GroceriesBalance = 125;
            }
            if (deposit.CategoryId == 5)
            {
                dashboard.TotalBalance += deposit.Amount;
            }

            decimal HandlePaycheckDeposit(decimal checkAmount)
            {
                return checkAmount - bills.AmountFromCheck + (dashboard.GasBalance + 40 - 100) + dashboard.GroceriesBalance;
            }

            decimal HandleBonusDeposit(decimal bonusAmount)
            {
                return bonusAmount - RoundedPercent(bonusAmount);
            }

            int RoundedPercent(decimal number)
            {
                decimal calculatedValue = number * (decimal)(30 / 100.0);

                int roundedValue = (int)Math.Round(calculatedValue);

                if (roundedValue % 3 != 0)
                {
                    int remainder = roundedValue % 3;

                    if (remainder <= 1)
                    {
                        roundedValue -= remainder;
                    }
                    else
                    {
                        roundedValue += (3 - remainder);
                    }
                }

                return roundedValue;
            }

            //decimal HandleExtraCheckDeposit(decimal extraCheckAmount)
            //{
            //    return extraCheckAmount - (bills.AmountFromCheck - bills.BillsTotal) + (100 - dashboard.GasBalance) + dashboard.GroceriesBalance;
            //}

            dashboard.Date = DateTime.Now;

            await GlobalConfig.Connection!.CreateDashboard(dashboard);
        }

        public static async Task HandlePurchase(PurchaseModel purchase)
        {
            // Gas Purchase
            if (purchase.CategoryId == 1)
            {
                if (purchase.Amount > dashboard.GasBalance)
                {
                    dashboard.TotalBalance -= (purchase.Amount - dashboard.GasBalance);
                    dashboard.GasBalance = 0;
                }
                else
                {
                    dashboard.GasBalance -= purchase.Amount;
                }
            }
            // Grocery Purchase
            if (purchase.CategoryId == 2) 
            {
                if (purchase.Amount > dashboard.GroceriesBalance)
                {
                    dashboard.TotalBalance -= (purchase.Amount - dashboard.GroceriesBalance);
                    dashboard.GroceriesBalance = 0;
                }
                else
                {
                    dashboard.GroceriesBalance -= purchase.Amount;
                }            
            }
            // Other Purchase
            if (purchase.CategoryId == 3) 
            {
                dashboard.TotalBalance -= purchase.Amount;
            }
            // Credit Card Refund
            if (purchase.CategoryId == 6)
            {
                dashboard.TotalBalance += purchase.Amount;
            }

            dashboard.BillsTotal = bills.BillsTotal;

            dashboard.Date = DateTime.Now;

            await GlobalConfig.Connection!.CreateDashboard(dashboard);
        }
    }
}
