﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceLibrary.Models
{
    public class BillsModel
    {
        public int Id { get; set; }
        public decimal BillsTotal { get; set; }
        public decimal AmountFromCheck { get; set; }
    }
}
