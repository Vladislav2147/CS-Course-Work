using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.model.database
{
	public partial class ComputerShopContext
	{
		public DbSet GetEntity<T>() where T : IEntity, new()
		{
			T entity = new T();
			switch (entity) 
			{
				case Customer _:
					return Customer;
				case DeliveredToWareHouse _:
					return DeliveredToWareHouse;
				case Order _:
					return Order;
				case Ordered _:
					return Ordered;
				case Product _:
					return Product;
				case Supply _:
					return Supply;
			}
			return default;
		}
	}
}
