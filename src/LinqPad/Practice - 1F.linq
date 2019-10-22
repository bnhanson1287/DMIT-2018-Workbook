<Query Kind="Expression">
  <Connection>
    <ID>ad5c237c-d0e0-4642-bd26-cdd8f1863069</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

//F) List all the region and territory names as an "object graph"
//   - use a nested query
from data in Regions
select new
{
    Region = data.RegionDescription,
    Terrtiories = from item in data.Territories
               select item.TerritoryDescription
}