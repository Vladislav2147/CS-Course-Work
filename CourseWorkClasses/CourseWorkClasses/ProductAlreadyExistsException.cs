using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkClasses
{
	class ProductAlreadyExistsException : ArgumentException
	{
		public ProductAlreadyExistsException(string message) : base(message)
		{

		}
	}
}
