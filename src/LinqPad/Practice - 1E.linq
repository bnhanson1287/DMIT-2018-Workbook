<Query Kind="Expression">
  <Connection>
    <ID>015bb1b6-039b-486e-9f5a-c865bba61021</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

//E) List all the region and territory names in a "flat" list
from territory in Territories
select new
{
	Region = territory.Region.RegionDescription,
	Territories = territory.TerritoryDescription
}