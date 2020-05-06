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
