using ComputerShop.model.database;
using ComputerShop.model.kindofmagic;
using ComputerShop.model.service.implementations;
using ComputerShop.model.statics;
using ComputerShop.view.products;
using Microsoft.Win32;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Image = System.Drawing.Image;

namespace ComputerShop.viewmodel.products
{
	public class ProductWindowViewModel : PropertyChangedBase
	{
		public string Title { get; set; } = "Добавить товар";
		public ProductWindow CodeBehind { get; set; }
		[Magic]
		public Product Product { get; set; }
		public bool IsCreatedNow { get; set; } = false;
		public ProductService ProductService { get; set; }
		public string ImageSource { get; set; } = "/pictures/none.png";
		public ICommand GetImage { get; set; }
		public ICommand Accept { get; set; }
		public ICommand Cancel { get; set; }

		public ProductWindowViewModel(ProductWindow codeBehind, Product product)
		{
			CodeBehind = codeBehind;
			if(product.Name == null || product.Name.Length == 0)
			{
				IsCreatedNow = true;
			}
			Product = product;
			ProductService = new ProductService();
			GetImage = new RelayCommand(param => GetImageExecute());
			Accept = new RelayCommand(param => AcceptExecute());
			Cancel = new RelayCommand(param => CancelExecute());
		}

		private void GetImageExecute()
		{
			try
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				if (openFileDialog.ShowDialog() == true)
				{
					Image myImage = Image.FromFile(openFileDialog.FileName);
					using (var ms = new MemoryStream())
					{
						myImage.Save(ms, myImage.RawFormat);
						Product.Photo = ms.ToArray();
					}
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Произошла ошибка получения изображения!");
			}
		}

		private void AcceptExecute()
		{
			try
			{
				if (IsCreatedNow)
				{
					ProductService.Add(Product);
				}		
				ProductService.SaveChanges();
				MessageBox.Show("Продукт успешно добавлен");
				(CodeBehind as Window).Close();
			}
			catch(Exception)
			{
				MessageBox.Show("Ошибка");
			}
		}

		private void CancelExecute()
		{
			(CodeBehind as Window).Close();
		}
		public void UserViewSetup()
		{
			Title = Product.Name;
			CodeBehind.Loaded += ProductWindowLoaded;
			CodeBehind.ProductName.Visibility = Visibility.Collapsed;
			CodeBehind.Amount.Visibility = Visibility.Collapsed;
		}

		private void ProductWindowLoaded(object sender, RoutedEventArgs e)
		{
			ResourceDictionary resource = new ResourceDictionary() { Source = new Uri("view\\products\\ReadonlyProductDictionary.xaml", UriKind.Relative) };
			CodeBehind.Resources.MergedDictionaries.Clear();
			CodeBehind.Resources.MergedDictionaries.Add(resource);
			

			foreach (var textBox in ChildFinder.FindVisualChildren<TextBox>(CodeBehind))
			{
				textBox.Style = resource["BoxStyle"] as Style;
				if (textBox.Text.Length == 0)
				{
					textBox.Text = "-";
				}
			}
			foreach (var comboBox in ChildFinder.FindVisualChildren<ComboBox>(CodeBehind))
			{
				comboBox.Visibility = Visibility.Collapsed;
			}
			foreach (var textblock in ChildFinder.FindVisualChildren<TextBlock>(CodeBehind))
			{
				textblock.Visibility = Visibility.Visible;
			}
			foreach (var button in ChildFinder.FindVisualChildren<Button>(CodeBehind))
			{
				button.Visibility = Visibility.Collapsed;
			}
		}
	}
}
