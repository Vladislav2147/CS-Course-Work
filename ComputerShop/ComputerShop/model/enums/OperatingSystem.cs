using ComputerShop.model.converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.model.enums
{
	[TypeConverter(typeof(EnumDescriptionTypeConverter))]
	public enum OperatingSystem
	{
		[Description("Не указана")]
		None,
		[Description("Windows 7")]
		Windows7,
		[Description("Windows 8")]
		Windows8,
		[Description("Windows 10")]
		Windows10,
		[Description("Linux")]
		Linux,
		[Description("Mac OS")]
		MacOS
	}
}
