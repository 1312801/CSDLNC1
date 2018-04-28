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

namespace HotelManagement
{
    public partial class InvoiceAdding : Form
    {
        public InvoiceAdding()
        {
            InitializeComponent();
           
        }
        private void loadCombobox(SqlConnection conn)
        {
            string query = "SELECT maDP FROM DatPhong";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "maDP");
            comboBox1.DisplayMember = "maDP";
            comboBox1.DataSource = ds.Tables["maDP"];
        }
        private void loadTable(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection=conn;
            cmd.CommandType=CommandType.Text;
            cmd.CommandText="SELECT * FROM HoaDon";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            danhsachhoadon.DataSource = dt;
        }
       
        private void ngaythanhtoanlb_Click(object sender, EventArgs e)
        {

        }

        private void ngaythanhtoandt_ValueChanged(object sender, EventArgs e)
        {

        }

        private void mahdtb_TextChanged(object sender, EventArgs e)
        {

        }

        private void ThemHoaDon_Option_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader rd = null;
                String connString = @"Data Source=DESKTOP-K61FV16\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=SSPI;";
                SqlConnection conn = new SqlConnection(connString);              
                SqlCommand cmd = new SqlCommand("SP_CreateBill", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@maDP", Int32.Parse(comboBox1.Text)));
                conn.Open();
                rd = cmd.ExecuteReader();
                conn.Close();
                loadTable(conn);
                
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void danhsachhoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void InvoiceAdding_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-K61FV16\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=SSPI;"))
            {
                try
                {
                    conn.Open();
                    loadCombobox(conn);
                    loadTable(conn);
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error!");
                }
            }
        }
    }
}
