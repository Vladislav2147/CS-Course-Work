using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseWorkClasses.Products;

namespace CourseWorkClasses
{
	class WareHouse
	{
		public List<Product> Products { get; }

		public WareHouse()
		{
			Products = new List<Product>();
		}
		public Product GetProductById(int id)
		{
			foreach(Product product in Products)
			{
				if(product.Id == id)
				{
					return product;
				}
			}
			return null;
		}
		public void AddProduct(Product product)
		{
			if(GetProductById(product.Id) == null)
			{
				Products.Add(product);
			}
			else
			{
				throw new ProductAlreadyExistsException($"Product");
			}
		}

		//public void 
	}
}
