using ComputerShop.model.database;
using ComputerShop.view.products;

namespace ComputerShop.viewmodel.products
{
	class DesktopWindowViewModel : ProductWindowViewModel<Desktop>
	{
		public DesktopWindowViewModel(DesktopWindow codeBehind) : base(codeBehind) 
		{
			Product = new Desktop() { Type = model.enums.ComputerType.Home };
		}
	}
}
