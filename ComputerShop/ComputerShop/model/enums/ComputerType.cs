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
