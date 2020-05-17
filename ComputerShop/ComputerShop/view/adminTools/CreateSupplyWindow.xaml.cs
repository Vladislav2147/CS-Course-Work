﻿using ComputerShop.model.repository.implementations;
using ComputerShop.viewmodel.adminTools;
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
using System.Windows.Shapes;

namespace ComputerShop.view.adminTools
{
	/// <summary>
	/// Логика взаимодействия для CreateSupplyWindow.xaml
	/// </summary>
	public partial class CreateSupplyWindow : Window
	{
		public new SupplyUC Owner { get; set; }
		public CreateSupplyWindow()
		{
			InitializeComponent();
		}

		public CreateSupplyWindow(SupplyRepository supplyRepository, SupplyUC owner) : this()
		{
			Owner = owner;
			var vm = new CreateSupplyViewModel(supplyRepository, this);
		}
	}
}