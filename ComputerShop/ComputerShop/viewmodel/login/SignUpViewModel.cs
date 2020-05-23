using ComputerShop.model.database;
using ComputerShop.model.repository.implementations;
using ComputerShop.view.login;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using DbUpdateException = System.Data.Entity.Infrastructure.DbUpdateException;

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
		public LoginWindow View { get; set; }

		public SignUpViewModel()
		{
			Registrate = new RelayCommand(param => ExecuteRegistrate());
			Back = new RelayCommand(param => ExecuteBack());

		}

		private void ExecuteRegistrate()
		{
			StringBuilder stringBuilder = new StringBuilder("");
			Regex pattern = new Regex(@"^\w{4,15}$");
			if (Password == null || !pattern.IsMatch(Password))
			{
				stringBuilder.Append("Поле пароль не может быть пустым, не должно содержать спец. символов и иметь длину не менее 4 и не более 15");
			}
			else
			{
				if (Password == ConfirmPassword)
				{
					using (ComputerShopContext context = new ComputerShopContext())
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
						catch (DbEntityValidationException e)
						{
							foreach (DbEntityValidationResult validationError in e.EntityValidationErrors)
							{
								foreach (DbValidationError err in validationError.ValidationErrors)
								{
									stringBuilder.Append(err.ErrorMessage);

									stringBuilder.Append("\n");

								}
							}

							
						}
						catch (Exception e)
						{
							if (CustomerRepository.FindByPredicate(cust => cust.Email == Email).FirstOrDefault() != null)
							{
								stringBuilder.Append("Пользователь с данной почтой уже существует");

								stringBuilder.Append("\n");
							}
							else
							{
								stringBuilder.Append(e.Message);

								stringBuilder.Append("\n");
							}
						}
					}
				}
				else
				{
					stringBuilder.Append("Подтверждение пароля не совпадает с паролем");
				}
			}
			if (stringBuilder.Length != 0)
			{
				MessageBox.Show(stringBuilder.ToString());
			}

		}
		private void ExecuteBack()
		{
			SignIn view = new SignIn();
			SignInViewModel vm = new SignInViewModel();
			vm.View = this.View;
			view.DataContext = vm;
			View.LoginOutputView.Content = view;
		}
	}
}
