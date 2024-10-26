using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Finance.Core.Models
{
    public class SpendingPowerModel
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        public SpendingPowerModel(DateTime date, decimal amount)
        {
            Date = date;
            Amount = amount;
        }
    }
}
