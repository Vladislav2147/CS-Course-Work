using ComputerShop.model.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.model.service.implementations
{
	class SupplyService : AbstractService<Supply>
	{
		public SupplyService() : base() { }
		public SupplyService(ComputerShopContext context) : base(context) { }
	}
}
