using ComputerShop.model.database;
using ComputerShop.view.shoppingcart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.viewmodel.cart
{
	class ShoppingCartViewModel
	{
		public ShoppingCart CodeBehind { get; set; }
		public Customer Customer { get; set; }
		public ShoppingCartViewModel(Customer customer, ShoppingCart codeBehing)
		{
			CodeBehind = codeBehing;
			Customer = customer;
			Order order = Customer.Order.Where(ord => ord.State == State.Created).FirstOrDefault();
			if (order != null)
			{
				CodeBehind.Order.ItemsSource = order.Ordered;
			}
		}
	}
}
