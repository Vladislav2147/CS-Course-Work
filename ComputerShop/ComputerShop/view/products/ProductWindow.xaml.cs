using ComputerShop.model.database;
using ComputerShop.model.statics;
using ComputerShop.viewmodel.products;
using System;
using System.CodeDom;
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
using Keyboard = ComputerShop.model.database.Keyboard;

namespace ComputerShop.view.products
{
	/// <summary>
	/// Логика взаимодействия для DesktopWindow.xaml
	/// </summary>
	public partial class ProductWindow : Window
	{
		public ProductWindow()
		{
			InitializeComponent();
			Closed += ProductWindow_Closed;
		}

		public ProductWindow(Product product, IProductUC productUC, bool isReadonly = false) : this()
		{
			this.DataContext = new ProductWindowViewModel(this, product);

			if (isReadonly)
			{
				(DataContext as ProductWindowViewModel).UserViewSetup();
			}

			
			this.RestParams.Content = productUC;
		}

		private void ProductWindow_Closed(object sender, EventArgs e)
		{
			(DataContext as ProductWindowViewModel).Close();
		}

	}
}
