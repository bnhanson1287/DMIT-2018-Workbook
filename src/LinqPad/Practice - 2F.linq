<Query Kind="Expression">
  <Connection>
    <ID>015bb1b6-039b-486e-9f5a-c865bba61021</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// F) List all the Suppliers, by Country

from supplier in Suppliers

group supplier by  supplier.Address.Country into SupplierGroups
select new
{
	Country = SupplierGroups.Key,
	Supplier = from data in SupplierGroups
	select new
	{
	
		SupplierName = data.CompanyName
	}


}

