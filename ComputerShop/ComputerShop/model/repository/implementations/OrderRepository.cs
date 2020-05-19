using ComputerShop.model.database;

namespace ComputerShop.model.repository.implementations
{
	public class OrderRepository : AbstractRepository<Order>
	{
		public OrderRepository() : base() { }
		public OrderRepository(ComputerShopContext context) : base(context) { }
	}
}
