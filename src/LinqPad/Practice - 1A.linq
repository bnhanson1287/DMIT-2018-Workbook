<Query Kind="Expression">
  <Connection>
    <ID>015bb1b6-039b-486e-9f5a-c865bba61021</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

//A) List all the customer company names for those with more than 5 orders.
from company in Customers
where company.Orders.Count > 5
select company.CompanyName