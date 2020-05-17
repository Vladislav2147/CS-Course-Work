using ComputerShop.model.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.model.repository.implementations
{
	public class SupplyRepository : AbstractRepository<Supply>
	{
		public SupplyRepository() : base() { }
		public SupplyRepository(ComputerShopContext context) : base(context) { }
	}
}
