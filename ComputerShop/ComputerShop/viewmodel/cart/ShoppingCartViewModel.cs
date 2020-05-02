using ComputerShop.model.database;
using ComputerShop.model.kindofmagic;
using ComputerShop.view.shoppingcart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ComputerShop.viewmodel.cart
{
	class ShoppingCartViewModel : PropertyChangedBase
	{
		public ShoppingCart CodeBehind { get; set; }
		public Customer Customer { get; set; }
		public ICommand AddAmountCommand { get; set; }
		public ICommand ReduceAmountCommand { get; set; }
		public ICommand DeleteProductCommand { get; set; }
		public ShoppingCartViewModel(Customer customer, ShoppingCart codeBehing)
		{
			AddAmountCommand = new RelayCommand(param => AddAmountCommandExecute(param));
			ReduceAmountCommand = new RelayCommand(param => ReduceAmountCommandExecute(param));
			DeleteProductCommand = new RelayCommand(param => DeleteProductCommandExecute(param));
			CodeBehind = codeBehing;
			Customer = customer;
			Order order = Customer.Order.Where(ord => ord.State == State.Created).FirstOrDefault();
			if (order != null)
			{
				CodeBehind.Order.ItemsSource = order.Ordered;
			}
		}
		private void AddAmountCommandExecute(object sender)
		{
			Button button = sender as Button;
			Ordered ordered = button.DataContext as Ordered;
			ordered.Amount++;
			
			if (ordered.Amount == ordered.Product.Amount)
			{
				button.IsEnabled = false;
			}
			((button.Parent as DockPanel).Children[0] as Button).IsEnabled = true;
		}
		private void ReduceAmountCommandExecute(object sender)
		{
			Button button = sender as Button;
			Ordered ordered = button.DataContext as Ordered;
			ordered.Amount--;
			
			if (ordered.Amount == 1)
			{
				button.IsEnabled = false;
			}
			((button.Parent as DockPanel).Children[1] as Button).IsEnabled = true;
		}
		private void DeleteProductCommandExecute(object sender)
		{
			Button button = sender as Button;
			Ordered ordered = button.DataContext as Ordered;
			CodeBehind.Order.ItemsSource = CodeBehind.Order.ItemsSource.Cast<Ordered>().Where(ord => ord != ordered);
			Customer.Order.First(order => order.Ordered.Contains(ordered)).Ordered.Remove(ordered);
		}
	}
}
