using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Tijarat.models
{
    public class CRUD
    {
        public static SqlDataReader getCustomers()
        {
            string connectionString = @"Data Source=AMMAR;Initial Catalog=Store;Integrated Security=True;";
            string query = "SELECT * FROM Customer";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static int isLoggedIn(string email, string password)
        {
            string connectionString = @"Data Source=AMMAR;Initial Catalog=Store;Integrated Security=True;";
            string query = "loginUser";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter();
            param = cmd.Parameters.Add("@email", SqlDbType.VarChar, 100);
            param.Value = email;
            param = cmd.Parameters.Add("@pwd", SqlDbType.VarChar, 100);
            param.Value = password;

            SqlParameter outputParam = cmd.Parameters.Add("@user", SqlDbType.Int);
            outputParam.Direction = ParameterDirection.Output;
            outputParam.Value = null;
            try
            {
                connection.Open();
                int r = cmd.ExecuteNonQuery();
                int output = Convert.ToInt32(cmd.Parameters["@user"].Value);
                if(output == 0)
                {
                    return 0;
                }
                else
                {
                    return output;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        public static int isRegistered(String Username, String Address, String Phone, String Date, String Email, String Pwd)
        {
            string connectionString = @"Data Source=AMMAR;Initial Catalog=Store;Integrated Security=True;";
            string query = "RegisterCustomer";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter();
            param = cmd.Parameters.Add("@n", SqlDbType.VarChar, 30);
            param.Value = Username;
            param = cmd.Parameters.Add("@adr", SqlDbType.VarChar, 200);
            param.Value = Address;
            param = cmd.Parameters.Add("@doB", SqlDbType.Date);
            param.Value = Date;
            param = cmd.Parameters.Add("@p", SqlDbType.VarChar, 20);
            param.Value = Phone;
            param = cmd.Parameters.Add("@email", SqlDbType.VarChar, 100);
            param.Value = Email;
            param = cmd.Parameters.Add("@pwd", SqlDbType.VarChar, 100);
            param.Value = Pwd;

            SqlParameter outputParam = cmd.Parameters.Add("@exists", SqlDbType.Int);
            outputParam.Direction = ParameterDirection.Output;
            outputParam.Value = null;
            try
            {
                connection.Open();
                int r = cmd.ExecuteNonQuery();
                int output = Convert.ToInt32(cmd.Parameters["@exists"].Value);
                if (output > 1)
                {
                    return output;
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 1;
            }
        }

        public static SqlDataReader getProducts()
        {
            string connectionString = @"Data Source=AMMAR;Initial Catalog=Store;Integrated Security=True;";
            string query = "SELECT * FROM Product";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static SqlDataReader getUserName(int ID)
        {
            string connectionString = @"Data Source=AMMAR;Initial Catalog=Store;Integrated Security=True;";
            string query = "getUserName";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter();
            param = cmd.Parameters.Add("@uID", SqlDbType.Int);
            param.Value = ID;
            try
            {
                connection.Open();
                SqlDataReader r = cmd.ExecuteReader();
                return r;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static SqlDataReader Search(string product)
        {
            string connectionString = @"Data Source=AMMAR;Initial Catalog=Store;Integrated Security=True;";
            string query = "Search";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter();
            param = cmd.Parameters.Add("@prod", SqlDbType.VarChar, 40);
            param.Value = product;
            try
            {
                connection.Open();
                SqlDataReader r = cmd.ExecuteReader();
                return r;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public static SqlDataReader SearchByCategory(string category)
        {
            string connectionString = @"Data Source=AMMAR;Initial Catalog=Store;Integrated Security=True;";
            string query = "SearchByCategory";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter();
            param = cmd.Parameters.Add("@cat", SqlDbType.VarChar, 40);
            param.Value = category;
            try
            {
                connection.Open();
                SqlDataReader r = cmd.ExecuteReader();
                return r;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}