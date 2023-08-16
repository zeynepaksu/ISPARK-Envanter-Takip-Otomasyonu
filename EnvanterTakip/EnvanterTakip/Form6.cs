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
using System.Data.Common;

namespace EnvanterTakip
{
    public partial class Form6 : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        public Form6()
        {
            InitializeComponent();
          
            conn = new SqlConnection("server=DESKTOP-RK7MA7J ;Initial Catalog= EnvanterTakip;Trusted_Connection=True;");
            conn.Open();
            adapter = new SqlDataAdapter("select*from UrunGecmis", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        SqlConnection baglanti = new SqlConnection("server=DESKTOP-RK7MA7J ;Initial Catalog= EnvanterTakip;Trusted_Connection=True;");
        DataSet daset = new DataSet();
        private void Kayit_goster()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select*from UrunGecmis", baglanti);
            adtr.Fill(daset, "UrunGecmis");
            dataGridView1.DataSource = daset.Tables["UrunGecmis"];
            baglanti.Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select*from UrunGecmis where UrunID like '%" + txtAra.Text + "%'", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int secilenId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            baglanti.Open();
            string sorgu = "delete from UrunGecmis where UrunID= @silinecekıd";
            SqlCommand command = new SqlCommand(sorgu, baglanti);
            command.Parameters.AddWithValue("@silinecekıd", secilenId);
            command.ExecuteNonQuery();
            baglanti.Close();
            Kayit_goster();
            MessageBox.Show("Kayıt Silindi");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 form2sec = new Form2();
            form2sec.Show();
            this.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
         
        }
    }
}
