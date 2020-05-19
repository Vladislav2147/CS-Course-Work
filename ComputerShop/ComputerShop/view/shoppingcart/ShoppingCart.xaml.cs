using System.Windows.Controls;

namespace ComputerShop.view.shoppingcart
{
	/// <summary>
	/// Логика взаимодействия для ShoppingCart.xaml
	/// </summary>
	public partial class ShoppingCart : UserControl
	{
		public MainWindow Owner { get; set; }

		public ShoppingCart(MainWindow owner)
		{
			this.Owner = owner;
			InitializeComponent();

		}


	}
}
