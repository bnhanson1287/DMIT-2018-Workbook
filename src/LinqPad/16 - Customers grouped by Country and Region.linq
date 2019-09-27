<Query Kind="Expression">
  <Connection>
    <ID>6edf624f-c0cc-49a2-a8cb-62de5ccf03e1</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// List all the customers grouped by country and region.
from row in Customers
group row by new { row.Address.Country, row.Address.Region } into CustomerGroups
//				  \      key is an anonymus type          /
select new
{
   Key = CustomerGroups.Key,
   Country = CustomerGroups.Key.Country,
   Region = CustomerGroups.Key.Region,
   Customers = from data in CustomerGroups
               select new
               {
                   Company = data.CompanyName,
                   City = data.Address.City
               }
}