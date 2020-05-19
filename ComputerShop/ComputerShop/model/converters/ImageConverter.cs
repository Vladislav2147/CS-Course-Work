using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace ComputerShop.model.converters
{
	public class ImageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
			{
				using (MemoryStream ms = new MemoryStream((byte[])value))
				{
					var decoder = BitmapDecoder.Create(ms,
						BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
					return decoder.Frames[0];
				}
			}
			else
			{
				return "/pictures/none.png";
			}

		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			System.Drawing.Image image = System.Drawing.Image.FromFile((string)value);
			using (MemoryStream ms = new MemoryStream())
			{
				image.Save(ms, image.RawFormat);
				return ms.ToArray();
			}
		}
	}
}
