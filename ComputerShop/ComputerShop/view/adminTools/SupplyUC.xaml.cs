using ComputerShop.viewmodel.adminTools;
using System.Windows.Controls;

namespace ComputerShop.view.adminTools
{
	/// <summary>
	/// Логика взаимодействия для SupplyUC.xaml
	/// </summary>
	public partial class SupplyUC : UserControl
	{
		public SupplyUC()
		{
			InitializeComponent();
			this.DataContext = new SupplyViewModel(this);
		}
	}
}
