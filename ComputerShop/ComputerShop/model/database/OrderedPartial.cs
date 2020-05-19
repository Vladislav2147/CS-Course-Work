using ComputerShop.model.kindofmagic;
using System;

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
