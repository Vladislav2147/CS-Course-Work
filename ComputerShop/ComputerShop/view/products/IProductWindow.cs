using ComputerShop.model.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.view.products
{
	interface IProductWindow<T> where T: Product
	{
		T Product { get; set; }
	}
}
