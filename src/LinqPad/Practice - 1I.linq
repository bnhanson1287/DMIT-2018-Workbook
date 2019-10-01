<Query Kind="Expression">
  <Connection>
    <ID>015bb1b6-039b-486e-9f5a-c865bba61021</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

//I) List the company names of all Suppliers in North America (Canada, USA, Mexico)
from company in Suppliers
where company.Address.Country.Equals("Canada") || company.Address.Country.Equals("USA") || company.Address.Country.Equals("Mexico")
select new 
{
	NorthAmericanCompanies = company.CompanyName
}