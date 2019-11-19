using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Admin.Security;
using WestWindSystem.BLL;
using WestWindSystem.DataModels;

namespace WebApp.Sales
{
    public partial class OrderShipping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Request.IsAuthenticated || !User.IsInRole(Settings.SupplierRole))
            {
                Response.Redirect("~", true);
            }
            if(!IsPostBack)
            {
                //Load up the info on the supplier.
                //TODO: Replace hard-coded supplierID with the user's supplier ID
                SupplierInfo.Text = "Temp supplier: ID 8";
            }
        }

        protected void CurrentOrders_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Ship")
            {
                // Gather information from the form to send to the BLL for shipping.
                // - ShipOrder(int ordeID, ShippingDirections shipping, List<ShippedItem> items)
                int orderId = 0;
                Label ordIDLabel = e.Item.FindControl("OrderIdLabel") as Label; // safe cast the Control object as a label object
                if (ordIDLabel != null)
                {
                    orderId = int.Parse(ordIDLabel.Text);
                }
                ShippingDirections shipInfo = new ShippingDirections();
                DropDownList shipViaDropDown = e.Item.FindControl("ShipperDropDown") as DropDownList;

                if(shipViaDropDown != null)// if i got the control... not validation
                {
                    shipInfo.ShipperId = int.Parse(shipViaDropDown.SelectedValue);
                }

                // tracking code
                TextBox trackingCodeTextBox = e.Item.FindControl("TrackingCode") as TextBox;

                if(trackingCodeTextBox != null)
                {
                    shipInfo.TrackingCode = trackingCodeTextBox.Text;
                }
                // freight charge
                decimal price;
                TextBox freightChargeTextBox = e.Item.FindControl("FreightCharge") as TextBox;
                if(freightChargeTextBox != null && decimal.TryParse(freightChargeTextBox.Text, out price))
                {
                    shipInfo.FreightCharge = price;
                }

                List<ShippedItem> goods = new List<ShippedItem>();
                GridView gv = e.Item.FindControl("ProductGridView") as GridView;
                if (gv != null)
                {
                    foreach (GridViewRow row in gv.Rows)
                    {
                        // get product id and ship qty
                        short quantity;
                        HiddenField prodId = row.FindControl("ProductId") as HiddenField;
                        TextBox qty = row.FindControl("ShipQuantity") as TextBox;

                        if (prodId != null && qty != null && short.TryParse(qty.Text, out quantity))
                        {
                            ShippedItem item = new ShippedItem
                            {
                                Product = prodId.Value,
                                Quantity = quantity
                            };
                            goods.Add(item);
                        }
                    }
                }

                var controller = new OrderProcessingController();
                controller.ShipOrder(orderId, shipInfo, goods);
            }
            
        }
    }
}