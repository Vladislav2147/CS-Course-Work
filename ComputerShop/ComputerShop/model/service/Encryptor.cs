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
			var utf8 = new UTF8Encoding();
			byte[] bytePassword = utf8.GetBytes(password);
			byte[] hashData = sha.ComputeHash(bytePassword);
			return utf8.GetString(hashData);
		}
		public static bool EqualsToHash(this string password, string hash)
		{
			var utf8 = new UTF8Encoding();
			byte[] data = utf8.GetBytes(password);
			byte[] hashData = sha.ComputeHash(data);
			string passwordHash = utf8.GetString(hashData);
			return passwordHash.Equals(hash);
		}
	}
}
