using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerShop.database;

namespace ComputerShop.business
{
	class ProductManager : IManager<Product>
	{
		public ComputerShopContext ComputerShopContext { get; set; }

		public ProductManager(ComputerShopContext computerShopContext)
		{
			ComputerShopContext = computerShopContext;
		}

		public void AddToDb(Product item)
		{
			ComputerShopContext.Product.Add(item);
		}

		public void DeleteById(int id)
		{
			ComputerShopContext.Product.Remove(ComputerShopContext.Product.Find(id));
		}

		public void ChangeItem(Product newItem)
		{
			DeleteById(newItem.Id);
			ComputerShopContext.SaveChanges();
			AddToDb(newItem);
		}

		public IEnumerable<Product> FindByPredicate(Predicate<Product> predicate)
		{
			return ComputerShopContext.Product.ToList().FindAll(predicate);
		}

		public Product GetById(int id)
		{
			return ComputerShopContext.Product.Find(id);
		}

		public void SaveChanges()
		{
			ComputerShopContext.SaveChanges();
		}
	}
}
