using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.DataModels;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{
    [DataObject]
    public class ReadModel
    {
        #region Query Supplier Summary
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<SupplierSummary> ListSuppliers()
        {   
            using (var context = new WestWindContext())
            {
            var result = from data in context.Suppliers
                            select new SupplierSummary
                            {
                                CompanyName = data.CompanyName,
                                Phone = data.Phone,
                                Products = from item in data.Products
                                        select new ProductSummary
                                        {
                                            ProductName = item.ProductName,
                                            UnitPrice = item.UnitPrice,
                                            QuantityPerUnit = item.QuantityPerUnit,
                                            Category = item.Category.CategoryName

                                        }
                            };
                return result.ToList();
            }
            
        }
        #endregion
    }
}
