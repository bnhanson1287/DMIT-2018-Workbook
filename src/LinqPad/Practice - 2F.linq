<Query Kind="Expression">
  <Connection>
    <ID>ad5c237c-d0e0-4642-bd26-cdd8f1863069</ID>
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
	select data.CompanyName


}