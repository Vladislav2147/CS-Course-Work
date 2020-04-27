﻿using System;
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
using ComputerShop.model.enums;
using ComputerShop.model.service.implementations;
using ComputerShop.view.main;

using System.IO;
using Microsoft.Win32;

namespace ComputerShop
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public ProductService ProductService { get; set; }
		public Customer Customer { get; set; }
		public MainWindow()
		{
			InitializeComponent();
			ProductService = new ProductService();			
			MainContent.Content = new UserMainList(this);
			//OpenFileDialog openFileDialog = new OpenFileDialog();
			//if (openFileDialog.ShowDialog() == true)
			//{
			//	System.Drawing.Image image = System.Drawing.Image.FromFile(openFileDialog.FileName);
			//	using (MemoryStream ms = new MemoryStream())
			//	{
			//		image.Save(ms, image.RawFormat);
			//		var products = ProductService.FindByPredicate(prod => prod.Photo == null);
			//		foreach(Product product in products)
			//		{
			//			product.Photo = ms.ToArray();
			//			ProductService.ChangeItem(product);
			//		}
			//		ProductService.SaveChanges();

			//	}

			//}
			//Computer pc = new Computer()
			//{
			//	Id = 8801,
			//	Name = "ppc",
			//	Price = 9000
			//};
			//ProductService.Add(pc);
			//ProductService.SaveChanges();
		}
		public MainWindow(Customer customer) : this()
		{
			Customer = customer;
			if(Customer.Role == Role.Admin)
			{
				this.Cart.Visibility = Visibility.Collapsed;
			}
		}
		
	}
}
