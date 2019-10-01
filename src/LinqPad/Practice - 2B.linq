<Query Kind="Expression">
  <Connection>
    <ID>015bb1b6-039b-486e-9f5a-c865bba61021</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// B) List all the Customers by Company Name. Include the Customer's company name, contact name, and other contact information in the result.
from person in Customers
group person by person.CompanyName into CompanyGroup
select new
{
	CompanyName = CompanyGroup.Key,
	Contact = from contact in CompanyGroup
	select new
	{
		Name = contact.ContactName,
		Email = contact.ContactEmail,
		Phone = contact.Phone,
		Fax = contact.Fax
	}

}
