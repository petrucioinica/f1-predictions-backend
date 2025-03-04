using System.Security.Cryptography;
using System.Text;

namespace f1_predictions.Core
{
    internal static class Helpers
    {

        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }
    }
}