using ComputerShop.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ComputerShop.viewmodel.main
{
	class MainListViewModel
	{
		public MainList CodeBehind { get; set; }
		public ICommand AddToCart { get; set; }
		public MainListViewModel(MainList codeBehind)
		{
			CodeBehind = codeBehind;
			AddToCart = new RelayCommand(param => ExecuteAddToCart());
		}
		private void ExecuteAddToCart()
		{
			MessageBox.Show("ex");
		}
	}
}
