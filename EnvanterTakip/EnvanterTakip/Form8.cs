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


namespace EnvanterTakip
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("server=DESKTOP-RK7MA7J ;Initial Catalog= EnvanterTakip;Trusted_Connection=True;");

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Urun(UrunID,UrunAd,UrunKategori) values(@UID,@UAd,@UKtgr)", baglanti);
            komut.Parameters.AddWithValue("@UID", txtUID.Text);
            komut.Parameters.AddWithValue("@UAd", txtUAd.Text);
            komut.Parameters.AddWithValue("@UKtgr", comboBox1.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün kaydı eklendi.");
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }
        private void kategorigetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select*from UrunKategori", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboBox1.Items.Add(read["UrunKategori"].ToString());
            }
            baglanti.Close() ;
        }
        private void Form8_Load(object sender, EventArgs e)
        {
            kategorigetir();    
        }
    }
}
