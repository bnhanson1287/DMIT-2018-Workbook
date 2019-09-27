<Query Kind="Expression">
  <Connection>
    <ID>6edf624f-c0cc-49a2-a8cb-62de5ccf03e1</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// Display all the company names and contact names for our customers, grouped by country


from row in Customers
//   Customer Table<Customers>
group  row   by   row.Address.Country 
	   //cUSTOMER     //[  String   ]
//    \what/      \       how       /
//                 \      KEY      /
into CustomersByCountry
// IGrouping<string, Customer>
select new
{
   Country = CustomersByCountry.Key, // the key is "how" we have sorted the data
   Customers = from data in CustomersByCountry
               select new
               {
			       Company = data.CompanyName,
				   Contact = data.ContactName
               }
}