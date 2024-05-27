using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceLibrary.Models
{
    public class PurchaseModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Name { get; set; }
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public int CreditCardId { get; set; }
    }
}
