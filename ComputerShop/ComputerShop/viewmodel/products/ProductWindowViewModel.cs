using ComputerShop.model.database;
using ComputerShop.model.kindofmagic;
using ComputerShop.model.service.implementations;
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
using System.Windows.Input;
using System.Windows.Media;

namespace ComputerShop.viewmodel.products
{
	public class ProductWindowViewModel<T> : PropertyChangedBase where T: Product
	{
		public ProductWindow CodeBehind { get; set; }
		public T Product { get; set; }
		public ProductService ProductService { get; set; }
		public string ImageSource { get; set; } = "/pictures/none.png";
		public ICommand GetImage { get; set; }
		public ICommand Accept { get; set; }
		public ICommand Cancel { get; set; }

		public ProductWindowViewModel(ProductWindow codeBehind, Product product)
		{
			CodeBehind = codeBehind;
			Product = product as T;
			
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
				ProductService.Add(Product);
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
	}
}
