using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desktop_Tourism.Model;

namespace Desktop_Tourism.Users
{
    static class UserAction
    {
        private static System.Data.SqlClient.SqlParameter parameterRole = new System.Data.SqlClient.SqlParameter("@role", "stuff");

        public static bool Login(string login, string password)
        {
            using (Context db = new Context())
            {
                System.Data.SqlClient.SqlParameter parameterLogin = new System.Data.SqlClient.SqlParameter("@login", login);
                System.Data.SqlClient.SqlParameter parameterPassword = new System.Data.SqlClient.SqlParameter("@password", Validation.GetHash(password,login));
                return db.Database.SqlQuery<int>("sign_in @login,@password,@role", parameterLogin, parameterPassword,parameterRole).First() != 0;
            }
        }
        
        public static bool SignUp(string login, string password)
        {
            using (Context db = new Context())
            {
                System.Data.SqlClient.SqlParameter parameterLogin = new System.Data.SqlClient.SqlParameter("@login", login);
                System.Data.SqlClient.SqlParameter parameterPassword = new System.Data.SqlClient.SqlParameter("@password", Validation.GetHash(password, login));
                return db.Database.SqlQuery<string>("sign_up @login,@password,@role", parameterLogin, parameterPassword, parameterRole).First() == "success";
            }
        }
    }
}
