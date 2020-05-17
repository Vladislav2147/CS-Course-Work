using ComputerShop.model.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.model.repository.implementations
{
	public class DeliveredToWareHouseRepository : AbstractRepository<DeliveredToWareHouse>
	{
		public DeliveredToWareHouseRepository() : base() { }
		public DeliveredToWareHouseRepository(ComputerShopContext context) : base(context) { }
	}
}
