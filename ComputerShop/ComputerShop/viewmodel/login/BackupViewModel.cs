using ComputerShop.model.database;
using ComputerShop.model.kindofmagic;
using ComputerShop.model.repository.implementations;
using ComputerShop.model.statics;
using ComputerShop.view.login;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace ComputerShop.viewmodel.login
{
	public class BackupViewModel : PropertyChangedBase
	{
		private string code;

		public LoginWindow CodeBehind { get; set; }
		public CustomerRepository CustomerRepository { get; set; }
		public string Email { get; set; }
		public string InputCode { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
		public ICommand Back { get; set; }
		public ICommand SendEmail { get; set; }
		public ICommand Accept { get; set; }
		public ICommand ChangePassword { get; set; }

		public BackupViewModel()
		{
			Back = new RelayCommand(param => BackExecute());
			SendEmail = new RelayCommand(param => SendEmailExecute());
			Accept = new RelayCommand(param => AcceptExecute());
			ChangePassword = new RelayCommand(param => ChangePasswordExecute());

			CustomerRepository = new CustomerRepository();

		}

		private void BackExecute()
		{
			SignIn view = new SignIn();
			SignInViewModel vm = new SignInViewModel();
			vm.CodeBehind = this.CodeBehind;
			view.DataContext = vm;
			CodeBehind.LoginOutputView.Content = view;
		}

		private void SendEmailExecute()
		{
			Random rand = new Random();
			code = rand.Next(1000, 9999).ToString();
			Customer customer = CustomerRepository.FindByPredicate(cust => cust.Email == Email).FirstOrDefault();
			if (customer != null)
			{
				PostEmail.SendEmail(Email, $"Ваш код: {code}, Логин: {customer.Login}");
			}
			else
			{
				MessageBox.Show("На данную почту не зарегистрированы пользователи");
			}
		}

		private void AcceptExecute()
		{
			if (code == InputCode)
			{
				Password view = new Password();
				view.DataContext = this;
				CodeBehind.LoginOutputView.Content = view;
			}
			else
			{
				MessageBox.Show("Введен неверный код");
			}
		}

		private void ChangePasswordExecute()
		{
			Customer customer = CustomerRepository.FindByPredicate(cust => cust.Email == Email).FirstOrDefault();

			Regex pattern = new Regex(@"^\w{4,15}$");

			if (customer != null && Password == ConfirmPassword && pattern.IsMatch(Password))
			{
				customer.Password = CustomerRepository.HashPassword(Password);
				CustomerRepository.ChangeItem(customer);
				CustomerRepository.SaveChanges();

				BackExecute();
			}
			else
			{
				MessageBox.Show("Пароль должен иметь длину от 4 до 5 и состоять из букв и цифр");
			}
		}
	}
}
