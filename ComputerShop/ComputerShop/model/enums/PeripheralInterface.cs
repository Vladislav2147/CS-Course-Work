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
	public enum PeripheralInterface
	{
		[Description("PS/2")]
		PS2,
		[Description("USB")]
		USB,
		[Description("Wi-Fi")]
		WiFi,
		[Description("Bluetooth")]
		Bluetooth,
		[Description("Радио")]
		Radio
	}
}
