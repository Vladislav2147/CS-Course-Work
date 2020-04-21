using ComputerShop.model.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.model.service.implementations
{
	class OrderService : AbstractService<Order>
	{
		public OrderService() : base() { }
		public OrderService(ComputerShopContext context) : base(context) { }
	}
}
