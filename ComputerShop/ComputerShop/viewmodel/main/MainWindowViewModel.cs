using ComputerShop.model.database;
using ComputerShop.model.service.implementations;
using ComputerShop.view;
using ComputerShop.view.shoppingcart;
using ComputerShop.viewmodel.cart;
using ComputerShop.viewmodel.login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ComputerShop.viewmodel.main
{
	class MainWindowViewModel
	{
		public MainWindow CodeBehind { get; set; }
		public ProductService ProductService { get; set; }
		public Customer Customer { get; set; }
		public ICommand GoToCart { get; set; }
		

		public MainWindowViewModel(MainWindow codeBehind)
		{
			CodeBehind = codeBehind;
			ProductService = new ProductService();
			GoToCart = new RelayCommand(param => ExecuteGoToCart());
			
		}
		private void ExecuteGoToCart()
		{
			ShoppingCart view = new ShoppingCart(CodeBehind);
			ShoppingCartViewModel vm = new ShoppingCartViewModel(Customer, view);
			view.DataContext = vm;
			CodeBehind.MainContent.Content = view;
		}

	}
}
