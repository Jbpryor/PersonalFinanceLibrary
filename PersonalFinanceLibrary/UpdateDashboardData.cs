using PersonalFinanceLibrary.DataAccess;
using PersonalFinanceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceLibrary
{
    public class UpdateDashboardData
    {
        public static void HandleDeposit(DepositModel deposit)
        {
            DashboardModel dashboard = GlobalConfig.Connection!.DashboardData_Get();

            BillsModel bills = ExcelProcessor.ConvertToBillsModel(ExcelProcessor.FullFilePath(GlobalConfig.ExcelFile));

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
            if (deposit.CategoryId == 4)
            {
                dashboard.TotalBalance += HandleExtraCheckDeposit(deposit.Amount);
            }
            if (deposit.CategoryId == 5)
            {
                dashboard.TotalBalance += deposit.Amount;
            }

            decimal HandlePaycheckDeposit(decimal checkAmount)
            {
                return checkAmount - bills.AmountFromCheck + (100 - dashboard.GasBalance) + dashboard.GroceriesBalance;
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

            decimal HandleExtraCheckDeposit(decimal extraCheckAmount)
            {
                return extraCheckAmount - (bills.AmountFromCheck - bills.BillsTotal) + dashboard.GasBalance + dashboard.GroceriesBalance + dashboard.TotalBalance;
            }

            dashboard.DateUpdated = DateTime.Now;

            GlobalConfig.Connection.UpdateDashboard(dashboard);
        }

        public static void HandlePurchase(PurchaseModel purchase)
        {
            DashboardModel dashboard = GlobalConfig.Connection!.DashboardData_Get();

            BillsModel bills = ExcelProcessor.ConvertToBillsModel(ExcelProcessor.FullFilePath(GlobalConfig.ExcelFile));

            // Gas Purchase
            if (purchase.CategoryId == 1)
            {
                if (purchase.Amount > dashboard.GasBalance)
                {
                    dashboard.GasBalance = 0;
                    dashboard.TotalBalance -= (purchase.Amount - 125);
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
                    dashboard.GroceriesBalance = 0;
                    dashboard.TotalBalance -= (purchase.Amount - 125);
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

            //decimal previousBillsTotal = dashboard.BillsTotal;

            dashboard.BillsTotal = bills.BillsTotal;

            dashboard.DateUpdated = DateTime.Now;

            GlobalConfig.Connection.UpdateDashboard(dashboard);

            //if (previousBillsTotal != dashboard.BillsTotal)
            //{
            //    if (bills.BillsTotal > previousBillsTotal)
            //    {
            //        // TODO - bills increased notification ( create a method )
            //    }
            //    else
            //    {
            //        // TODO - bills decreased notification ( create a method )
            //    }
            //}
        }
    }
}
