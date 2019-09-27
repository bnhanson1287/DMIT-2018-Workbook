<Query Kind="Program">
  <Connection>
    <ID>6edf624f-c0cc-49a2-a8cb-62de5ccf03e1</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

void Main()
{
	// Aggregates and Linq Extension Methods
	    // In addition to the query syntax approach to Linq,
	    // we can use method syntax to achieve the same results.
	    // Method syntax also provides us with capabilities
	    // that go beyond what is possible in Query syntax.
	    
	    // .Count()
	    var categoryCount = Categories.Count(); // count up all the categories
	    categoryCount.Dump("Total number of categories");
	    var productCount = Products.Count();
	    productCount.Dump("Total number of products");
	    // The .Count() method can also take a "filter" expression
	    productCount = Products.Count(item => item.ProductName.Contains("Chef"));
	    productCount.Dump("Number of products with Chef in the name");
	    // A "Lambda Expression" is one that acts as an "ad-hoc" method is passed
	    // into the .Count() method.
	    // .Count(item => item.ProductName.Contains("Chef"))
	    // can be read as "Count each item such that (=>) I only include items where
	    // the product name contains the text 'Chef'".
	    
	    // .Sum(), .Average(), .Max(), .Min()
	    var orderTotals = from details in OrderDetails
	                      // Calculate the line-item total, less the discount
	                      select details.UnitPrice * details.Quantity
	                           - (details.UnitPrice * (decimal)details.Discount * details.Quantity);
	    orderTotals.Dump("Line-item totals in Order Details");
	    var grandTotal = orderTotals.Sum();
	    grandTotal.Dump("Total sales to-date");
	    var result = orderTotals.Average();
	    result.Dump("The average line-item amount");
	    result = orderTotals.Max(); 
	    result.Dump("The largest line-item total");
	    result = orderTotals.Min();
	    result.Dump("The smallest line-item total");
}

// Define other methods and classes here
