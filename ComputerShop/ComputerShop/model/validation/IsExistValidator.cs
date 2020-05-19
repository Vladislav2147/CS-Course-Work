using ComputerShop.model.repository.implementations;
using System;
using System.Globalization;
using System.Windows.Controls;

namespace ComputerShop.model.validation
{
	class IsExistValidator : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			try
			{
				ProductRepository productRepository = new ProductRepository();
				if (value != null && productRepository.GetById(Int32.Parse((string)value)) != null)
				{
					return ValidationResult.ValidResult;
				}
				else
				{
					return new ValidationResult(false, "Артикул не существует");
				}
			}
			catch (Exception)
			{
				return new ValidationResult(false, "Ошибка");
			}

		}
	}
}