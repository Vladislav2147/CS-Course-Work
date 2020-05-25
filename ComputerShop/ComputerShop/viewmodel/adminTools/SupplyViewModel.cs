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

		public ICommand Create { get; set; }
		public ICommand Remove { get; set; }

		public SupplyViewModel(SupplyUC view)
		{
			View = view;
			SupplyRepository = new SupplyRepository();
			Supplies = SupplyRepository.GetAll();

			Create = new RelayCommand(param => CreateExecute());
			Remove = new RelayCommand(param => RemoveExecute());
		}

		private void CreateExecute()
		{
			var createWindow = new CreateSupplyWindow(SupplyRepository, View);
			createWindow.Show();
		}
		private void RemoveExecute()
		{
			SupplyRepository.RemoveById((View.DataSupplies.SelectedItem as Supply).Id);
			SupplyRepository.SaveChanges();
			Update();
		}

		public void Update() => Supplies = SupplyRepository.GetAll();
	}
}
