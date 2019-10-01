<Query Kind="Expression">
  <Connection>
    <ID>015bb1b6-039b-486e-9f5a-c865bba61021</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

//C) Get a list of all the territory names
from territory in Territories
select new
{
	TerritoryList =territory.TerritoryDescription
}