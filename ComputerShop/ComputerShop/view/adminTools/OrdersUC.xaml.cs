﻿using ComputerShop.viewmodel.adminTools;
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

namespace ComputerShop.view.adminTools
{
	/// <summary>
	/// Логика взаимодействия для OrdersUC.xaml
	/// </summary>
	public partial class OrdersUC : UserControl
	{
		public OrdersUC()
		{
			InitializeComponent();
			OrdersViewModel ordersVM = new OrdersViewModel(this);
			DataContext = ordersVM;
		}
	}
}