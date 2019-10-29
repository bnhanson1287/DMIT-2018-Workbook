# Order Processing

> Orders are shipped directly from our suppliers to our customers. As such, suppliers log onto our system to see what orders there are for the products that they provide.

## User Interface

Suppliers will be interacting with a page that shows the following information.

![Mockup](./Shipping-Orders.svg)

The information shown here will be displayed in a **ListView**, using the *EditItemTemplate* as the part that shows the details for a given order.

## Events and Interactions
![Plan](ShippingOrders_Plan.svg)

- ![](1.svg)**Page_Load** event
    - ![](a.svg) - Supplier/Contact names obtained by who the logged in user is.
    - ![](b.svg) - Load the ListView data
        - **`List<OutstandingOrder>OrderProcessingController.LoadOrders(supplierID)`**
    - ![](c.svg) - Load the list of shippers from BLL
        - **`List<ShipperSelection>OrderProcessingController.ListShipers()`**
- ![](2.svg) - **EditCommand** click event
    - Default EditCommand behaviour of the ListView 
    - `<EditItemTemplate>` will display the extended information of the products ![](d.svg) and other details of the order.
- ![](3.svg) **ShipOrder** click
    - Use a custom command name of "ShipOrder" and handle the ListView's `ItemCommand` event. 
    - Gather information from the form of the products to be shipped and the shipping information. This is sent to the following method in the BLL for processing:
```csharp
void OrderProcessingController.ShipOrder(int orderId, ShippingDirections shipping, List<ShippedItem> items)
```
## POCOs/DTOs
The POCOs/DTOs are simply classes that will hold our data when we are performing Queries or issuing Commands to the BLL.

```C#

```
### Commands
```C#
public class ShippingDirections
{
    public int ShipperId { get; set; }
    public string TrackingCode { get; set; }
    public decimal? FreightCharge { get; set; }
}
```
```C#
public class ShippedItem
{
    public int ProductId { get; set; }
    public int ShipQuantity { get; set; }
}
```
### Queries
```C#
public class ShipperSelection
{
    public int ShipperId { get; set; }
    public string Shipper { get; set; }
}
```
```C#
public class OutstandingOrder
{
    public int OrderId { get; set; }
    public string ShipToName { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime RequiredBy { get; set; }
    public TimeSpan DaysRemaining { get; } // Calculated
    public IEnumerable<OrderProductInformation> OutstandingItems { get; set; }
    public string FullShippingAddress { get; set; }
    public string Comments { get; set; }
}
```
```C#
public class OrderProductInformation
{
    public int ProductId {get;set;}
    public string ProductName {get;set;}
    public short Qty {get;set;}
    public string QtyPerUnit {get;set;}
    public short Outstanding {get;set;}
    // NOTE: Outstanding <= OrderDetails.Quantity - Sum(ManifestItems.ShipQuantity) for that product/order
}
```
```C#
public class OrderItem
{
    public int ProductID {get;set;}
    public string ProductName {get;set;}
    public short Qty {get;set;}
    public short QtyPerUnit {get;set;}
    public short Outstanding {get;set;} //Calculated as OD.Quantity - Sum(Shipped qty)
}
```
## BLL Processing
All product shipments are handled by the **`OrderProcessingController`**. It supports the following methods.

- **`List<OutstandingOrder> LoadOrders(int supplierID)`**
    - **Validation:**
        - Make sure the supplier ID exists, otherwise throw an exception.
        -[Advanced:] Make sure the logged-in user works for the identified supplier.
    - Query for outstanding orders, getting data from the following tables:
        - TODO: List table names
    - **`void ShipOrder(int orderId, ShippingDirections shipping, List<ProductShipment> products)`**
  - **Validation:**
    - OrderId must be valid
    - `List<ShippedItems>` cannot be empty/null
    - Products identified must be on the order
    - Quantity must be greater than zero and less than or equal to the quantity     outstanding
    - Shipper must exist
    - Freight charge must either be null (no charge) or > $0.00
  - **Processing** (tables/data that must be updated/inserted/deleted/whatever)
    - Create new Shipment
    - Add all manifest items
    - Check if order is complete; if so, update Order.Shipped
