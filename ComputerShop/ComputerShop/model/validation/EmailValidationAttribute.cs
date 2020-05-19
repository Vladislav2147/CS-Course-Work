using System;
using System.ComponentModel.DataAnnotations;

namespace ComputerShop.model.validation
{
	public class EmailValidationAttribute : ValidationAttribute
	{
		public EmailValidationAttribute(string message) : base(message)
		{

		}
		public override bool IsValid(object value)
		{
			string email = value.ToString();
			try
			{
				var addr = new System.Net.Mail.MailAddress(email);
				return addr.Address == email;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
