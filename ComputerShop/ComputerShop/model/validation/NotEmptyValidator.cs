using System.Globalization;
using System.Windows.Controls;

namespace ComputerShop.model.validation
{
	class NotEmptyValidator : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			if (value == null || ((string)value).Length < 3)
			{
				return new ValidationResult(false, "Длина строки должна быть > 3");
			}
			else
			{
				return ValidationResult.ValidResult;
			}
		}
	}
}
