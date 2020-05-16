using ComputerShop.model.service.implementations;
using ComputerShop.viewmodel.adminTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ComputerShop.view.adminTools
{
	/// <summary>
	/// Логика взаимодействия для CreateSupplyWindow.xaml
	/// </summary>
	public partial class CreateSupplyWindow : Window
	{
		public CreateSupplyWindow()
		{
			InitializeComponent();

			//

			var vm = new CreateSupplyViewModel(new SupplyService(), this);

			//
		}
		public CreateSupplyWindow(SupplyService supplyService) : this()
		{
			var vm = new CreateSupplyViewModel(supplyService, this);
		}
	}
}
