using ComputerShop.model.kindofmagic;
using System.Text;

namespace ComputerShop.model.database
{
	public partial class Product : PropertyChangedBase, IEntity
	{
		public override string ToString()
		{
			StringBuilder description = new StringBuilder();
			if (Year != null)
			{
				description.Append($"Год выпуска: {this.Year} ");
			}
			return description.ToString();
		}
	}
}
