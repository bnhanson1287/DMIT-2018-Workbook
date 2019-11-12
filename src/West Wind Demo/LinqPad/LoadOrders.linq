<Query Kind="Program">
  <Connection>
    <ID>ad5c237c-d0e0-4642-bd26-cdd8f1863069</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

void Main()
{
	int supplier = 8; // 2, 7, 8, 16, 19
	var output = LoadOrders(supplier);
	output.Dump();
}
List<OutstandingOrder> LoadOrders(int supplierID)
{
	var result =
	from sale in Orders
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
								 sale.Customer.Address.Address+ Environment.NewLine +
								 sale.Customer.Address.City+ ", " +
								 sale.Customer.Address.Region+ Environment.NewLine +
								 sale.Customer.Address.Country+ " " +
								 sale.Customer.Address.PostalCode+ Environment.NewLine,
			Comments = sale.Comments
		};
		return result.ToList();
		
    //throw new NotImplementedException();
    // TODO: Implement this method with the following
    /*
     * Validation:
        Make sure the supplier ID exists, otherwise throw an exception. -[Advanced:] Make sure the logged-in user works for the identified supplier.
        Query for outstanding orders, getting data from the following tables:
        TODO: List table names
     */
}
public class OutstandingOrder
    {
        public int OrderId { get; set; }
        public string ShipToName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredBy { get; set; }
        public TimeSpan DaysRemaining { get; } // TODO: Calculated
        public IEnumerable<OrderItem> OutstandingItems { get; set; }
        public string FullShippingAddress { get; set; }
        public string Comments { get; set; }
    }
	 public class OrderItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public short Qty { get; set; }
        public string QtyPerUnit { get; set; }
        public short Outstanding { get; set; }
        //Outstanding <= OrderDetails.Quantity - Sum(ManifestItems.ShipQuantity)
    }