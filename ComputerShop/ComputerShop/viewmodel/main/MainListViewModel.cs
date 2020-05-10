using ComputerShop.model.database;
using ComputerShop.model.statics;
using ComputerShop.view;
using ComputerShop.view.products;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Keyboard = ComputerShop.model.database.Keyboard;
using Mouse = ComputerShop.model.database.Mouse;

namespace ComputerShop.viewmodel.main
{
	class MainListViewModel
	{
		public MainWindowViewModel MainVM { get; set; }
		public MainList CodeBehind { get; set; }
		public ICommand AddToCart { get; set; }
		public ICommand Remove { get; set; }
		public ICommand Create { get; set; }
		public object ProductType { get; set; }

		public MainListViewModel(MainList codeBehind)
		{
			CodeBehind = codeBehind;
			AddToCart = new RelayCommand(param => ExecuteAddToCart(param));
			Remove = new RelayCommand(param => ExecuteRemove());
			Create = new RelayCommand(param => ExecuteCreate());
			MainVM = CodeBehind.Owner.DataContext as MainWindowViewModel;
			if(MainVM.Customer.Role == model.enums.Role.User)
			{
				CodeBehind.AdminTools.Visibility = Visibility.Collapsed;
			}
		}

		private void ExecuteAddToCart(object sender)
		{
			Button button = sender as Button;
			Product product = (Product)button.DataContext;
			Ordered ordered = new Ordered() { Product = product, Amount = 1 };
			Order order = MainVM.GetCreatedOrder();
			if(order == null)
			{
				order = new Order() { Customer = MainVM.Customer, State = State.Created };
			}
			order.Ordered.Add(ordered);
			button.Content = "В корзине";
			button.IsEnabled = false;
		}

		private void ExecuteRemove()
		{
			Product product = CodeBehind.ProductList.SelectedItem as Product;
			MainVM.ProductService.RemoveById(product.Id);
			MainVM.ProductService.SaveChanges();
			MainVM.UpdateMainList(MainVM.GetListOfCurrentType(MainVM.ProductService.GetAll()));
		}

		private void ExecuteCreate()
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

		public void UpdateButtons()
		{
			Order order = MainVM.Customer.Order.FirstOrDefault(ord => ord.State == State.Created);

			if(order != null)
			{
				foreach (Button button in ChildFinder.FindVisualChildren<Button>(CodeBehind.ProductList))
				{
					if (order.Ordered.FirstOrDefault(ord => ord.Product == (Product)button.DataContext) != null && MainVM.Customer.Role == model.enums.Role.User)
					{
						button.IsEnabled = false;
						button.Content = "В корзине";
					}
					else if (((Product)button.DataContext).Amount == 0)
					{
						button.IsEnabled = false;
						button.Content = "Нет на складе";
					}
					else
					{
						button.IsEnabled = true;
						button.Content = "В корзину";
					}
				}
			}
		}

		public void ShowProduct(object sender)
		{
			Product product = (sender as ListBox).SelectedItem as Product;
			IProductUC productUC = null;
			switch (product)
			{
				case Desktop _:
					productUC = new DesktopUC();
					break;
				case Keyboard _:
					productUC = new KeyboardUC();
					break;
				case Laptop _:
					productUC = new LaptopUC();
					break;
				case Monoblock _:
					productUC = new MonoblockUC();
					break;
				case Mouse _:
					productUC = new MouseUC();
					break;

			}

			ProductWindow productWindow = new ProductWindow(product, productUC, MainVM.Customer.Role == model.enums.Role.User);
			productWindow.Owner = CodeBehind.Owner;
			productWindow.Show();
		}
		
	}
}
