using ComputerShop.model.database;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
			InitializeComponent();
			Owner = owner;
			List<Product> products = Owner.ComputerShopContext.Product.ToList();
			this.ProductList.ItemsSource = products;
		}

	}
}
