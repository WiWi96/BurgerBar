using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BurgerBar.Utils
{
    public static class Cryptography
    {
        public static string HashPassword(string password)
        {
            using (SHA512 sha512 = new SHA512Managed())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha512.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
