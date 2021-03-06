﻿using System;
using System.Globalization;
using System.Windows.Controls;

namespace ComputerShop.model.validation
{
	class DecimalValidator : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			if (value != null && Decimal.TryParse((string)value, out _) && Decimal.Parse((string)value) > 0)
			{
				return ValidationResult.ValidResult;
			}
			else
			{
				return new ValidationResult(false, "Неверный формат");

			}
		}
	}
}
