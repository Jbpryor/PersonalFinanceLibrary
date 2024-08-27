using P_Finance.Core.DataAccess;
using P_Finance.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Finance.Core
{
    public class FinanceLogic
    {
        public static decimal GetBalance(CreditCardModel card)
        {
            decimal balance = 0;

            foreach (PurchaseModel purchase in card.Purchases)
            {
                if (purchase.CategoryId != 5 && purchase.CategoryId != 6)
                {
                    balance += purchase.Amount;
                }
                if (purchase.CategoryId == 5 || purchase.CategoryId == 6)
                {
                    balance -= purchase.Amount;
                }                
            }

            return balance;
        }
    }
}
