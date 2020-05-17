using ComputerShop.model.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.model.repository.implementations
{
	public class ProductRepository : AbstractRepository<Product>
	{
		public ProductRepository() : base() { }
		public ProductRepository(ComputerShopContext context) : base(context) { } 
	}
}
