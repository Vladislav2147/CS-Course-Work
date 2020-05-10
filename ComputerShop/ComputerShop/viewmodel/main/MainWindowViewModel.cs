using ComputerShop.model.database;
using ComputerShop.model.enums;
using ComputerShop.model.service.implementations;
using ComputerShop.model.statics;
using ComputerShop.view;
using ComputerShop.view.main.filters;
using ComputerShop.view.shoppingcart;
using ComputerShop.viewmodel.cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ComputerShop.viewmodel.main
{
	class MainWindowViewModel
	{
		public MainList ListState { get; set; }
		public MainWindow CodeBehind { get; set; }
		public ProductService ProductService { get; set; }
		public Customer Customer { get; set; }
		public Type CurrentProductType { get; set; } 
		public ICommand GoToCart { get; set; }
		public ICommand Filter { get; set; }
		public ICommand FindByName { get; set; }
		public ICommand Cancel { get; set; }

		public MainWindowViewModel(MainWindow codeBehind, Customer customer)
		{
			Customer = customer;
			CodeBehind = codeBehind;
			ProductService = new ProductService();
			GoToCart = new RelayCommand(param => ExecuteGoToCart());
			Filter = new RelayCommand(param => FilterProducts());
			FindByName = new RelayCommand(param => FindByNameExecute());
			Cancel = new RelayCommand(param => CancelExecute());
			CurrentProductType = typeof(Product);
			if (GetCreatedOrder() == null)
			{
				Customer.Order.Add(new Order() { State = State.Created, Customer = this.Customer });
			}
			
		}

		private void ExecuteGoToCart()
		{
			ShoppingCart view = new ShoppingCart(CodeBehind);
			ShoppingCartViewModel vm = new ShoppingCartViewModel(Customer, view);
			view.DataContext = vm;
			CodeBehind.MainContent.Content = view;
		}

		public void TreeItemExecute()
		{
			List<Product> products = ProductService.GetAll();
			products = GetListOfCurrentType(products);
			CurrentProductType = TypeOfList(products);

			if(CurrentProductType == typeof(Product))
			{
				CodeBehind.FiltersContent.Content = null;
			}
			if (Activator.CreateInstance(CurrentProductType) as Computer != null)
			{
				CodeBehind.FiltersContent.Content = new ComputerFilters();
			}
			if (Activator.CreateInstance(CurrentProductType) as Peripherals != null)
			{
				CodeBehind.FiltersContent.Content = new PeripheralFilters();
			}

			UpdateMainList(products);			
		}

		public void UpdateMainList(List<Product> products)
		{
			MainList view = new MainList(this.CodeBehind);
			view.ProductList.ItemsSource = products;
			MainListViewModel vm = new MainListViewModel(view);
			vm.MainVM = this.CodeBehind.DataContext as MainWindowViewModel;
			view.DataContext = vm;
			CodeBehind.MainContent.Content = view;
		}

		public Order GetCreatedOrder()
		{
			return Customer.Order.FirstOrDefault(order => order.State == State.Created);
		}

		private void FilterProducts()
		{

			List<Product> products = ProductService
				.GetAll()
				.Where(product => product.GetType().IsSubclassOf(CurrentProductType)).ToList();


			decimal beginPrice = Decimal.Zero, endPrice = Decimal.MaxValue;

			if (Decimal.TryParse(CodeBehind.BeginPrice.Text, out beginPrice) || Decimal.TryParse(CodeBehind.EndPrice.Text, out endPrice))
			{
				products = products.Where(product => product.Price >= beginPrice && product.Price <= endPrice).ToList();
			}


			int beginYear = DateTime.Now.Year - 20, endYear = DateTime.Now.Year;
			
			if (Int32.TryParse(CodeBehind.BeginYear.Text, out beginYear) || Int32.TryParse(CodeBehind.EndYear.Text, out endYear))
			{
				products = products.Where(product => product.Year >= beginYear && product.Year <= endYear).ToList();
			}

			if (CodeBehind.IsInWarehouse.IsChecked.Value)
			{
				products = products.Where(product => product.Amount != 0).ToList();
			}

			
			if (Activator.CreateInstance(CurrentProductType) as Computer != null)
			{
				ComputerFilters filters = CodeBehind.FiltersContent.Content as ComputerFilters;


				int minCores = 0, maxCores = Int32.MaxValue;

				if (Int32.TryParse(filters.MinCores.Text, out minCores) || Int32.TryParse(filters.MaxCores.Text, out maxCores))
				{
					products = products.Where(product => (product as Computer).Cores >= minCores && (product as Computer).Cores <= maxCores).ToList();
				}


				int minFrequency = 0, maxFrequency = Int32.MaxValue;

				if (Int32.TryParse(filters.MinFrequency.Text, out minFrequency) || Int32.TryParse(filters.MaxFrequency.Text, out maxFrequency))
				{
					products = products.Where(product => (product as Computer).Frequency >= minFrequency && (product as Computer).Frequency <= maxFrequency).ToList();
				}

				
				int minRam = 0, maxRam = Int32.MaxValue;

				if (Int32.TryParse(filters.MinRAM.Text, out minRam) || Int32.TryParse(filters.MaxRAM.Text, out maxRam))
				{
					products = products.Where(product => (product as Computer).RamSize >= minRam && (product as Computer).RamSize <= maxRam).ToList();
				}

				ComputerType computerType = (ComputerType)filters.ComputerType.SelectedItem;
				
				if(computerType != ComputerType.None)
				{
					products = products.Where(product => (product as Computer).Type == computerType).ToList();
				}
				

				model.enums.OperatingSystem operating = (model.enums.OperatingSystem)filters.OS.SelectedItem;

				if (computerType != ComputerType.None)
				{
					products = products.Where(product => (product as Computer).OperatingSystem == operating).ToList();
				}

			}
			if (Activator.CreateInstance(CurrentProductType) as Peripherals != null)
			{
				PeripheralFilters filters = CodeBehind.FiltersContent.Content as PeripheralFilters;


				Color color = (Color)filters.Color.SelectedItem;

				if (color != Color.None)
				{
					products = products.Where(product => (product as Peripherals).Color == color).ToList();
				}


				PeripheralInterface peripheralInterface = (PeripheralInterface)filters.Interface.SelectedItem;

				if (peripheralInterface != PeripheralInterface.None)
				{
					products = products.Where(product => (product as Peripherals).Interface == peripheralInterface).ToList();
				}
			}

			UpdateMainList(products);
		}

		private void FindByNameExecute()
		{
			string nameToFind = CodeBehind.SearchString.Text;

			if (nameToFind.Length != 0)
			{
				CodeBehind.SearchString.Clear();
				List<Product> products = ProductService.FindByPredicate(product => product.Name.ToLower().Contains(nameToFind.ToLower())).ToList();
				UpdateMainList(products);
			}			
		}
		
		private void CancelExecute()
		{
			UpdateMainList(GetListOfCurrentType(ProductService.GetAll()));
			foreach(TextBox textBox in ChildFinder.FindVisualChildren<TextBox>(CodeBehind.Filters))
			{
				textBox.Text = "";
			}
			foreach(ComboBox comboBox in ChildFinder.FindVisualChildren<ComboBox>(CodeBehind.Filters))
			{
				comboBox.SelectedIndex = 0;
			}
			foreach(CheckBox checkBox in ChildFinder.FindVisualChildren<CheckBox>(CodeBehind.Filters))
			{
				checkBox.IsChecked = false;
			}
		}

		public List<Product> GetListOfCurrentType(List<Product> products)
		{
			if(CodeBehind.Tree.SelectedItem as TreeViewItem != null)
			{
				switch ((CodeBehind.Tree.SelectedItem as TreeViewItem).Header.ToString())
				{
					case "Товары":
						products = products.Where(product => product is Product).ToList();
						break;
					case "Компьютеры":
						products = products.Where(product => product is Computer).ToList();
						break;
					case "Периферия":
						products = products.Where(product => product is Peripherals).ToList();
						break;
					case "Настольные пк":
						products = products.Where(product => product is Desktop).ToList();
						break;
					case "Ноутбуки":
						products = products.Where(product => product is Laptop).ToList();
						break;
					case "Моноблоки":
						products = products.Where(product => product is Monoblock).ToList();
						break;
					case "Мыши":
						products = products.Where(product => product is model.database.Mouse).ToList();
						break;
					case "Клавиатуры":
						products = products.Where(product => product is model.database.Keyboard).ToList();
						break;
				}
			}			

			return products;
		}

		private Type TypeOfList(List<Product> products)
		{
			Type type = null;
			switch ((CodeBehind.Tree.SelectedItem as TreeViewItem).Header.ToString())
			{
				case "Товары":
					type = typeof(Product);
					break;
				case "Компьютеры":
					type = typeof(Computer);
					break;
				case "Периферия":
					type = typeof(Peripherals);
					break;
				case "Настольные пк":
					type = typeof(Desktop);
					break;
				case "Ноутбуки":
					type = typeof(Laptop);
					break;
				case "Моноблоки":
					type = typeof(Monoblock);
					break;
				case "Мыши":
					type = typeof(model.database.Mouse);
					break;
				case "Клавиатуры":
					type = typeof(model.database.Keyboard);
					break;
			}

			return type;
		}
	}
}
