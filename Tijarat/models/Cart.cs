using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Tijarat.models
{
    public class Cart
    {
        public class Product {
            public int ID { get; set; }
            public string product { get; set; }
            public int qty { get; set; }
        }

        public static SqlDataReader orderProduct(int id, int qty)
        {
            SqlDataReader r;

            string connectionString = @"Data Source=AMMAR;Initial Catalog=Store;Integrated Security=True;";

            string query = "getAProduct";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter();
            param = cmd.Parameters.Add("@id", SqlDbType.Int);
            param.Value = id;
            param = cmd.Parameters.Add("@qty", SqlDbType.Int);
            param.Value = qty;

            SqlParameter outputParam = cmd.Parameters.Add("@ret", SqlDbType.Int);
            outputParam.Direction = ParameterDirection.Output;
            outputParam.Value = null;
            try
            {
                connection.Open();
                r = cmd.ExecuteReader();
                int output = Convert.ToInt32(cmd.Parameters["@ret"].Value);
                if (output == 1)
                {
                    return null;
                }
                else
                {
                    return r;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        public static void generateOrder(int ordID, int uID, string st)
        {

            string connectionString = @"Data Source=AMMAR;Initial Catalog=Store;Integrated Security=True;";

            string query = "generateOrder";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter();
            param = cmd.Parameters.Add("@ordID", SqlDbType.Int);
            param.Value = ordID;
            param = cmd.Parameters.Add("@uID", SqlDbType.Int);
            param.Value = uID;
            param = cmd.Parameters.Add("@st", SqlDbType.VarChar, 20);
            param.Value = st;
            
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static void generateItemOrder(int itemNo, int ordID, int prodID, int qty)
        {

            string connectionString = @"Data Source=AMMAR;Initial Catalog=Store;Integrated Security=True;";

            string query = "generateItemOrder";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter();
            param = cmd.Parameters.Add("@itemNo", SqlDbType.Int);
            param.Value = itemNo;
            param = cmd.Parameters.Add("@ordNo", SqlDbType.Int);
            param.Value = ordID;
            param = cmd.Parameters.Add("@prodID", SqlDbType.Int);
            param.Value = prodID;
            param = cmd.Parameters.Add("@qty", SqlDbType.Int);
            param.Value = qty;

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}