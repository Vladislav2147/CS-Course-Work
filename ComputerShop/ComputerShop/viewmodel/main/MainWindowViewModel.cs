﻿using ComputerShop.model.database;
using ComputerShop.model.service.implementations;
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

		public MainWindowViewModel(MainWindow codeBehind, Customer customer)
		{
			Customer = customer;
			CodeBehind = codeBehind;
			ProductService = new ProductService();
			GoToCart = new RelayCommand(param => ExecuteGoToCart());
			Filter = new RelayCommand(param => FilterProducts());
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
			CodeBehind.MainContent.Content = view;
		}

		public void TreeItemExecute()
		{
			Type type = null;
			List<Product> products = ProductService.GetAll();
			switch ((CodeBehind.Tree.SelectedItem as TreeViewItem).Header.ToString())
			{
				case "Товары":
					products = products.Where(product => product is Product).ToList();
					type = typeof(Product);
					break;
				case "Компьютеры":
					products = products.Where(product => product is Computer).ToList();
					type = typeof(Computer);
					break;
				case "Периферия":
					products = products.Where(product => product is Peripherals).ToList();
					type = typeof(Peripherals);
					break;
				case "Настольные пк":
					products = products.Where(product => product is Desktop).ToList();
					type = typeof(Desktop);
					break;
				case "Ноутбуки":
					products = products.Where(product => product is Laptop).ToList();
					type = typeof(Laptop);
					break;
				case "Моноблоки":
					products = products.Where(product => product is Monoblock).ToList();
					type = typeof(Monoblock);
					break;
				case "Мыши":
					products = products.Where(product => product is model.database.Mouse).ToList();
					type = typeof(model.database.Mouse);
					break;
				case "Клавиатуры":
					products = products.Where(product => product is model.database.Keyboard).ToList();
					type = typeof(model.database.Keyboard);
					break;
			}

			CurrentProductType = type;

			if (Activator.CreateInstance(CurrentProductType) as Computer != null)
			{
				CodeBehind.FiltersContent.Content = new ComputerFilters();
			}
			if (Activator.CreateInstance(CurrentProductType) as Peripherals != null)
			{
				CodeBehind.FiltersContent.Content = new PeripheralFilters();
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

		private void FilterProducts()
		{

			List<Product> products = ProductService.GetAll();


			decimal beginPrice = Decimal.Zero, endPrice = Decimal.MaxValue;

			if(Decimal.TryParse(CodeBehind.BeginPrice.Text, out beginPrice) && Decimal.TryParse(CodeBehind.EndPrice.Text, out endPrice))
			{
				products = products.Where(product => product.Price >= beginPrice && product.Price <= endPrice).ToList();
			}


			int beginYear = DateTime.Now.Year - 20, endYear = DateTime.Now.Year;
			
			if(Int32.TryParse(CodeBehind.BeginYear.Text, out beginYear) && Int32.TryParse(CodeBehind.EndYear.Text, out endYear))
			{
				products = products.Where(product => product.Year >= beginYear && product.Year <= endYear).ToList();
			}

			if(CodeBehind.IsInWarehouse.IsChecked.Value)
			{
				products = products.Where(product => product.Amount != 0).ToList();
			}

			
			if (Activator.CreateInstance(CurrentProductType) as Computer != null)
			{
				MessageBox.Show("Computer");
			}
			if (Activator.CreateInstance(CurrentProductType) as Peripherals != null)
			{
				MessageBox.Show("perip");
			}

			(CodeBehind.MainContent.Content as MainList).ProductList.ItemsSource = products;
		}
	}
}
