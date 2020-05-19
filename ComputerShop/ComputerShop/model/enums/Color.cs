using ComputerShop.model.converters;
using System.ComponentModel;

namespace ComputerShop.model.enums
{
	[TypeConverter(typeof(EnumDescriptionTypeConverter))]
	public enum Color
	{
		[Description("Не указан")]
		None,
		[Description("Белый")]
		White,
		[Description("Серый")]
		Grey,
		[Description("Черный")]
		Black,
		[Description("Красный")]
		Red,
		[Description("Синий")]
		Blue,
		[Description("Зеленый")]
		Green,
		[Description("Желтый")]
		Yellow
	}
}
