using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;

namespace ye
{
    class Product
    {
        private static string connect_Str = @"Data Source=LAPTOP-77AKUU80\SQLEXPRESS;Initial Catalog=QLCH;Integrated Security=True";
        private SqlConnection conn = new SqlConnection(connect_Str);
        public bool insertProduct(string idP, string nameP, double idA, string price)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                string sql = "INSERT INTO Albums (AlbumID, AlbumName,ArtistID, Price) VALUES (@AlbumID, @AlbumName, @ArtistID, @Price)";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@AlbumID", idP);
                cmd.Parameters.AddWithValue("@AlbumName", nameP);
                cmd.Parameters.AddWithValue("@ArtistID", idA);
                cmd.Parameters.AddWithValue("@Price", price);
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                    return true;
                else
                    return false;
            }
        }
        public bool deleteProduct(string idP)
        {
            using (SqlConnection connection = new SqlConnection(connect_Str))
            {
                connection.Open();
                string sql = "DELETE DIEM WHERE MaHocVien = @mhv";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@mhv", idP);
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
