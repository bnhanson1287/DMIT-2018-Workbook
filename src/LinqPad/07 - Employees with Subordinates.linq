<Query Kind="Expression">
  <Connection>
    <ID>6edf624f-c0cc-49a2-a8cb-62de5ccf03e1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// List all the employees who are managers.
from person in Employees
//   thing      thing[] 
where person.ReportsToChildren.Count > 0
//     thing    thing[]
select new
{
  Name = person.FirstName + " " + person.LastName,
  Subordinates = from sub in person.ReportsToChildren
  	select sub.FirstName+ " " +sub.LastName
}