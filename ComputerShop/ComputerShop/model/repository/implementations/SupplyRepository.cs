using ComputerShop.model.database;

namespace ComputerShop.model.repository.implementations
{
	public class SupplyRepository : AbstractRepository<Supply>
	{
		public SupplyRepository() : base() { }
		public SupplyRepository(ComputerShopContext context) : base(context) { }
	}
}
