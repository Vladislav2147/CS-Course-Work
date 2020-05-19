using ComputerShop.model.converters;
using System.ComponentModel;

namespace ComputerShop.model.enums
{
	[TypeConverter(typeof(EnumDescriptionTypeConverter))]
	public enum ComputerType
	{
		[Description("Не указан")]
		None,
		[Description("Домашний")]
		Home,
		[Description("Офисный")]
		Office,
		[Description("Игровой")]
		Gaming,
		[Description("Рабочая станция")]
		Workstation
	}
}
