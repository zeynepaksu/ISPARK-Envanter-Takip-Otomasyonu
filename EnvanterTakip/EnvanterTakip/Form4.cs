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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace EnvanterTakip
{
    public partial class Form4 : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapter;

        public Form4()
        {
            InitializeComponent();
            conn = new SqlConnection("server=DESKTOP-RK7MA7J ;Initial Catalog= EnvanterTakip;Trusted_Connection=True;");
            conn.Open();
            adapter = new SqlDataAdapter("select*from Urun", conn);
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
            SqlDataAdapter adtr = new SqlDataAdapter("select*from Urun", baglanti);
            adtr.Fill(daset, "Urun");
            dataGridView1.DataSource = daset.Tables["Urun"];
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2sec = new Form2();
            form2sec.Show();
            this.Hide();
        }
        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select*from Urun where UrunID like '%" + txtAra.Text + "%'", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            int secilenId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            baglanti.Open();
            string sorgu = "delete from Urun where UrunID= @silinecekıd";
            SqlCommand command = new SqlCommand(sorgu, baglanti);
            command.Parameters.AddWithValue("@silinecekıd", secilenId);
            command.ExecuteNonQuery();
            baglanti.Close();
            Kayit_goster();
            MessageBox.Show("Kayıt Silindi");

        }
    }
}
