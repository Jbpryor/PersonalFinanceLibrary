using PersonalFinanceLibrary.Models;

namespace PersonalFinanceLibrary
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
