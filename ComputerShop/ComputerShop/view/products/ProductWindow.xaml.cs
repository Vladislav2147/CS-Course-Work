using ComputerShop.model.database;
using ComputerShop.viewmodel.products;
using System;
using System.Windows;

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
