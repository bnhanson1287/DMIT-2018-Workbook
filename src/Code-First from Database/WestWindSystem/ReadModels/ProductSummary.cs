﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.Entities;

namespace WestWindSystem.ReadModels
{
    public class ProductSummary
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }

        public string QuantityPerUnit { get; set; }

        public string Category { get; set; }
    }
}
