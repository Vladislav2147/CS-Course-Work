﻿using ComputerShop.model.database;
using ComputerShop.model.kindofmagic;
using ComputerShop.model.repository.implementations;
using ComputerShop.model.statics;
using ComputerShop.view.adminTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ComputerShop.viewmodel.adminTools
{
	class OrdersViewModel : PropertyChangedBase
	{
		public OrderRepository OrderRepository { get; set; }
		public CustomerRepository CustomerRepository { get; set; }
		public OrdersUC View { get; set; }

		public List<Order> NotAcceptedOrders { get; set; }
		public List<Order> AcceptedOrders { get; set; }

		public ICommand Accept { get; set; }

		public OrdersViewModel(OrdersUC view)
		{
			View = view;

			CustomerRepository = new CustomerRepository();
			OrderRepository = new OrderRepository();

			UpdateLists();
			Accept = new RelayCommand(param => ExecuteAccept(param));
		}

		private void ExecuteAccept(object sender)
		{
			Order order = (sender as Button).DataContext as Order;
			try
			{
				
				foreach (Ordered ordered in order.Ordered)
				{
					if (ordered.Product.Amount - ordered.Amount >= 0)
					{
						ordered.Product.Amount -= ordered.Amount;
					}
					else
					{
						throw new ArgumentOutOfRangeException("Количество товара");
					}
				}
				OrderRepository.SaveChanges();
				order.State = State.Approved;
				OrderRepository.SaveChanges();
			}
			catch (Exception e)
			{
				MessageBox.Show($"Невозможно принять заказ: {e.Message}");
				return;
			}

			StringBuilder message = new StringBuilder($"Заказ N{order.Id} подтвержден");
			message.Append("<table border=\"1\"><tr><td>Название</td><td>Количество</td><td>Цена за шт</td></tr>");

			decimal total = 0;

			foreach (var ordered in order.Ordered)
			{
				total += ordered.Product.Price * ordered.Amount;
				message.Append($"<tr><td>{ordered.Product.Name}</td><td>{ordered.Amount}</td><td>{ordered.Product.Price:0.00}</td></tr>");
			}
			message.Append($"</table><br><b>К оплате:{total:0.00}</b>");

			PostEmail.SendEmail(order.Customer.Email, message.ToString());
			UpdateLists();
		}

		private void UpdateLists()
		{
			NotAcceptedOrders = OrderRepository.FindByPredicate(order => order.State == State.Formed).ToList();
			AcceptedOrders = OrderRepository.FindByPredicate(order => order.State == State.Approved).ToList();
		}
	}
}
