<Query Kind="Expression" />

//F) List all the region and territory names as an "object graph"
//   - use a nested query
from data in Regions
select new
{
    Region = data.RegionDescription,
    Terrtiories = from item in data.Territories
               select item.TerritoryDescription
}