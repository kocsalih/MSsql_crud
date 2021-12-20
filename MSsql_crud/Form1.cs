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

namespace MSsql_crud
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        static string Baglanti = "server=DESKTOP-HNE43R2; Database=NORTHWND; Trusted_connection=True;  ";

        SqlConnection conn = new SqlConnection(Baglanti);
        SqlCommand cmd;

        private void UrunGetir(string sorgu)
        {
            SqlDataAdapter adap = new SqlDataAdapter(sorgu, conn);
            DataTable tablo = new DataTable();
            adap.Fill(tablo);

            dataGridView1.DataSource = tablo;
        }

        private void btnUrunGetir_Click(object sender, EventArgs e)
        {
            string sorgu = "select*from products";
            UrunGetir(sorgu);
        }
    }
}
