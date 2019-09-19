<Query Kind="Expression">
  <Connection>
    <ID>6edf624f-c0cc-49a2-a8cb-62de5ccf03e1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// - Filter on partial name
// List employees who have an "an" in their first name
from person in Employees
where person.FirstName.Contains("an")
select person