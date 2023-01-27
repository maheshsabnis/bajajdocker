using System;
namespace ProductService.Models
{
	public class ProductsDB : List<Product>
	{
		public ProductsDB()
		{
			Add(new Product() { ProductId = 101, ProductName = "Laptop" });
            Add(new Product() { ProductId = 102, ProductName = "Mobile" });
            Add(new Product() { ProductId = 103, ProductName = "HDD" });
            Add(new Product() { ProductId = 104, ProductName = "RAM" });
            Add(new Product() { ProductId = 105, ProductName = "CPU" });
        }
		 
	}
}

