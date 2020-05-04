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
			//Авторизация костыль
			Customer customer;
			using (ComputerShopContext context = new ComputerShopContext())
			{
				customer = context.Customer.Include("Order").Where(customer1 => customer1.Role == Role.User).FirstOrDefault();
			}
			if (customer.Role == Role.Admin)
			{
				this.Cart.Visibility = Visibility.Collapsed;
			}
			//

			MainWindowViewModel mainvm = new MainWindowViewModel(this, customer);
			this.DataContext = mainvm;
			
			MainList view = new MainList(this);
			MainListViewModel vm = new MainListViewModel(view);
			vm.MainVM = this.DataContext as MainWindowViewModel;
			view.DataContext = vm;
			MainContent.Content = view;
			
		}
		private void TreeItemExecute(object sender, RoutedEventArgs e)
		{
			(DataContext as MainWindowViewModel).TreeItemExecute();
		}
		public MainWindow(Customer customer) { }

	}
}
