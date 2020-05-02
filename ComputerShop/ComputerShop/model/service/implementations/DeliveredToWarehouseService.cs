﻿using ComputerShop.model.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.model.service.implementations
{
	class DeliveredToWareHouseService : AbstractService<DeliveredToWareHouse>
	{
		public DeliveredToWareHouseService() : base() { }
		public DeliveredToWareHouseService(ComputerShopContext context) : base(context) { }
	}
}