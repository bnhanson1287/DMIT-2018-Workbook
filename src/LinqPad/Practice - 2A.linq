<Query Kind="Expression">
  <Connection>
    <ID>ad5c237c-d0e0-4642-bd26-cdd8f1863069</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// A) Group employees by region and show the results in this format:
/* ----------------------------------------------
 * | REGION        | EMPLOYEES                  |
 * ----------------------------------------------
 * | Eastern       | ------------------------   |
 * |               | | Nancy Devalio        |   |
 * |               | | Fred Flintstone      |   |
 * |               | | Bill Murray          |   |
 * |               | ------------------------   |
 * |---------------|----------------------------|
 * | ...           |                            |
 * 
 */
 from place in Regions
 select new
 {
 	Region = place.RegionDescription,
	Employees = from area in place.Territories
	from manager in area.EmployeeTerritories
	group manager by manager.Employee into areaManagers
	select areaManagers.Key.FirstName+" "+areaManagers.Key.LastName
 }