using ComputerShop.model.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.model.repository.implementations
{
	public class OrderRepository : AbstractRepository<Order>
	{
		public OrderRepository() : base() { }
		public OrderRepository(ComputerShopContext context) : base(context) { }
	}
}
