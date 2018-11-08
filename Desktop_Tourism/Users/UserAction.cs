using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Desktop_Tourism.Users
{
    static class UserAction
    {
        private static readonly System.Data.SqlClient.SqlParameter parameterRole = new System.Data.SqlClient.SqlParameter("@role", "stuff");
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static async Task<bool> Login(string login, string password)
        {
            string procedureName = "sign_in";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand storedProcedure = ConfigureProcedure(GetParameters(login, password), procedureName, connection);
                int count = (int)storedProcedure.ExecuteScalar();
                return count > 0;
            }
        }

        public static async Task<bool> SignUp(string login, string password)
        {
            string procedureName = "sign_up";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand storedProcedure = ConfigureProcedure(GetParameters(login, password), procedureName, connection);
                int count = (int)storedProcedure.ExecuteScalar();
                return count > 0;
            }
        }

        private static SqlCommand ConfigureProcedure(SqlParameter[] parameters, string procedureName, SqlConnection connection)
        {
            SqlCommand storedProcedure = new SqlCommand(procedureName, connection);
            storedProcedure.CommandType = System.Data.CommandType.StoredProcedure;
            storedProcedure.Parameters.AddRange(parameters);
            return storedProcedure;
        }

        private static SqlParameter[] GetParameters(string login, string password)
        {
            SqlParameter[] parameters = new SqlParameter[] { GetLoginParameter(login), GetPasswordParameter(login, password), GetRoleParameter(login) };
            return parameters;
        }

        private static SqlParameter GetLoginParameter(string login)
        {
            return new SqlParameter
            {
                ParameterName = "@login",
                Value = login
            };
        }

        private static SqlParameter GetPasswordParameter(string login, string password)
        {
            return new SqlParameter
            {
                ParameterName = "@password",
                Value = Validation.GetHash(password,login)
            };
        }

        private static SqlParameter GetRoleParameter(string login)
        {
            return new SqlParameter
            {
                ParameterName = "@role",
                Value = "staff"
            };
        }
    }
}
