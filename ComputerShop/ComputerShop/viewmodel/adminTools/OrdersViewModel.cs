using ComputerShop.model.database;
using ComputerShop.model.kindofmagic;
using ComputerShop.model.service.implementations;
using ComputerShop.model.statics;
using ComputerShop.view.adminTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ComputerShop.viewmodel.adminTools
{
	class OrdersViewModel : PropertyChangedBase
	{
		public OrderService OrderService { get; set; }
		public CustomerService CustomerService { get; set; }
		public OrdersUC CodeBehind { get; set; }
		
		public List<Order> NotAcceptedOrders { get; set; }
		public List<Order> AcceptedOrders { get; set; }

		public ICommand Accept { get; set; }

		public OrdersViewModel(OrdersUC codeBehind)
		{
			CodeBehind = codeBehind;

			CustomerService = new CustomerService();
			OrderService = new OrderService();

			UpdateLists();
			Accept = new RelayCommand(param => ExecuteAccept(param));
		}

		private void ExecuteAccept(object sender)
		{
			Order order = (sender as Button).DataContext as Order;
			foreach(Ordered ordered in order.Ordered)
			{
				ordered.Product.Amount -= ordered.Amount;
			}
			try
			{
				OrderService.SaveChanges();
				order.State = State.Approved;
				OrderService.SaveChanges();
			}
			catch (Exception)
			{
				MessageBox.Show("Неваозможно принять заказ");
			}

			Customer admin = CustomerService.FindByPredicate(cust => cust.Role == model.enums.Role.Admin).FirstOrDefault();
			StringBuilder message = new StringBuilder($"Заказ N{order.Id} подтвержден");
			message.Append("<table border=\"1\"><tr><td>Название</td><td>Количество</td><td>Цена за шт</td></tr>");
			decimal total = 0;

			foreach(var ordered in order.Ordered)
			{
				total += ordered.Product.Price * ordered.Amount;
				message.Append($"<tr><td>{ordered.Product.Name}</td><td>{ordered.Amount}</td><td>{ordered.Product.Price:0.00}</td></tr>");
			}
			message.Append($"</table><br><b>К оплате:{total:0.00}</b>");

			PostEmail.SendEmail(admin.Email, "abcd88005553535", order.Customer.Email, message.ToString());			
			UpdateLists();
		}
		private void UpdateLists()
		{
			NotAcceptedOrders = OrderService.FindByPredicate(order => order.State == State.Formed).ToList();
			AcceptedOrders = OrderService.FindByPredicate(order => order.State == State.Approved).ToList();
		}
	}
}
