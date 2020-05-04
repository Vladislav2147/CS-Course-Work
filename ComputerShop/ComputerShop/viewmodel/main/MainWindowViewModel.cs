using ComputerShop.model.database;
using ComputerShop.model.service.implementations;
using ComputerShop.view;
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
		public ICommand GoToCart { get; set; }

		public MainWindowViewModel(MainWindow codeBehind, Customer customer)
		{
			Customer = customer;
			CodeBehind = codeBehind;
			ProductService = new ProductService();
			GoToCart = new RelayCommand(param => ExecuteGoToCart());
			if(GetCreatedOrder() == null)
			{
				Customer.Order.Add(new Order() { State = State.Created, Customer = this.Customer });
			}
			
		}
		private void ExecuteGoToCart()
		{
			ShoppingCart view = new ShoppingCart(CodeBehind);
			ShoppingCartViewModel vm = new ShoppingCartViewModel(Customer, view);
			view.DataContext = vm;
			ListState = CodeBehind.MainContent.Content as MainList;
			CodeBehind.MainContent.Content = view;
			CodeBehind.Filters.Visibility = System.Windows.Visibility.Collapsed;
			CodeBehind.Cart.IsEnabled = false;
		}
		public void TreeItemExecute()
		{
			List<Product> products = ProductService.GetAll();
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
	}
}
