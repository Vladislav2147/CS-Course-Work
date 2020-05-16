using ComputerShop.model.database;
using ComputerShop.model.service.implementations;
using ComputerShop.view.adminTools;
using ComputerShop.view.products;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Keyboard = ComputerShop.model.database.Keyboard;
using Mouse = ComputerShop.model.database.Mouse;

namespace ComputerShop.viewmodel.adminTools
{
	class CreateSupplyViewModel
	{
		public SupplyService SupplyService { get; set; }
		public CreateSupplyWindow CodeBehind { get; set; }
		public Supply CreatedSupply { get; set; }
		public ObservableCollection<DeliveredToWareHouse> Delivered { get; set; }
		public ICommand CreateProduct { get; set; }
		public object ProductType { get; set; }

		public CreateSupplyViewModel(SupplyService supplyService, CreateSupplyWindow codeBehind)
		{
			codeBehind.DataContext = this;
			SupplyService = supplyService;
			CodeBehind = codeBehind;

			CreatedSupply = new Supply();
			Delivered = new ObservableCollection<DeliveredToWareHouse>();
			CreateProduct = new RelayCommand(param => ExecuteCreateProduct());
		}

		private void ExecuteCreateProduct()
		{
			string type = (ProductType as ComboBoxItem).Content.ToString();
			ProductWindow productWindow = new ProductWindow();
			switch (type)
			{
				case "Настольный пк":
					productWindow = new ProductWindow(new Desktop(), new DesktopUC(), false);
					break;
				case "Ноутбук":
					productWindow = new ProductWindow(new Laptop(), new LaptopUC(), false);
					break;
				case "Моноблок":
					productWindow = new ProductWindow(new Monoblock(), new MonoblockUC(), false);
					break;
				case "Клавиатура":
					productWindow = new ProductWindow(new Keyboard(), new KeyboardUC(), false);
					break;
				case "Мышь":
					productWindow = new ProductWindow(new Mouse(), new MouseUC(), false);
					break;
			}

			productWindow.Show();

		}
	}
}
