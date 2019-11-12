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
	var output = ShipperList();
	output.Dump();
}

public List<ShipperSelection> ShipperList()
{
    //throw new NotImplementedException();
    //Get all the shippers from the Db
	var result = from shipper in Shippers
	orderby shipper.CompanyName
	select new ShipperSelection
	{
		ShipperId = shipper.ShipperID,
		Shipper = shipper.CompanyName
	
	};
	return result.ToList();
}
		
		public class ShipperSelection
    {
        public int ShipperId { get; set; }
        public string Shipper { get; set; }
    }