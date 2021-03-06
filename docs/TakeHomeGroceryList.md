## User Interface
Clerk will be able to see the product information on a certain order. They will have the ability to update the pickerID, the Picked Qty, and Pick Issue.
![Mockup](./GroceryListOrderPicking.svg)

## Events and Interactions
![Plan](./GroceryListOrderPickingPlan.svg)
- ![](1.svg)**Page_Load** event
    - ![](a.svg) - Load the list of Pickers from the BLL
    - **`List<PickerSelection>OrderPickingController.ListPickers()`**
- ![](2.svg) **LookUpOrder** click event - Order Details will be listed based on OrderID entered.
    - ![](b.svg) - Load the OrderCustomer information
    - **`OrderPickingController.FindCustomer(OrderID)`**
    - ![](c.svg) - Load the PickedItems ListView
    - `<EditItemTemplate>` will display the OrderListItems. User will be able to edit the PickedQty and Pick Issue field.
    - **`List<OrderListItems>OrderPickingController.LoadOrder(OrderID)`**    
- ![](3.svg) **UpdateOrder** click
    - ![](d.svg) Use the custom command of "PickOrder" and handle the ListView's `ItemCommand` event.
    - If the cancel button is selected, the editable fields will be reverted to blank.
    - Gather the information from the form of the picked items. The "PickOrder" in the BLL will handle the processing:
    ```csharp
    void OrderPickingController.PickOrder(int orderID, OrderPicker picker, List<PickedItems> items)
    ```


## POCOs/DTOs

### Commands
```csharp
public class PickedItems
{
    public int ProductID {get;set;}
    public short QtyPicked{get;set;}
    public string PickIssue{get;set;}
    
}
public class OrderPicker
{
    public int PickerID {get;set;}
    public DateTime? PickedDate {get;set;}
}
```
### Queries
```csharp
public class PickerSelection
{
    public int PickerID {get;set;}
    public string PickerName 
    {
        get
        {
            string result = $"{FirstName} {LastName}"

            return result;
        }
    }
}
```
```csharp
public class OrderCustomer
{
    public int CustomerID {get;set;}
    public string CustomerName 
    {
        get
        {
            string result = $"{FirstName} {LastName}"

            return result;
        }
    }
    public string Phone {get;set;}
}
```

```csharp
public class OrderProducts
{
    public int ProductID {get;set;}
    public string Description {get;set;}
}
```

```csharp
public class OrderListItems
{
    public int OrderListID {get;set;}
    public int OrderID {get;set;}
    public IEnumerable<OrderProducts> OrderItems {get;set;}
    public short OrderedQty {get;set;}
    public string CustomerComments {get;set;}
    public short PickedQty {get;set;}
    public string PickIssue {get;set;}
}
```
## BLL Processing
All order picking will be handled by the OrderPickingController.
- **`List<PickerSelection>OrderPickingController.ListPickers()`**
    - Get all the pickers from the DB.
- **`OrderPickingController.FindCustomer(OrderID)`**
    - Will return the `OrderCustomer` information based on the customerId attributed to the OrderId.
    - Will ensure OrderId exists || throw exception
- **`List<OrderListItems>OrderPickingController.LoadOrder(OrderID)`** 
    - Will list all of the `OrderListItems` based on the OrderID. 
    - Will ensure OrderId exists || throw exception
- 
- **`void OrderPickingController.PickOrder(int orderID, OrderPicker picker, List<PickedItems> items)`**
    - ### Validation
        - OrderID must be valid
        - PickedQty cannot be greater than OrderedQty.
        - Picker must be selected ** is a nullable field, however, the whole basis for this page is that the items have been picked.
    - ### Processing
        - OrderList updated to reflect the QtyPicked and Pick Issue if applicable.
        - Update PickerId and PickedDate in Orders to reflect changes.