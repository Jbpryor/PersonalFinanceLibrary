using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceLibrary.Models
{
    public class DepositModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Name { get; set; }
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public string? CategoryName
        {
            get
            {
                return DepositCategoryModel.GetCategoryNameById(CategoryId);
            }
        }

    }

    // Logic

    // -- Total Spending Power Logic
    // take currentTotal += (gasTotal + groceryTotal + leftFromCheck)
    // gasTotal = 100
    // groceryTotal = 125

    // -- Gas Purchase Logic
    // if gasPurchase <= gasTotal ? gasTotal -= gasPurchase : currentTotal -= (gasPurchase - gasTotal) && gasTotal = 0

    // -- Grocery Purchase Logic
    // if groceryPurchase <= groceryTotal ? groceryTotal -= groceryPurchase : currentTotal -= (groceryPurchase - groceryTotal) && groceryTotal = 0

    // -- Other Purchase Logic
}
