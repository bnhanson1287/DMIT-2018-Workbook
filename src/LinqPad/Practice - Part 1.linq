<Query Kind="Expression">
  <Connection>
    <ID>05901ad4-c977-4990-b339-4a4e9112438a</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// Practice questions - do each one in a separate LinqPad query.
/*













*/

//A) List all the customer company names for those with more than 5 orders.
from company in Customers
where company.Orders.Count > 5
select company.CompanyName

//B) Get a list of all the region names
from region in Regions
select new 
{
	RegionList = region.RegionDescription
}

//C) Get a list of all the territory names
from territory in Territories
select new
{
	TerritoryList =territory.TerritoryDescription
}
//D) List all the regions and the number of territories in each region
from region in Regions
select new
{
	Regions = region.RegionDescription,
	NumberOfTerritories = region.Territories.Count
}
//E) List all the region and territory names in a "flat" list
from territory in Territories
select new
{
	Region = territory.Region.RegionDescription,
	Territories = territory.TerritoryDescription
}
//F) List all the region and territory names as an "object graph"
//   - use a nested query
from data in Regions
select new
{
    Region = data.RegionDescription,
    Terrtiories = from item in data.Territories
               select item.TerritoryDescription
}
//G) List all the product names that contain the word "chef" in the name.
from item in Products
where item.ProductName.Contains("chef")
select item.ProductName

//H) List all the discontinued products, specifying the product name and unit price.
from item in Products 
where item.Discontinued.Equals(true)
select new
{
	Product = item.ProductName,
	Price = item.UnitPrice
}
//I) List the company names of all Suppliers in North America (Canada, USA, Mexico)
from company in Suppliers
where company.Address. 

