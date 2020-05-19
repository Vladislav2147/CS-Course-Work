using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace ComputerShop.model.validation
{

	class ResolutionValidator : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			Regex regex = new Regex("^[0-9]{3,4}x[0-9]{3,4}$");
			if (value == null || !regex.IsMatch((string)value))
			{
				return new ValidationResult(false, "Неверный формат");
			}
			else
			{
				return ValidationResult.ValidResult;
			}
		}
	}
}
