<Query Kind="Statements">
  <Connection>
    <ID>6edf624f-c0cc-49a2-a8cb-62de5ccf03e1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

//Orders.Max(sale => sale.OrderDate).Value.Month

from sale in Orders 
where sale.OrderDate.Value.Month == 5 
	&& sale.OrderDate.Value.Year == 2018
select new
{

	Customer = sale.Customer.CompanyName,
	ResponseTime = sale.RequiredDate.Value - sale.OrderDate.Value,
	PaymentDueOn = sale.PaymentDueDate,
	FirstPayment = sale.Payments.First().PaymentDate,
	PaymentResponseTime = sale.Payments.First().PaymentDate - sale.PaymentDueDate.Value


}

