using ComputerShop.model.database;
using ComputerShop.view;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ComputerShop.viewmodel.main
{
	class MainListViewModel
	{
		public MainWindowViewModel MainVM { get; set; }
		public MainList CodeBehind { get; set; }
		public ICommand AddToCart { get; set; }
		public MainListViewModel(MainList codeBehind)
		{
			CodeBehind = codeBehind;
			AddToCart = new RelayCommand(param => ExecuteAddToCart(param));
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

		public void UpdateButtons()
		{
			Order order = MainVM.Customer.Order.FirstOrDefault(ord => ord.State == State.Created);
			foreach(Button button in FindVisualChildren<Button>(CodeBehind.ProductList))
			{
				if(order.Ordered.FirstOrDefault(ord => ord.Product == (Product)button.DataContext) != null && MainVM.Customer.Role == model.enums.Role.User)
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
		public IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
		{
			if (depObj != null)
			{
				for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
				{
					DependencyObject child = VisualTreeHelper.GetChild(depObj, i);

					if (child != null && child is T)
						yield return (T)child;

					foreach (T childOfChild in FindVisualChildren<T>(child))
						yield return childOfChild;
				}
			}
		}
	}
}
