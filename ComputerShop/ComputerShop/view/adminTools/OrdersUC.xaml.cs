using ComputerShop.viewmodel.adminTools;
using System.Windows.Controls;

namespace ComputerShop.view.adminTools
{
	/// <summary>
	/// Логика взаимодействия для OrdersUC.xaml
	/// </summary>
	public partial class OrdersUC : UserControl
	{
		public OrdersUC()
		{
			InitializeComponent();
			OrdersViewModel ordersVM = new OrdersViewModel(this);
			DataContext = ordersVM;
		}
	}
}
