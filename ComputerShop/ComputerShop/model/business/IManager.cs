using ComputerShop.model.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.model.business
{
	interface IManager<T>
	{
		ComputerShopContext ComputerShopContext { get; set; }
		void AddToDb(T item);
		void DeleteById(int id);
		void ChangeItem(T newItem);
		T GetById(int id);
		IEnumerable<T> FindByPredicate(Predicate<T> predicate);
		void SaveChanges();
	}
}
