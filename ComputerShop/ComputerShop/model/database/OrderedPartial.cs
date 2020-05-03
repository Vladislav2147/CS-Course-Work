using ComputerShop.model.kindofmagic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.model.database
{
	public partial class Ordered : PropertyChangedBase, IEntity, ICloneable
	{
		public object Clone()
		{
			Ordered ordered = new Ordered()
			{
				ProductId = this.Product.Id,
				OrderId = this.OrderId,
				Amount = this.Amount
			};
			return ordered;
		}
	}
}
