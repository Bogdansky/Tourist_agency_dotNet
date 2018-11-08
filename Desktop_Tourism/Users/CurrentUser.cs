using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_Tourism.Users
{
    static class CurrentUser
    {
        public static string Login { get; set; }

        new public static string ToString()
        {
            return $"Пользователь {Login}";
        }
    }
}
