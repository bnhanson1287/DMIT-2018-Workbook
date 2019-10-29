using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var shipInfo = new ShippingDirections();
            ShipOrder(5,shipInfo,null);
        }
        /// <summary>
        /// Process the order shipment
        /// </summary>
        /// <param name="orderId">The ID of the order being shipped</param>
        /// <param name="shipping"> The <see cref="ShippingDirections"/> of the items being shipped.</param>
        /// <param name="items"></param>
        static void ShipOrder(int orderId, ShippingDirections shipping, List<ShippedItem> items)
        {

        }


    }
    /// <summary>
    /// Represents information about the shipper and tracking/freight details for shipping an order
    /// </summary>
    public class ShippingDirections
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int ShipperId { get; set; }
        public string TrackingCode { get; set; }
        public decimal? FreightCharge { get; set; }
    }
    public class ShippedItem
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int ProductId { get; set; }
        public int ShipQuantity { get; set; }
    }
}
