<Query Kind="Expression">
  <Connection>
    <ID>6edf624f-c0cc-49a2-a8cb-62de5ccf03e1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// List all the employees who do not have a manager
// (i.e.: they do not report to anyone).
from person in Employees
//   Employee  Table<Employees>
where person.ReportsToEmployee == null
//    Employee  Employee
select new // Creating an Anonymus data type
// The curly braces section below is called the Initializer List
{
  Name = person.FirstName + " " + person.LastName
}