using System.Security.Cryptography;
using System.Text;

namespace ProjetosApp.Domain.Helpers
{
    public class CryptoHelper
    {
        public static string EncryptSHA1(string value)
        {
            using (var sha1 = SHA1.Create())
            {
                var hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(value));

                var result = new StringBuilder();
                foreach (var item in hashBytes)
                    result.Append(item.ToString("x2"));

                return result.ToString();
            }
        }
    }
}
