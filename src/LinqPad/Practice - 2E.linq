<Query Kind="Expression">
  <Connection>
    <ID>015bb1b6-039b-486e-9f5a-c865bba61021</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// E) Group all customers by city. Output the city name, aalong with the company name, contact name and title, and the phone number.
from company in Customers

group company by company.Address.City into CompanyGroups

select new
{
    City = CompanyGroups.Key,
	Customer = from customer in CompanyGroups
	           select new
               {
			       CompanyName = customer.CompanyName,
				   ContactName = customer.ContactName,
				   ContactTitle = customer.ContactTitle,
				   Phone = customer.Phone
               }
}