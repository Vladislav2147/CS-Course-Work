using ComputerShop.model.repository.implementations;
using ComputerShop.viewmodel.adminTools;
using System.Windows;

namespace ComputerShop.view.adminTools
{
	/// <summary>
	/// Логика взаимодействия для CreateSupplyWindow.xaml
	/// </summary>
	public partial class CreateSupplyWindow : Window
	{
		public new SupplyUC Owner { get; set; }
		public CreateSupplyWindow()
		{
			InitializeComponent();
		}

		public CreateSupplyWindow(SupplyRepository supplyRepository, SupplyUC owner) : this()
		{
			Owner = owner;
			var vm = new CreateSupplyViewModel(supplyRepository, this);
		}
	}
}
