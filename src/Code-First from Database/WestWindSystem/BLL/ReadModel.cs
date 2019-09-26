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
        public List<Supplier> ListSuppliers ()
        {
            using (var context = new WestWindContext())
            {
                var result = from data in Suppliers
                    select new Suppliers
                    {
                        CompanyName = data.CompanyName,
                        PhoneNumber = data.Phone,
                        Products = from item in data.Products
                                select new //ProductSummary
                                {
                                    ProductName = item.ProductName,
                                    UnitPrice = item.UnitPrice,
                                    QuantityPerUnit = item.QuantityPerUnit,
                                    Category = from cat in Categories
                                                where cat.CategoryID == item.CategoryID
                                                select cat.CategoryName

                                }
                    }
            }
        }
        #endregion
    }
}
