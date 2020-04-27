using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.model.database
{
	public partial class Product : IEntity
	{
		public override string ToString()
		{
			StringBuilder description = new StringBuilder();
			if(Year != null)
			{
				description.Append($"Год выпуска: {this.Year} ");
			}
			return description.ToString();
		}
	}
}
