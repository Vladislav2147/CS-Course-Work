using ComputerShop.model.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.model.service.implementations
{
	public class ProductService : AbstractService<Product>
	{
		public ProductService() : base() { }
		public ProductService(ComputerShopContext context) : base(context) { } 
	}
}
