using ComputerShop.model.business;
using ComputerShop.model.database;
using ComputerShop.model.repository.implementations;
using ComputerShop.view;
using ComputerShop.view.login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ComputerShop.viewmodel.login
{
	class SignInViewModel
	{
		public string Login { get; set; }
		public string Password { get; set; }
		public ICommand LoadRegistration { get; private set; }
		public ICommand LoadMainWindow { get; private set; }
		public LoginWindow CodeBehind { get; set; }
		public CustomerRepository CustomerRepository { get; set;}

		public SignInViewModel()
		{
			LoadRegistration = new RelayCommand(param => ExecuteLoadRegistration());
			LoadMainWindow = new RelayCommand(param => ExecuteLoadMainWindow());
		}

		private void ExecuteLoadRegistration()
		{
			SignUp view = new SignUp();
			SignUpViewModel vm = new SignUpViewModel();
			vm.CodeBehind = this.CodeBehind;
			view.DataContext = vm;
			CodeBehind.LoginOutputView.Content = view;
		}
		private void ExecuteLoadMainWindow()
		{
			using(ComputerShopContext computerShopContext = new ComputerShopContext())
			{
				CustomerRepository = new CustomerRepository(computerShopContext);
				Customer customer = CustomerRepository.FindByPredicate(cust => cust.Login == Login).FirstOrDefault();
				if (customer != null)
				{
					if (Password != null && CustomerRepository.HashEquals(Password, customer.Password))
					{
						MainWindow mainWindow = new MainWindow(customer);
						mainWindow.Show();
						CodeBehind.Close();
					}
					else
					{
						MessageBox.Show("Введен неверный пароль");
					}
				}
				else
				{
					MessageBox.Show("Неверно введен логин");
				}
			}
			
		}

	}
}
