using ComputerShop.model.database;
using ComputerShop.viewmodel.cart;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace ComputerShop.model.converters
{
	class OrderPriceConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (value as ShoppingCartViewModel).View.Order.ItemsSource.Cast<Ordered>().Sum(orderd => orderd.Amount * orderd.Product.Price).ToString("0.00");
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
