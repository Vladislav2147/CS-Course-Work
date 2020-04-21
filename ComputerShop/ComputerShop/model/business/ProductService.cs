using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerShop.model.database;

namespace ComputerShop.model.business
{
	public class ProductService : IService<Product>
	{
		public ComputerShopContext ComputerShopContext { get; set; }

		public ProductService(ComputerShopContext computerShopContext)
		{
			ComputerShopContext = computerShopContext;
		}
		public ProductService()
		{
			ComputerShopContext = new ComputerShopContext();
		}

		public void Add(Product item)
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
			Add(newItem);
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
