using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.Entities;

namespace WestWindSystem.DataModels
{
    public class SupplierSummary
    {
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public virtual IEnumerable<ProductSummary> Products { get; set; }
    }
}
