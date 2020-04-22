using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.model.business
{
	public static class Encryptor
	{
		private static SHA1 sha = new SHA1CryptoServiceProvider();

		public static byte[] GetHash(string password)
		{
			var utf8 = new UTF8Encoding();
			byte[] bytePassword = utf8.GetBytes(password);
			byte[] hashData = sha.ComputeHash(bytePassword);
			return hashData;
		}
		public static bool EqualsToHash(this string password, byte[] hash)
		{
			var utf8 = new UTF8Encoding();
			byte[] data = utf8.GetBytes(password);
			byte[] hashData = sha.ComputeHash(data);

			if(hashData.Length == hash.Length)
			{
				for(int i = 0; i < hash.Length; i++)
				{
					if(hashData[i] != hash[i])
					{
						return false;
					}
				}
			}
			return true;
		}
	}
}
