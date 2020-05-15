using ComputerShop.model.database;
using ComputerShop.model.kindofmagic;
using ComputerShop.model.service.implementations;
using ComputerShop.view.adminTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.viewmodel.adminTools
{
	class SupplyViewModel : PropertyChangedBase
	{
		public List<Supply> Supplies { get; set; }
		public SupplyService SupplyService { get; set; }
		public SupplyUC CodeBehind { get; set; }

		public SupplyViewModel(SupplyUC codeBehind)
		{
			CodeBehind = codeBehind;
			SupplyService = new SupplyService();
			Supplies = SupplyService.GetAll();
		}
	}
}
