using ComputerShop.viewmodel.main;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace ComputerShop.view
{
	/// <summary>
	/// Логика взаимодействия для MainList.xaml
	/// </summary>
	public partial class MainList : UserControl
	{
		public MainWindow Owner { get; set; }
		public MainList(MainWindow owner)
		{
			Owner = owner;
			InitializeComponent();
			this.ProductList.ItemsSource = (Owner.DataContext as MainWindowViewModel).ProductRepository.GetAll();
			Loaded += MainList_Loaded;
			this.ProductList.MouseDoubleClick += ItemDoubleClick;

		}

		private void ItemDoubleClick(object sender, MouseButtonEventArgs e)
		{
			(this.DataContext as MainListViewModel).ShowProduct(sender);
		}

		private void MainList_Loaded(object sender, EventArgs e)
		{
			(this.DataContext as MainListViewModel).UpdateButtons();
		}

	}
}
