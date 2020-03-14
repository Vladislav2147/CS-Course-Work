using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkClasses.Products.Computer
{
	/*abstract*/ class Computer : Product
	{
		public string Producer { get; set; }
		public ComputerType Type { get; set; }
		public string Processor { get; set; }
		public string RAM { get; set; }
		public string HardDrive { get; set; }
		public string OpticalDrive { get; set; }
		public string GraphicsCard { get; set; }

	}
}
