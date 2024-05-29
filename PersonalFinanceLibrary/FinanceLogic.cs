using PersonalFinanceLibrary.DataAccess;
using PersonalFinanceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceLibrary
{
    public class FinanceLogic
    {
        public static decimal GetBalance(CreditCardModel card)
        {
            decimal balance = 0;

            foreach (PurchaseModel purchase in card.Purchases)
            {
                if (purchase.CategoryId != 5)
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
