﻿using System;
using System.Globalization;
using System.Windows.Controls;

namespace ComputerShop.model.validation
{
	class IntegerValidator : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			if (value == null || !Int32.TryParse((string)value, out _) || Int32.Parse((string)value) < 0)
			{
				return new ValidationResult(false, "Введите целое число > 0");
			}
			else
			{
				return ValidationResult.ValidResult;
			}
		}
	}
}
