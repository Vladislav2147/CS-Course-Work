﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ComputerShop.model.validation
{
	class DoubleValidator : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			if (value == null || !Double.TryParse((string)value, out _))
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