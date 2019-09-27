<Query Kind="Expression">
  <Connection>
    <ID>6edf624f-c0cc-49a2-a8cb-62de5ccf03e1</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// Display the Employees, grouped by the region in which the employee lives. Show the employee's first name, last name, and job title as separate properties within each group.
from person in Employees
//   Employee  Table<Employee>
group person by person.Address.Region into EmployeeGroups
//    Employee  [    string        ]       IGrouping<string,employee>
select new
{
    Region = EmployeeGroups.Key,
	Employee = from staff in EmployeeGroups
	           select new
               {
			       FirstName = staff.FirstName,
				   LastName = staff.LastName,
				   JobTitle = staff.JobTitle
               }
}