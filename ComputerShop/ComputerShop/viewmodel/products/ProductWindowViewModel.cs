using ComputerShop.model.database;
using ComputerShop.model.kindofmagic;
using ComputerShop.model.repository.implementations;
using ComputerShop.model.statics;
using ComputerShop.view.products;
using ComputerShop.viewmodel.main;
using Microsoft.Win32;
using System;
using System.Data.Entity.Validation;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Image = System.Drawing.Image;

namespace ComputerShop.viewmodel.products
{
	public class ProductWindowViewModel : PropertyChangedBase
	{
		public string Title { get; set; } = "Добавить товар";
		public ProductWindow CodeBehind { get; set; }

		public Product Product { get; set; }
		public int ProductId { get; set; }
		public bool IsCreatedNow { get; set; } = false;
		public ProductRepository ProductRepository { get; set; }
		public string ImageSource { get; set; } = "/pictures/none.png";
		public ICommand GetImage { get; set; }
		public ICommand ResetImage { get; set; }
		public ICommand Accept { get; set; }
		public ICommand Cancel { get; set; }

		public ProductWindowViewModel(ProductWindow codeBehind, Product product)
		{
			CodeBehind = codeBehind;
			if (product.Name == null || product.Name.Length == 0)
			{
				IsCreatedNow = true;
			}
			Product = product;
			ProductId = product.Id;
			ProductRepository = new ProductRepository();
			GetImage = new RelayCommand(param => GetImageExecute());
			Accept = new RelayCommand(param => AcceptExecute());
			ResetImage = new RelayCommand(param => Product.Photo = null);
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
				Product.Price = Product.Price < 0 ? 0 : Product.Price;
				if (IsCreatedNow)
				{
					ProductRepository.Add(Product);
				}
				else
				{
					ProductRepository.ChangeItem(Product);
				}
				ProductRepository.SaveChanges();
				MessageBox.Show("Продукт успешно добавлен");
				(CodeBehind as Window).Close();
			}
			catch (DbEntityValidationException ex)
			{
				foreach (var entityValidationErrors in ex.EntityValidationErrors)
				{
					foreach (var validationError in entityValidationErrors.ValidationErrors)
					{
						MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
					}
				}
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

		public void Close()
		{
			try
			{
				if (CodeBehind.Owner as MainWindow != null)
				{
					Product = ProductRepository.GetById(ProductId);
					MainWindowViewModel MainVM = (CodeBehind.Owner as MainWindow).DataContext as MainWindowViewModel;
					MainVM.UpdateMainList(MainVM.GetListOfCurrentType(MainVM.ProductRepository.GetAll()));
				}
			}
			finally
			{
				ProductRepository.Dispose();
			}

		}
	}
}
