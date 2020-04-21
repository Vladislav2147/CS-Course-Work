using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.model.business
{
	public static class Encryptor
	{
		private static SHA1 sha = new SHA1CryptoServiceProvider();

		public static string GetHash(string password)
		{
			byte[] data = Encoding.ASCII.GetBytes(password);
			byte[] hashData = sha.ComputeHash(data);
			return ASCIIEncoding.ASCII.GetString(hashData);
		}
		public static bool EqualsToHash(this string password, string hash)
		{
			byte[] data = Encoding.ASCII.GetBytes(password);
			byte[] hashData = sha.ComputeHash(data);
			string passwordHash = ASCIIEncoding.ASCII.GetString(hashData);
			return passwordHash.Equals(hash);
		}
	}
}
