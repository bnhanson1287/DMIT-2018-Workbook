<Query Kind="Expression">
  <Connection>
    <ID>6edf624f-c0cc-49a2-a8cb-62de5ccf03e1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

from cat in Categories
select new //ProductCategory
{
 	CategoryName = cat.CategoryName,
	Description = cat.Description,
 	Picture = cat.Picture.ToImage(), //remove .ToImage() for vs2019
 	MimeType = cat.PictureMimeType,
 	Products = from item in cat.Products
            select new //ProductSummary
            {
                Name = item.ProductName,
                Price = item.UnitPrice,
                Quantity = item.QuantityPerUnit
            }
}