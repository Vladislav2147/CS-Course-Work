using ComputerShop.model.business;
using ComputerShop.model.database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.model.service.implementations
{
	class CustomerService : AbstractService<Customer>
	{
		public CustomerService() : base() { }
		public CustomerService(ComputerShopContext context) : base(context) { }
		public byte[] HashPassword(string password)
		{
			return Encryptor.GetHash(password);
		}
		public bool HashEquals(string password, byte[] passwordHash)
		{
			return password.EqualsToHash(passwordHash);
		}
		public void RegistrateCustomer(Customer customer)
		{
			customer.Role = "USER";
			Add(customer);
		}
	}
	
}
