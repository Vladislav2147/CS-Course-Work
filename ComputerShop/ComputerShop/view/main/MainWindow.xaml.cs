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
			MainWindowViewModel mainvm = new MainWindowViewModel(this);
			this.DataContext = mainvm;
			//Авторизация костыль
			using (ComputerShopContext context = new ComputerShopContext())
			{
				(this.DataContext as MainWindowViewModel).Customer = context.Customer.Include("Order").Where(customer => customer.Role == Role.User).FirstOrDefault();
			}
			if ((this.DataContext as MainWindowViewModel).Customer.Role == Role.Admin)
			{
				this.Cart.Visibility = Visibility.Collapsed;
			}
			//
			MainList view = new MainList(this);
			MainListViewModel vm = new MainListViewModel(view);
			view.DataContext = vm;
			MainContent.Content = view;
			
		}
		public MainWindow(Customer customer) : this()
		{
			(this.DataContext as MainWindowViewModel).Customer = customer;
			if(customer.Role == Role.Admin)
			{
				this.Cart.Visibility = Visibility.Collapsed;
			}
		}
		
	}
}
