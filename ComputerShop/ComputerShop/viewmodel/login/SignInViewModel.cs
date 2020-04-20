using ComputerShop.view;
using ComputerShop.view.login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ComputerShop.viewmodel.login
{
	class SignInViewModel
	{
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
			CodeBehind.LoginOutputView.Content = new SignUp();
		}
		private void ExecuteLoadMainWindow()
		{
			//Валидация и прочее
			MainWindow mainWindow = new MainWindow();
			mainWindow.Show();
			CodeBehind.Close();
		}

	}
}
