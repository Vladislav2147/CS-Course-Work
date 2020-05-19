using ComputerShop.model.database;

namespace ComputerShop.model.repository.implementations
{
	public class ProductRepository : AbstractRepository<Product>
	{
		public ProductRepository() : base() { }
		public ProductRepository(ComputerShopContext context) : base(context) { }
	}
}
