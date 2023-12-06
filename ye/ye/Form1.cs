using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace ye
{
    public partial class Form1 : Form
    {
        private static string connect_Str = @"Data Source=LAPTOP-77AKUU80\SQLEXPRESS;Initial Catalog=QLCH;Integrated Security=True";
        Product p = new Product();
        public Form1()
        {
            InitializeComponent();
            Load_Data();
        }
        DatabaseManager dbmanager = new DatabaseManager();
        private void Load_Data()
        {
            DataTable dt_product = new DataTable();
            dbmanager.OpenConnection();
            string query = "SELECT AlbumID AS 'Mã album', AlbumName AS 'Tên album', ArtistID AS 'Mã ca sĩ', Price AS 'Giá tiền' " +
                "FROM Albums";
            dt_product = dbmanager.ExecuteQuery_LoadData(query);
            dbmanager.CloseConnection();
            dataGridView_Product.DataSource = dt_product;
        }

       
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGridView_Product.Columns.Clear();
            txt_IDP.Clear();
            txt_PName.Clear();
            txt_IDA.Clear();
            txt_Price.Clear();
            Load_Data();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (txt_IDP.Text == "" || txt_PName.Text == "")
            {
                MessageBox.Show("Need Product data", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else  
            {
                string idP = txt_IDP.Text;
                string nameP = txt_PName.Text;
                string idA = txt_IDA.Text;
                string price = txt_Price.Text;

                if (dbmanager.insertProduct(idP, nameP, idA, price) == true)
                {
                    btn_Refresh.PerformClick();
                    MessageBox.Show("Hoàn tất thêm album", "Update Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Chưa hoàn tất thêm album", "Update Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Form1();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (txt_IDP.Text == null)
            {
                MessageBox.Show("Need Product data", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_IDP.Focus();
            }
            else
            {
                if (txt_IDA.Text == null)
                {
                    MessageBox.Show("Need Product data", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_IDA.Focus();
                }
                else
                {
                    string mhv = txt_IDP.Text;
                    string mkh = txt_IDA.Text;
                    if (dbmanager.deleteProduct(mhv, mkh) == true)
                    {
                        btn_Refresh.PerformClick();
                        MessageBox.Show("Hoàn tất xóa điểm", "Delete Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Chưa hoàn tất xóa điểm", "Delete Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
    }
}
