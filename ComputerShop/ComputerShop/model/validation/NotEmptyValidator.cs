using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ComputerShop.model.validation
{
	class NotEmptyValidator : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			if(value == null || ((string)value).Length < 3)
			{
				return new ValidationResult(false, "Поле не может быть пустым");
			}
			else
			{
				return ValidationResult.ValidResult;
			}
		}
	}
}
