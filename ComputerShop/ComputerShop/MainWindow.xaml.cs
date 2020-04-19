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
using ComputerShop.model.database;
using ComputerShop.model.business;

namespace ComputerShop
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			try
			{
				using (ComputerShopContext computerShopContext = new ComputerShopContext())
				{
					ProductManager productManager = new ProductManager(computerShopContext);

					Computer computer1 = new Computer()
					{
						Id = 3,
						Name = "intel computer",
						Price = 1000,
						Amount = 25,
						Producer = "intel",
						Type = "desktop"
					};
					Computer computer2 = new Computer()
					{
						Id = 4,
						Name = "amd computer",
						Price = 900,
						Amount = 30,
						Producer = "amd",
						Type = "desktop"
					};

					productManager.DeleteById(3);
					productManager.DeleteById(4);
					productManager.SaveChanges();

					productManager.AddToDb(computer1);
					productManager.AddToDb(computer2);
					productManager.SaveChanges();

					foreach (Product product in productManager.FindByPredicate(product => true))
					{
						Console.WriteLine($"{product.Id}\t{product.Name}\t{product.Price}");
					}

					Console.WriteLine("\nproducts with price between 600 and 1200:\n");
					foreach (Product product in productManager.FindByPredicate(product => product.Price < 1200
																						&& product.Price > 600))
					{
						Console.WriteLine($"{product.Id}\t{product.Name}\t{product.Price}");
					}

					Computer computer = productManager.GetById(3) as Computer;
					computer.Amount -= 1;

					productManager.ChangeItem(computer);
					productManager.SaveChanges();

				}
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}

		}
	}
}
