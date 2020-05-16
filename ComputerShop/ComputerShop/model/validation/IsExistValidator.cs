using ComputerShop.model.service.implementations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ComputerShop.model.validation
{
	class IsExistValidator : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			try
			{
				ProductService productService = new ProductService();
				if (value != null && productService.GetById(Int32.Parse((string)value)) != null)
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