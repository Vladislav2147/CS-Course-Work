using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ComputerShop.model.validation
{
	class YearValidator : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			if (value == null || !Int32.TryParse((string)value, out _) || ((string)value).Length < 4)
			{
				return new ValidationResult(false, "Неверный формат года");
			}
			else
			{
				return ValidationResult.ValidResult;
			}
		}
	}
}
