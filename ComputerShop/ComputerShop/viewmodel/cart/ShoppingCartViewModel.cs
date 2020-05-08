using ComputerShop.model.database;
using ComputerShop.model.kindofmagic;
using ComputerShop.model.service.implementations;
using ComputerShop.view;
using ComputerShop.view.shoppingcart;
using ComputerShop.viewmodel.main;
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
		public OrderService OrderService { get; set; }
		public ShoppingCart CodeBehind { get; set; }
		public Customer Customer { get; set; }
		public ICommand AddAmountCommand { get; set; }
		public ICommand ReduceAmountCommand { get; set; }
		public ICommand DeleteProductCommand { get; set; }
		public ICommand ConfirmCommand { get; set; }
		public ICommand CancelCommand { get; set; }
		public ShoppingCartViewModel(Customer customer, ShoppingCart codeBehing)
		{
			OrderService = new OrderService();
			AddAmountCommand = new RelayCommand(param => AddAmountCommandExecute(param));
			ReduceAmountCommand = new RelayCommand(param => ReduceAmountCommandExecute(param));
			DeleteProductCommand = new RelayCommand(param => DeleteProductCommandExecute(param));
			ConfirmCommand = new RelayCommand(param => ConfirmCommandExecute());
			CancelCommand = new RelayCommand(param => CancelCommandExecute());
			CodeBehind = codeBehing;
			Customer = customer;
			Order order = Customer.Order.Where(ord => ord.State == State.Created).FirstOrDefault();
			if (order != null)
			{
				CodeBehind.Order.ItemsSource = order.Ordered;
			}
		}

		private void CancelCommandExecute()
		{
			MainList view = new MainList(this.CodeBehind.Owner);			
			view.ProductList.ItemsSource = (this.CodeBehind.Owner.DataContext as MainWindowViewModel).ProductService.GetAll();
			MainListViewModel vm = new MainListViewModel(view);
			vm.MainVM = this.CodeBehind.Owner.DataContext as MainWindowViewModel;
			view.DataContext = vm;
			CodeBehind.Owner.MainContent.Content = view;
			(CodeBehind.Owner.DataContext as MainWindowViewModel).Filter.Execute(this);
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
			CodeBehind.Order.ItemsSource = CodeBehind.Order.ItemsSource.Cast<Ordered>().Where(ord => ord != ordered);
			Customer.Order.First(order => order.State == State.Created).Ordered.Remove(ordered);
			UpdateTotal();
		}
		private void UpdateTotal()
		{
			CodeBehind.TotalCost.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
		}
		private void ConfirmCommandExecute()
		{
			using(ComputerShopContext context = new ComputerShopContext())
			{
				StringBuilder errorMessage = new StringBuilder("");
				Order formedOrder = Customer.Order.FirstOrDefault(order => order.State == State.Created);
				if (formedOrder != null)
				{					
					if (CodeBehind.Address.Text.Length > 0)
					{
						formedOrder.Address = CodeBehind.Address.Text;
					}
					else
					{
						errorMessage.Append("Поле адреса не может быть пустым!\n");
					}
					if (CodeBehind.Phone.IsMaskFull)
					{
						formedOrder.Phone = CodeBehind.Phone.Text;
					}
					else
					{
						errorMessage.Append("Поле номера телефона заполнено некорректно!\n");
					}
					if(CodeBehind.Order.Items.Count == 0)
					{
						errorMessage.Append("Заказ не может быть пустым!\n");
					}
					if (errorMessage.Length == 0)
					{
						
						formedOrder.CustomerId = formedOrder.Customer.Id;
						formedOrder.State = State.Formed;
						formedOrder.Date = DateTime.Now;
						context.Order.Add((Order)formedOrder.Clone());
						context.SaveChanges();
						MainList view = new MainList(CodeBehind.Owner);
						MainListViewModel vm = new MainListViewModel(view);
						vm.MainVM = CodeBehind.Owner.DataContext as MainWindowViewModel;
						view.DataContext = vm;
						CodeBehind.Owner.MainContent.Content = view;
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
}
