using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Finance.Core.Models
{
    public class LedgerModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Name { get; set; }
        public decimal Amount { get; set; }
        public int FromId { get; set; }
        public int ModelId { get; set; }
    }
}
