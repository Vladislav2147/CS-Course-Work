using ComputerShop.viewmodel.adminTools;
using System.Windows.Controls;

namespace ComputerShop.view.adminTools
{
	/// <summary>
	/// Логика взаимодействия для StatsUC.xaml
	/// </summary>
	public partial class StatsUC : UserControl
	{
		public StatsUC()
		{
			InitializeComponent();
			StatsViewModel vm = new StatsViewModel(this);
			DataContext = vm;
		}
	}
}
