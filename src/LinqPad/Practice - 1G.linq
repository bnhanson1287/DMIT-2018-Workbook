<Query Kind="Expression">
  <Connection>
    <ID>015bb1b6-039b-486e-9f5a-c865bba61021</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

from item in Products
where item.ProductName.Contains("chef")
select item.ProductName
