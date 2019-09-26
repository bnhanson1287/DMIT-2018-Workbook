<Query Kind="Expression">
  <Connection>
    <ID>6edf624f-c0cc-49a2-a8cb-62de5ccf03e1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// List all the employees who do not manage anyone.
from person in Employees
//   Employee  Table<Employee> 
where person.ReportsToChildren.Count == 0
//    Employee  IEnumerable<Employee>
select new// Anonymus DataType
{
  Name = person.FirstName + " " + person.LastName,
  Manager = person.ReportsToEmployee.FirstName+ " " +person.ReportsToEmployee.LastName
}