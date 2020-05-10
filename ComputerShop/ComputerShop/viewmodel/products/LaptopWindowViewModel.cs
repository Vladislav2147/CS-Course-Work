using ComputerShop.model.database;
using ComputerShop.view.products;

namespace ComputerShop.viewmodel.products
{
	class LaptopWindowViewModel : ProductWindowViewModel<Laptop>
	{
		public LaptopWindowViewModel(LaptopWindow codeBehind) : base(codeBehind)
		{
			Product = new Laptop();
		}
	}
}
