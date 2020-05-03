using ComputerShop.model.database;
using ComputerShop.model.service.implementations;
using ComputerShop.view;
using ComputerShop.view.shoppingcart;
using ComputerShop.viewmodel.cart;
using System.Linq;
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
		}
		public Order GetCreatedOrder()
		{
			return Customer.Order.FirstOrDefault(order => order.State == State.Created);
		}
	}
}
