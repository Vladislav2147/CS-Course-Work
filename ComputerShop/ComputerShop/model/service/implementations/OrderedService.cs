using ComputerShop.model.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.model.service.implementations
{
	public class OrderedService : AbstractService<Ordered>
	{
		public OrderedService() : base() { }
		public OrderedService(ComputerShopContext context) : base(context) { }
	}
}
