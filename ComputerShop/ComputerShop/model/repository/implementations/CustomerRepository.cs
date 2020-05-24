using ComputerShop.model.business;
using ComputerShop.model.database;

namespace ComputerShop.model.repository.implementations
{
	public class CustomerRepository : AbstractRepository<Customer>
	{
		public CustomerRepository() : base() { }
		public CustomerRepository(ComputerShopContext context) : base(context) { }

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
			customer.Role = enums.Role.User;
			Add(customer);
		}
	}

}
