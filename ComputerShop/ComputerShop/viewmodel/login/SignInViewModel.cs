using ComputerShop.model.business;
using ComputerShop.model.database;
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
				Customer customer = computerShopContext.Customer.FirstOrDefault(cust => cust.Login == Login);
				if (customer != null)
				{
					if (Password.EqualsToHash(customer.Password))
					{
						//передать роль параметром
						MainWindow mainWindow = new MainWindow();
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
