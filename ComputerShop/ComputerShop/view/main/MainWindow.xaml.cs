using ComputerShop.model.database;
using ComputerShop.model.enums;
using ComputerShop.model.statics;
using ComputerShop.view;
using ComputerShop.view.shoppingcart;
using ComputerShop.viewmodel.main;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

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
			Closed += MainWindowClosed;

		}

		public MainWindow(Customer customer) : this()
		{
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
				this.AdminMenu.Visibility = Visibility.Visible;
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
			foreach (var item in ChildFinder.FindVisualChildren<TreeViewItem>(AdminMenu))
			{
				item.IsSelected = false;
			}
			(DataContext as MainWindowViewModel).TreeItemExecute();
		}

		private void AdminToolsSelectedItemChanged(object sender, RoutedEventArgs e)
		{
			foreach (var item in ChildFinder.FindVisualChildren<TreeViewItem>(Tree))
			{
				item.IsSelected = false;
			}
			string tool = (sender as TreeViewItem).Header.ToString();
			(DataContext as MainWindowViewModel).SelectAdminTool(tool);
		}

		private void MainWindowClosed(object sender, EventArgs e)
		{
			Application.Current.Shutdown();
		}
	}
}
