using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ComputerShop.model.database;
using ComputerShop.model.business;
using ComputerShop.view;
using ComputerShop.model.enums;
using ComputerShop.model.service.implementations;

using System.IO;
using Microsoft.Win32;
using ComputerShop.viewmodel.main;
using ComputerShop.view.shoppingcart;
using System.ComponentModel;
using ComputerShop.model.statics;

namespace ComputerShop
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		
		public MainWindow()
		{
			InitializeComponent();
			//Авторизация костыль потом через конструктор передать
			Customer customer;
			using (ComputerShopContext context = new ComputerShopContext())
			{
				customer = context.Customer.Include("Order").Where(customer1 => customer1.Role == Role.User).FirstOrDefault();
			}
			
			//

			MainWindowViewModel mainvm = new MainWindowViewModel(this, customer);
			this.DataContext = mainvm;
			
			MainList view = new MainList(this);
			MainListViewModel vm = new MainListViewModel(view);
			vm.MainVM = this.DataContext as MainWindowViewModel;
			view.DataContext = vm;
			MainContent.Content = view;

			if (customer.Role == Role.Admin)
			{
				this.Cart.Visibility = Visibility.Collapsed;
				foreach (Button button in ChildFinder.FindVisualChildren<Button>((this.MainContent.Content as MainList).ProductList))
				{
					button.Visibility = Visibility.Collapsed;
				}
			}

			var desc = DependencyPropertyDescriptor.FromProperty(ContentControl.ContentProperty, typeof(ContentPresenter));
			desc.AddValueChanged(MainContent, MainContent_DataContextChanged);
		}

		private void MainContent_DataContextChanged(object sender, EventArgs e)
		{
			if (MainContent.Content is ShoppingCart)
			{
				Filters.Visibility = Visibility.Collapsed;
				Cart.IsEnabled = false;
			}
			else
			{
				Filters.Visibility = Visibility.Visible;
				Cart.IsEnabled = true;
			}
		}

		private void TreeItemExecute(object sender, RoutedEventArgs e)
		{
			(DataContext as MainWindowViewModel).TreeItemExecute();
		}
		public MainWindow(Customer customer) { }

	}
}
