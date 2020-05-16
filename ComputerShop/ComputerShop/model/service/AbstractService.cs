using ComputerShop.model.database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.model.service
{
	public abstract class AbstractService<T> : IDisposable where T: IEntity, new()
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
		public virtual List<T> GetAll()
		{
			return ComputerShopContext.GetEntity<T>().AsNoTracking().Cast<T>().ToList();
		}
		public virtual void Add(T item)
		{
			ComputerShopContext.GetEntity<T>().Add(item);
		}

		public virtual void Remove(T item)
		{
			ComputerShopContext.GetEntity<T>().Remove(item);
		}

		public virtual void RemoveById(int id)
		{
			T t = FindByPredicate(item => item.Id == id).FirstOrDefault();
			ComputerShopContext.GetEntity<T>().Remove(t);
		}

		public virtual void ChangeItem(T newItem)
		{
			Remove(GetById(newItem.Id));
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

		public void Dispose()
		{
			ComputerShopContext.Dispose();
		}
	}
}
