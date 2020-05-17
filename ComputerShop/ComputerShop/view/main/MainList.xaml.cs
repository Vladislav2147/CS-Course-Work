﻿using ComputerShop.model.database;
using ComputerShop.view.products;
using ComputerShop.viewmodel.main;
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
