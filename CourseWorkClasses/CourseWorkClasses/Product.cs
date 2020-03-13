using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkClasses
{
	class Product
	{
		public string Title { get; set; }
		public int Id { get; set; }
		public decimal Price { get; set; }
		public int Amount { get; set; }
		public ProductType Type { get; set; }
		public string JSONtable { get; set; }
		public byte[][] Photos { get; set; }

		public Product(string title, int id, decimal price, int amount, ProductType type, string jSONtable, byte[][] photos)
		{
			Title = title;
			Id = id;
			Price = price;
			Amount = amount;
			Type = type;
			JSONtable = jSONtable;
			Photos = photos;
		}

		public Product()
		{
		}

	}
}
