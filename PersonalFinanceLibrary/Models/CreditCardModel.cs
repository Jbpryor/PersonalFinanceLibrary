using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceLibrary.Models
{
    public class CreditCardModel
    {
        public int Id { get; set; }
        public string? CardName { get; set; }
        public List<PurchaseModel> Purchases { get; set; } = [];
    }
}
