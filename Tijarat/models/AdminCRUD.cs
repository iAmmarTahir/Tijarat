using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Tijarat.models
{
    public class AdminCRUD
    {
        public static int isAdminLoggedIn(string email, string password)
        {
            string connectionString = @"Data Source=AMMAR;Initial Catalog=Store;Integrated Security=True;";
            string query = "adminLogin";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter();
            param = cmd.Parameters.Add("@email", SqlDbType.VarChar, 40);
            param.Value = email;
            param = cmd.Parameters.Add("@pwd", SqlDbType.VarChar, 100);
            param.Value = password;

            SqlParameter outputParam = cmd.Parameters.Add("@ret", SqlDbType.Int);
            outputParam.Direction = ParameterDirection.Output;
            outputParam.Value = null;
            try
            {
                connection.Open();
                int r = cmd.ExecuteNonQuery();
                int output = Convert.ToInt32(cmd.Parameters["@ret"].Value);
                if (output == 0)
                {
                    return 0;
                }
                else
                {
                    return output;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
        public static int getOrdersCount()
        {
            string connectionString = @"Data Source=AMMAR;Initial Catalog=Store;Integrated Security=True;";
            string query = "ordersPending";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter outputParam = cmd.Parameters.Add("@orders", SqlDbType.Int);
            outputParam.Direction = ParameterDirection.Output;
            outputParam.Value = null;
            try
            {
                connection.Open();
                int r = cmd.ExecuteNonQuery();
                int output = Convert.ToInt32(cmd.Parameters["@orders"].Value);
                if (output == 0)
                {
                    return 0;
                }
                else
                {
                    return output;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        public static int getAdsCount()
        {
            string connectionString = @"Data Source=AMMAR;Initial Catalog=Store;Integrated Security=True;";
            string query = "adsPosted";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter outputParam = cmd.Parameters.Add("@ads", SqlDbType.Int);
            outputParam.Direction = ParameterDirection.Output;
            outputParam.Value = null;
            try
            {
                connection.Open();
                int r = cmd.ExecuteNonQuery();
                int output = Convert.ToInt32(cmd.Parameters["@ads"].Value);
                if (output == 0)
                {
                    return 0;
                }
                else
                {
                    return output;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        public static int getProductsCount()
        {
            string connectionString = @"Data Source=AMMAR;Initial Catalog=Store;Integrated Security=True;";
            string query = "totalProducts";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter outputParam = cmd.Parameters.Add("@products", SqlDbType.Int);
            outputParam.Direction = ParameterDirection.Output;
            outputParam.Value = null;
            try
            {
                connection.Open();
                int r = cmd.ExecuteNonQuery();
                int output = Convert.ToInt32(cmd.Parameters["@products"].Value);
                if (output == 0)
                {
                    return 0;
                }
                else
                {
                    return output;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        public static SqlDataReader getOrderDetails()
        {
            string connectionString = @"Data Source=AMMAR;Initial Catalog=Store;Integrated Security=True;";
            string query = "SELECT * FROM OrderDetails";
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

        public static void updateStatusOfOrder(int ID)
        {
            string connectionString = @"Data Source=AMMAR;Initial Catalog=Store;Integrated Security=True;";
            string query = "UpdateOrderStatus";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param = cmd.Parameters.Add("@ordID", SqlDbType.Int);
            param.Value = ID;

            try
            {
                connection.Open();
                int r = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static SqlDataReader getAdsDetails()
        {
            string connectionString = @"Data Source=AMMAR;Initial Catalog=Store;Integrated Security=True;";
            string query = "getAdsDetails";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandType = CommandType.StoredProcedure;
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

        public static void DeleteAds(int ID)
        {
            string connectionString = @"Data Source=AMMAR;Initial Catalog=Store;Integrated Security=True;";
            string query = "deleteAd";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter();
            param = cmd.Parameters.Add("@id", SqlDbType.Int);
            param.Value = ID;
            try
            {
                connection.Open();
                int r = cmd.ExecuteNonQuery();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
        }

        public static int CreateAd(int adID, int adminID, string product, string adContent, string imgUrl)
        {
            string connectionString = @"Data Source=AMMAR;Initial Catalog=Store;Integrated Security=True;";
            string query = "insertAd";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter();

            param = cmd.Parameters.Add("@adID", SqlDbType.Int);
            param.Value = adID;

            param = cmd.Parameters.Add("@admID", SqlDbType.Int);
            param.Value = adminID;

            param = cmd.Parameters.Add("@prod", SqlDbType.VarChar, 40);
            param.Value = product;

            param = cmd.Parameters.Add("@adCont", SqlDbType.VarChar, 500);
            param.Value = adContent;

            param = cmd.Parameters.Add("@adImg", SqlDbType.VarChar, 1000);
            param.Value = imgUrl;



            SqlParameter outputParam = cmd.Parameters.Add("@ret", SqlDbType.Int);
            outputParam.Direction = ParameterDirection.Output;
            outputParam.Value = null;
            try
            {
                connection.Open();
                int r = cmd.ExecuteNonQuery();
                int output = Convert.ToInt32(cmd.Parameters["@ret"].Value);
                
                    return output;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        public static SqlDataReader GetProductDetails()
        {
            string connectionString = @"Data Source=AMMAR;Initial Catalog=Store;Integrated Security=True;";
            string query = "getProductDetails";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandType = CommandType.StoredProcedure;
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

        public static void DeleteProducts(int ID)
        {
            string connectionString = @"Data Source=AMMAR;Initial Catalog=Store;Integrated Security=True;";
            string query = "deleteProduct";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter();
            param = cmd.Parameters.Add("@prodID", SqlDbType.Int);
            param.Value = ID;
            try
            {
                connection.Open();
                int r = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }

        public static int CreateProduct(int prodID, string name, string imgUrl, string desc, int price, string category, int qty)
        {
            string connectionString = @"Data Source=AMMAR;Initial Catalog=Store;Integrated Security=True;";
            string query = "addProduct";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter();

            param = cmd.Parameters.Add("@prodID", SqlDbType.Int);
            param.Value = prodID;

            param = cmd.Parameters.Add("@name", SqlDbType.VarChar, 40);
            param.Value = name;

            param = cmd.Parameters.Add("@img", SqlDbType.VarChar, 1000);
            param.Value = imgUrl;

            param = cmd.Parameters.Add("@desc", SqlDbType.VarChar, 1000);
            param.Value = desc;

            param = cmd.Parameters.Add("@price", SqlDbType.Int);
            param.Value = price;

            param = cmd.Parameters.Add("@cat", SqlDbType.VarChar, 1000);
            param.Value = category;

            param = cmd.Parameters.Add("@qty", SqlDbType.Int);
            param.Value = qty;



            SqlParameter outputParam = cmd.Parameters.Add("@ret", SqlDbType.Int);
            outputParam.Direction = ParameterDirection.Output;
            outputParam.Value = null;
            try
            {
                connection.Open();
                int r = cmd.ExecuteNonQuery();
                int output = Convert.ToInt32(cmd.Parameters["@ret"].Value);

                return output;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        public static SqlDataReader GetCategories()
        {
            string connectionString = @"Data Source=AMMAR;Initial Catalog=Store;Integrated Security=True;";
            string query = "getCategories";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandType = CommandType.StoredProcedure;
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

        public static void CreateCategory(int catID, string catName)
        {
            string connectionString = @"Data Source=AMMAR;Initial Catalog=Store;Integrated Security=True;";
            string query = "addCategory";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter();

            param = cmd.Parameters.Add("@cat", SqlDbType.Int);
            param.Value = catID;

            param = cmd.Parameters.Add("@catName", SqlDbType.VarChar, 75);
            param.Value = catName;

    
            try
            {
                connection.Open();
                int r = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}