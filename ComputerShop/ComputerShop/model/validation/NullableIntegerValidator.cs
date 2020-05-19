using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Forms;

namespace ComputerShop.model.validation
{
	class NullableIntegerValidator : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			if (value != null && !Int32.TryParse((string)value, out _))
			{
				MessageBox.Show(Int32.TryParse((string)value, out _).ToString());
				return new ValidationResult(false, "Введите целое число");
			}
			else
			{
				return ValidationResult.ValidResult;
			}
		}
	}
}
