using ComputerShop.model.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.model.repository.implementations
{
	public class OrderedRepository : AbstractRepository<Ordered>
	{
		public OrderedRepository() : base() { }
		public OrderedRepository(ComputerShopContext context) : base(context) { }
	}
}
