using ComputerShop.model.database;
using ComputerShop.view;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
	}
}
