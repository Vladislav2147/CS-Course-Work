using ComputerShop.model.kindofmagic;
using System;

namespace ComputerShop.model.database
{
	public partial class Order : PropertyChangedBase, IEntity, ICloneable
	{
		public object Clone()
		{
			Order order = new Order()
			{
				Date = this.Date,
				Address = this.Address,
				Phone = this.Phone,
				State = this.State,
				CustomerId = this.CustomerId
			};
			foreach (Ordered ordered in this.Ordered)
			{
				order.Ordered.Add((Ordered)ordered.Clone());
			}
			return order;
		}
	}
}
