using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.DataModels;

namespace WestWindSystem.BLL
{
    [DataObject]
    public class OrderProcessingController
    {

        #region Queries


        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<OutstandingOrder> LoadOrders(int supplierID)
        {
            
            // TODO: Implement this method with the following
            /*
             * Validation:
                Make sure the supplier ID exists, otherwise throw an exception. -[Advanced:] Make sure the logged-in user works for the identified supplier.
                Query for outstanding orders, getting data from the following tables:
                TODO: List table names
             */
             using(var context = new WestWindContext())//using my DAL object
             {
                //Validation
                var supplier = context.Suppliers.Find(supplierID);
                if(supplier == null)
                {
                    throw new Exception("Invalid supplier - unable to load orders.");
                }
                //Processing
                var result =
                from sale in context.Orders
                    where !sale.Shipped
                        && sale.OrderDate.HasValue
                    select new OutstandingOrder
                    {
                        OrderId = sale.OrderID,
                        ShipToName = sale.ShipName,
                        OrderDate = sale.OrderDate.Value,
                        RequiredBy = sale.RequiredDate.Value,
                        OutstandingItems = from items in sale.OrderDetails
                                           where items.Product.SupplierID == supplierID
                                           select new OrderItem
                                           {
                                               ProductId = items.ProductID,
                                               ProductName = items.Product.ProductName,
                                               Qty = items.Quantity,
                                               QtyPerUnit = items.Product.QuantityPerUnit
                                               //TODO: Figure out outstanding quantity
                                               //				Outstanding = (from ship in items.Order.Shipments
                                               //							  from shipItem in ship.ManifestItems
                                               //							  where shipItem.ProductID == items.ProductID
                                               //							  select shipItem.ShipQuantity).Sum()
                                           },
                        FullShippingAddress = //TODO: sale.ShipAddressID
                        sale.Customer.Address.Street + Environment.NewLine +
                        sale.Customer.Address.City + ", " +
                        sale.Customer.Address.Region + Environment.NewLine +
                        sale.Customer.Address.Country + " " +
                        sale.Customer.Address.PostalCode + Environment.NewLine,
                        Comments = sale.Comments
                    };
                    return result.ToList();
             }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ShipperSelection> ShipperList()
        {
            using(var context = new WestWindContext())
            {
                var result = from shipper in context.Shippers
                             orderby shipper.CompanyName
                             select new ShipperSelection
                             {
                                 ShipperId = shipper.ShipperID,
                                 Shipper = shipper.CompanyName

                             };
                return result.ToList();
            }
        }
        #endregion

        #region Commands
        public void ShipOrder(int orderId, ShippingDirections shipping, List<ShippedItem> items)
        {
            using (var context = new WestWindContext())
            {
                //VALIDATION

                //OrderId must be valid
                var existingOrder = context.Orders.Find(orderId);

                if(existingOrder == null)
                {
                    throw new Exception("Order does not exist");
                }
                if(existingOrder.Shipped)
                {
                    throw new Exception("This order has already been complete.");
                }
                if(!existingOrder.OrderDate.HasValue)
                {
                    throw new Exception("This order is not ready to be shipped (no order date has been specified)");
                }

                // ShippingDirections is required (cannot be null)
                if(shipping == null)
                {
                    throw new Exception("No shipping details have been provided.");
                }
                // Shipper must exist
                var shipper = context.Shippers.Find(shipping.ShipperId);
                if(shipper == null)
                {
                    throw new Exception("Invalid shipper ID");
                }
                //Freight charge must be either null (no charge) or > $0.00
                if(shipping.FreightCharge.HasValue && shipping.FreightCharge <=0)
                {
                    throw new Exception("Freight charge must be either a positive value or no charge");
                }
                //List<ShippedItem> cannot be empty/null
                if(items == null || !items.Any())
                {
                    throw new Exception("No products identified for shipping");
                }
                //The products must be on the order
                foreach(var item in items)
                {
                    if (items == null) throw new Exception("Black items listed in the products to be shipped");
                    if (!existingOrder.OrderDetails.Any(x => x.ProductID.ToString() == item.Product)) throw new Exception($"The product{item.Product} does not exist");
                }

                /*
                    Validation:
                        
                        
                        
                         AND items that this supplier provides
                        Quantities must be greater than zero and less than or equal to the quantity outstanding
                        Shipper must exist
                        
                        Processing (tables/data that must be updated/inserted/deleted/whatever)
                        Create new Shipment
                        Add all manifest items
                        Check if order is complete; if so, update Order.Shipped
                 */
            }
        }
        #endregion
    }

}
