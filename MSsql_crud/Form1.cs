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

        private void btnGetirID_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("select *from products where productID=@pID", conn);
                    cmd.Parameters.AddWithValue("@pID", txtBulID.text);

                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    DataTable tablo = new DataTable();
                    adap.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text!="")
                {
                    conn.Open();
                    cmd=new SqlCommand("insert into products(productName,unitsInstock,unitPrice) values(@productName,@unitsInstock,")

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            conn.Open();
            string updateSorgu = "update Products set productName=@name, unitprice=@uprice,unitinstock=@stock where productID=@pID";
            cmd = new SqlCommand(updateSorgu, conn);
            cmd.Parameters.AddWithValue("@pId",id);
            cmd.Parameters.AddWithValue("@name",textBox2.Text);
            cmd.Parameters.AddWithValue("@uprice",textBox3.Text);
            cmd.Parameters.AddWithValue("@stock",textBox4.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Güncellendi..");
            UrunGetir("Select*from products");
            conn.Close();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
