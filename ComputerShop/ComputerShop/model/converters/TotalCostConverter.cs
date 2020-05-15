using ComputerShop.model.database;
using ComputerShop.viewmodel.adminTools;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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