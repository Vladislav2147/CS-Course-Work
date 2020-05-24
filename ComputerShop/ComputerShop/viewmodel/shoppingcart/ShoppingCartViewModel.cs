using ComputerShop.model.database;
using ComputerShop.model.kindofmagic;
using ComputerShop.model.repository.implementations;
using ComputerShop.view;
using ComputerShop.view.shoppingcart;
using ComputerShop.viewmodel.main;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ComputerShop.viewmodel.cart
{
	class ShoppingCartViewModel : PropertyChangedBase
	{
		public OrderRepository OrderRepository { get; set; }
		public ProductRepository ProductRepository { get; set; }
		public ShoppingCart View { get; set; }
		public Customer Customer { get; set; }

		public ICommand AddAmountCommand { get; set; }
		public ICommand ReduceAmountCommand { get; set; }
		public ICommand DeleteProductCommand { get; set; }
		public ICommand ConfirmCommand { get; set; }
		public ICommand CancelCommand { get; set; }

		public ShoppingCartViewModel(Customer customer, ShoppingCart codeBehing)
		{
			OrderRepository = new OrderRepository();
			ProductRepository = new ProductRepository();

			AddAmountCommand = new RelayCommand(param => AddAmountCommandExecute(param));
			ReduceAmountCommand = new RelayCommand(param => ReduceAmountCommandExecute(param));
			DeleteProductCommand = new RelayCommand(param => DeleteProductCommandExecute(param));
			ConfirmCommand = new RelayCommand(param => ConfirmCommandExecute());
			CancelCommand = new RelayCommand(param => CancelCommandExecute());

			View = codeBehing;
			Customer = customer;
			Order order = Customer.Order.Where(ord => ord.State == State.Created).FirstOrDefault();
			if (order != null)
			{
				View.Order.ItemsSource = order.Ordered;
			}
		}

		private void CancelCommandExecute()
		{
			MainList view = new MainList(this.View.Owner);
			view.ProductList.ItemsSource = (this.View.Owner.DataContext as MainWindowViewModel).ProductRepository.GetAll();
			MainListViewModel vm = new MainListViewModel(view);
			vm.MainVM = this.View.Owner.DataContext as MainWindowViewModel;
			view.DataContext = vm;
			View.Owner.MainContent.Content = view;
			(View.Owner.DataContext as MainWindowViewModel).Filter.Execute(this);
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
			UpdateTotal();
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
			UpdateTotal();
		}
		private void DeleteProductCommandExecute(object sender)
		{
			Button button = sender as Button;
			Ordered ordered = button.DataContext as Ordered;
			View.Order.ItemsSource = View.Order.ItemsSource.Cast<Ordered>().Where(ord => ord != ordered);
			Customer.Order.First(order => order.State == State.Created).Ordered.Remove(ordered);
			UpdateTotal();
		}
		private void UpdateTotal()
		{
			View.TotalCost.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
		}
		private void ConfirmCommandExecute()
		{
			StringBuilder errorMessage = new StringBuilder("");
			Order formedOrder = Customer.Order.FirstOrDefault(order => order.State == State.Created);
			if (formedOrder != null)
			{
				if (View.Address.Text.Length > 0)
				{
					formedOrder.Address = View.Address.Text;
				}
				else
				{
					errorMessage.Append("Поле адреса не может быть пустым!\n");
				}
				if (View.Phone.IsMaskFull)
				{
					formedOrder.Phone = View.Phone.Text;
				}
				else
				{
					errorMessage.Append("Поле номера телефона заполнено некорректно!\n");
				}
				if (View.Order.Items.Count == 0)
				{
					errorMessage.Append("Заказ не может быть пустым!\n");
				}
				if (errorMessage.Length == 0)
				{
					foreach (var ordered in formedOrder.Ordered)
					{
						if (ProductRepository.GetById(ordered.Product.Id) == null)
						{
							MessageBox.Show($"Товар {ordered.Product.Name} был изменен. Он будет удален из корзины.");
							View.Order.ItemsSource = View.Order.ItemsSource.Cast<Ordered>().Where(ord => ord != ordered);
							Customer.Order.First(order => order.State == State.Created).Ordered.Remove(ordered);
							UpdateTotal();
							return;
						}
					}

					formedOrder.CustomerId = formedOrder.Customer.Id;
					formedOrder.State = State.Formed;
					formedOrder.Date = DateTime.Now;
					OrderRepository.Add((Order)formedOrder.Clone());
					OrderRepository.SaveChanges();

					MainList view = new MainList(View.Owner);
					MainListViewModel vm = new MainListViewModel(view);
					vm.MainVM = View.Owner.DataContext as MainWindowViewModel;
					view.DataContext = vm;
					View.Owner.MainContent.Content = view;
					(View.Owner.DataContext as MainWindowViewModel).Customer.Order.Add(new Order() { State = State.Created, Customer = this.Customer });
					MessageBox.Show("Заказ успешно сформирован. Ожидайте подтверждения.");
				}
				else
				{
					MessageBox.Show(errorMessage.ToString());
				}
			}
			else
			{
				MessageBox.Show("Ошибка");
			}
		}
	}
}
