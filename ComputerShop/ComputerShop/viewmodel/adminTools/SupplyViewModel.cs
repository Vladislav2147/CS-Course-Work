using ComputerShop.model.database;
using ComputerShop.model.kindofmagic;
using ComputerShop.model.repository.implementations;
using ComputerShop.view.adminTools;
using System.Collections.Generic;
using System.Windows.Input;

namespace ComputerShop.viewmodel.adminTools
{
	class SupplyViewModel : PropertyChangedBase
	{
		public List<Supply> Supplies { get; set; }
		public SupplyRepository SupplyRepository { get; set; }
		public SupplyUC View { get; set; }

		public ICommand CreateCommand { get; set; }
		public ICommand RemoveCommand { get; set; }

		public SupplyViewModel(SupplyUC view)
		{
			View = view;
			SupplyRepository = new SupplyRepository();
			Supplies = SupplyRepository.GetAll();

			CreateCommand = new RelayCommand(param => Create());
			RemoveCommand = new RelayCommand(param => Remove());
		}

		private void Create()
		{
			var createWindow = new CreateSupplyWindow(SupplyRepository, View);
			createWindow.Show();
		}
		private void Remove()
		{
			SupplyRepository.RemoveById((View.DataSupplies.SelectedItem as Supply).Id);
			SupplyRepository.SaveChanges();
			Update();
		}

		public void Update() => Supplies = SupplyRepository.GetAll();
	}
}
