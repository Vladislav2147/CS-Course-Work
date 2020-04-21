using ComputerShop.model.database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.model.service
{
	class AbstractService<T> where T: IEntity, new()
	{
		public ComputerShopContext ComputerShopContext { get; set; }

		public AbstractService(ComputerShopContext computerShopContext)
		{
			ComputerShopContext = computerShopContext;
		}
		public AbstractService()
		{
			ComputerShopContext = new ComputerShopContext();
		}

		public void Add(T item)
		{
			ComputerShopContext.GetEntity<T>().Add(item);
		}

		public void DeleteById(int id)
		{
			ComputerShopContext.GetEntity<T>().Remove(ComputerShopContext.GetEntity<T>().Find(id));
		}

		public void ChangeItem(T newItem)
		{
			DeleteById(newItem.Id);
			ComputerShopContext.SaveChanges();
			Add(newItem);
		}

		public IEnumerable<T> FindByPredicate(Predicate<T> predicate)
		{
			return ComputerShopContext.GetEntity<T>().Cast<T>().ToList().FindAll(predicate);
		}

		public T GetById(int id)
		{
			return (T)ComputerShopContext.GetEntity<T>().Find(id);
		}

		public void SaveChanges()
		{
			ComputerShopContext.SaveChanges();
		}
	}
}
