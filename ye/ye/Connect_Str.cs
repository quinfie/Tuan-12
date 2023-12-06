using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ye
{
    public class DatabaseManager
    {
        private string connectionString;
        private SqlConnection connection;
        private string chuoiKetNoi = @"Data Source=LAPTOP-77AKUU80\SQLEXPRESS;Initial Catalog=QLCH;Integrated Security=True";

        public string GetConnection()
        {
            return chuoiKetNoi;
        }
        public DatabaseManager()
        {
            connectionString = chuoiKetNoi;
            connection = new SqlConnection(connectionString);
        }
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public void CloseConnection()
        {
            connection.Close();
        }

        public DataTable ExecuteQuery_LoadData(string cmd)
        {
            OpenConnection();
            DataTable da = new DataTable();
            try
            {
                SqlCommand sc = new SqlCommand(cmd, connection);
                SqlDataAdapter sda = new SqlDataAdapter(sc);
                sda.Fill(da);
            }
                
            catch
            {
                da = null;
            }
            CloseConnection();
            return da;
        }

        internal bool insertProduct(string idP, string nameP, string idA, string price)
        {
            throw new NotImplementedException();
        }

        internal bool deleteProduct(string mhv, string mkh)
        {
            throw new NotImplementedException();
        }
    }
    
}
