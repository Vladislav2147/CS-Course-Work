using ComputerShop.model.database;
using ComputerShop.model.kindofmagic;
using ComputerShop.model.service.implementations;
using ComputerShop.view.adminTools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ComputerShop.viewmodel.adminTools
{
	class SupplyViewModel : PropertyChangedBase
	{
		public List<Supply> Supplies { get; set; }
		public SupplyService SupplyService { get; set; }
		public SupplyUC CodeBehind { get; set; }

		public ICommand CreateCommand { get; set; }
		public ICommand RemoveCommand { get; set; }

		public SupplyViewModel(SupplyUC codeBehind)
		{
			CodeBehind = codeBehind;
			SupplyService = new SupplyService();
			Supplies = SupplyService.GetAll();

			CreateCommand = new RelayCommand(param => Create());
			RemoveCommand = new RelayCommand(param => Remove());
		}
		
		private void Create()
		{
			var createWindow = new CreateSupplyWindow(SupplyService, CodeBehind);
			createWindow.Show();
		}
		private void Remove()
		{
			SupplyService.RemoveById((CodeBehind.DataSupplies.SelectedItem as Supply).Id);
			SupplyService.SaveChanges();
			Update();
		}

		public void Update() => Supplies = SupplyService.GetAll();
	}
}
