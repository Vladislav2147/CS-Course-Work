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
using ComputerShop.model.database;
using ComputerShop.model.business;
using ComputerShop.view;

namespace ComputerShop
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public ComputerShopContext ComputerShopContext;
		public ProductManager ProductManager { get; set; }
		public MainWindow()
		{
			InitializeComponent();
			ComputerShopContext = new ComputerShopContext();
			ProductManager = new ProductManager(ComputerShopContext);
			
			MainContent.Content = new MainList(this);
		}
	}
}
