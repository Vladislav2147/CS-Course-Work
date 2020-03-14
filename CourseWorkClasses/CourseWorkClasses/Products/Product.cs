using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkClasses.Products
{
	abstract class Product
	{
		int year;
		public string Title { get; set; }
		public int Id { get; set; }
		public decimal Price { get; set; }
		public int Amount { get; set; }
		public int Year
		{
			get
			{
				return year;
			}
			set 
			{
				if (year > 1970 && year < DateTime.Now.Year)
				{
					year = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException("Invalid year");
				}
			}
		}

		public string[] Photos { get; set; }

		public Product()
		{

		}

	}
}
