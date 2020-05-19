using ComputerShop.model.database;

namespace ComputerShop.model.repository.implementations
{
	public class DeliveredToWareHouseRepository : AbstractRepository<DeliveredToWareHouse>
	{
		public DeliveredToWareHouseRepository() : base() { }
		public DeliveredToWareHouseRepository(ComputerShopContext context) : base(context) { }
	}
}
