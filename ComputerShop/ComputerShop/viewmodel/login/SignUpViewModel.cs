using ComputerShop.model.database;
using ComputerShop.model.repository.implementations;
using ComputerShop.view.login;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ComputerShop.viewmodel.login
{
	class SignUpViewModel
	{
		public string Email { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
		public CustomerRepository CustomerRepository { get; set; }
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
			StringBuilder stringBuilder = new StringBuilder("");
			if(Password == null)
			{
				stringBuilder.Append("Поле пароль не может быть пустым");
			}
			else
			{
				if (Password == ConfirmPassword)
				{
					using(ComputerShopContext context = new ComputerShopContext())
					{
						try
						{
							CustomerRepository = new CustomerRepository(context);
							Customer customer = new Customer()
							{
								Login = Login,
								Email = Email,
								Password = CustomerRepository.HashPassword(Password)
							};
							var results = new List<ValidationResult>();
							var cont = new ValidationContext(customer);

							if (!Validator.TryValidateObject(customer, cont, results, true))
							{
								foreach (var error in results)
								{
									stringBuilder.Append(error);
									stringBuilder.Append("\n");
								}
							}
							else
							{								
								CustomerRepository.RegistrateCustomer(customer);
								CustomerRepository.SaveChanges();
								ExecuteBack();
							}
						}
						catch (DataException e)
						{
							stringBuilder.Append(e.Message);
							stringBuilder.Append("\n");
						}
					}
				}
				else
				{
					stringBuilder.Append("Подтверждение пароля не совпадает с паролем");
				}
			}
			if(stringBuilder.Length != 0)
			{
				MessageBox.Show(stringBuilder.ToString());
			}
			
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
