<Query Kind="Expression">
  <Connection>
    <ID>ad5c237c-d0e0-4642-bd26-cdd8f1863069</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// B) List all the Customers by Company Name. Include the Customer's company name, contact name, and other contact information in the result.
from person in Customers
orderby person.CompanyName
select new
{
	CompanyName = person.CompanyName,
	Contact = new
	{
		Name = person.ContactName,
		Title = person.ContactTitle,
		Email = person.ContactEmail,
		Phone = person.Phone,
		Fax = person.Fax
	}
}

