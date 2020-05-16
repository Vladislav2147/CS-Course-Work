﻿using ComputerShop.model.database;
using ComputerShop.model.service.implementations;
using ComputerShop.view.adminTools;
using ComputerShop.view.products;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Keyboard = ComputerShop.model.database.Keyboard;
using Mouse = ComputerShop.model.database.Mouse;

namespace ComputerShop.viewmodel.adminTools
{
	class CreateSupplyViewModel
	{
		public SupplyService SupplyService { get; set; }
		public CreateSupplyWindow CodeBehind { get; set; }
		public Supply CreatedSupply { get; set; }
		public List<DeliveredToWareHouse> Delivered { get; set; }
		public object ProductType { get; set; }
		public DateTime Date { get; set; }
		public DateTime Time { get; set; }

		public ICommand CreateProduct { get; set; }
		public ICommand Accept { get; set; }


		public CreateSupplyViewModel(SupplyService supplyService, CreateSupplyWindow codeBehind)
		{
			codeBehind.DataContext = this;
			SupplyService = supplyService;
			CodeBehind = codeBehind;
			CreatedSupply = new Supply();
			Delivered = new List<DeliveredToWareHouse>();
			CreateProduct = new RelayCommand(param => ExecuteCreateProduct());
			Accept = new RelayCommand(param => ExecuteAccept());
			Time = DateTime.Now;
			Date = DateTime.Now;
		}

		private void ExecuteCreateProduct()
		{
			string type = (ProductType as ComboBoxItem).Content.ToString();
			ProductWindow productWindow = new ProductWindow();
			switch (type)
			{
				case "Настольный пк":
					productWindow = new ProductWindow(new Desktop(), new DesktopUC());
					break;
				case "Ноутбук":
					productWindow = new ProductWindow(new Laptop(), new LaptopUC());
					break;
				case "Моноблок":
					productWindow = new ProductWindow(new Monoblock(), new MonoblockUC());
					break;
				case "Клавиатура":
					productWindow = new ProductWindow(new Keyboard(), new KeyboardUC());
					break;
				case "Мышь":
					productWindow = new ProductWindow(new Mouse(), new MouseUC());
					break;
			}

			productWindow.Show();

		}

		private void ExecuteAccept()
		{
			if(Delivered.Count > 0 && Delivered.First().ProductId != 0)
			{
				try
				{
					Date = Date.Date;
					Date = Date.AddHours(Time.Hour);
					Date = Date.AddMinutes(Time.Minute);
					if (Date > DateTime.Now)
					{
						Date = DateTime.Now;
					}
					CreatedSupply.Date = Date;
					CreatedSupply.DeliveredToWareHouse = Delivered;
					SupplyService.Add(CreatedSupply);
					SupplyService.SaveChanges();
					(CodeBehind.Owner.DataContext as SupplyViewModel).Update();
					CodeBehind.Close();
				}
				catch (Exception)
				{
					MessageBox.Show("Непредвиденная ошибка");
				}
			}
			else
			{
				MessageBox.Show("Таблица не может быть пустой или содержать нулевые значения");
			}
		}
	}
}
