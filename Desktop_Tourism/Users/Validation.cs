using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desktop_Tourism.Model;

namespace Desktop_Tourism.Users
{
    public static class Validation
    {
        public static byte[] GetHash(string word, string key)
        {
            using (HMACSHA256 hmac = new HMACSHA256(Encoding.ASCII.GetBytes(key)))
            {
                return hmac.ComputeHash(Encoding.ASCII.GetBytes(word));
            }
        }
    }
}
