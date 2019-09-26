<Query Kind="Expression">
  <Connection>
    <ID>6edf624f-c0cc-49a2-a8cb-62de5ccf03e1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

from data in Suppliers
select new //SupplierProduct
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