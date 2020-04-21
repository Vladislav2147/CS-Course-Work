using ComputerShop.model.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.model.service.implementations
{
	class CustomerService : AbstractService<Customer>
	{
		public CustomerService() : base() { }
		public CustomerService(ComputerShopContext context) : base(context) { }
	}
}
