using ComputerShop.model.database;
using ComputerShop.view.products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.viewmodel.products
{
	class DesktopWindowViewModel : ProductWindowViewModel<Desktop>
	{
		public DesktopWindowViewModel(DesktopWindow codeBehind) : base(codeBehind) 
		{
			Product = new Desktop();
		}
	}
}
