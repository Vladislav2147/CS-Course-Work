using ComputerShop.model.database;

namespace ComputerShop.model.repository.implementations
{
	public class OrderedRepository : AbstractRepository<Ordered>
	{
		public OrderedRepository() : base() { }
		public OrderedRepository(ComputerShopContext context) : base(context) { }
	}
}
