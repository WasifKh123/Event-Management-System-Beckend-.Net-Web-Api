using System.Security.Cryptography;
using System.Text;
using static System.Console;
namespace EventManagement.Shared
{
    public class CommonMethods
    {
        public static string GetHash(string password)
        {
            SHA256 hash = SHA256.Create();
            var hashedpassword = hash.ComputeHash(Encoding.Default.GetBytes(password));
            return Convert.ToHexString(hashedpassword);
        }
        
    }
}
