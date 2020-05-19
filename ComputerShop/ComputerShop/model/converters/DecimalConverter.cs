using System;
using System.Globalization;
using System.Windows.Data;

namespace ComputerShop.model.converters
{
	class DecimalConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			decimal price = Decimal.Parse(value.ToString());
			return price;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value.ToString();
		}
	}
}