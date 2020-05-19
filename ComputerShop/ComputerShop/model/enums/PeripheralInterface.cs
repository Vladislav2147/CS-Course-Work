using ComputerShop.model.converters;
using System.ComponentModel;

namespace ComputerShop.model.enums
{
	[TypeConverter(typeof(EnumDescriptionTypeConverter))]
	public enum PeripheralInterface
	{
		[Description("Не указан")]
		None,
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
