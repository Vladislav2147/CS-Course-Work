using ComputerShop.model.database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            catch(Exception)
            {
                return false;
            }
        }
    }
}
