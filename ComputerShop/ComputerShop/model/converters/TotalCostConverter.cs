using ComputerShop.model.database;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace ComputerShop.model.converters
{
	class TotalCostConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (value as Supply).DeliveredToWareHouse.Sum(delivered => delivered.Amount * delivered.Price);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}