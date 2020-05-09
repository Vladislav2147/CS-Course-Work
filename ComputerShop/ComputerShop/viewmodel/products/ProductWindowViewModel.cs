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
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ComputerShop.viewmodel.products
{
	abstract class ProductWindowViewModel<T> : PropertyChangedBase where T: Product
	{
		public IProductWindow<T> CodeBehind { get; set; }
		public T Product { get; set; }
		public ProductService ProductService { get; set; }
		public string ImageSource { get; set; } = "/pictures/none.png";
		public ICommand GetImage { get; set; }
		public ICommand Accept { get; set; }
		public ProductWindowViewModel(IProductWindow<T> codeBehind)
		{ 
			CodeBehind = codeBehind;
			ProductService = new ProductService();
			GetImage = new RelayCommand(param => GetImageExecute());
			Accept = new RelayCommand(param => AcceptExecute());
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

		protected virtual void AcceptExecute()
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


	}
}
