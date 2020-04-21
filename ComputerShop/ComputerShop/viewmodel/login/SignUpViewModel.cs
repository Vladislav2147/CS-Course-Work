using ComputerShop.model.database;
using ComputerShop.view.login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ComputerShop.viewmodel.login
{
	class SignUpViewModel
	{
		public string Email { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
		public ICommand Registrate { get; private set; }
		public ICommand Back { get; private set; }
		public LoginWindow CodeBehind { get; set; }

		public SignUpViewModel()
		{
			Registrate = new RelayCommand(param => ExecuteRegistrate());
			Back = new RelayCommand(param => ExecuteBack());

		}

		private void ExecuteRegistrate()
		{
			//Добавление пользователя
		}
		private void ExecuteBack()
		{
			SignIn view = new SignIn();
			SignInViewModel vm = new SignInViewModel();
			vm.CodeBehind = this.CodeBehind;
			view.DataContext = vm;
			CodeBehind.LoginOutputView.Content = view;

		}
	}
}
