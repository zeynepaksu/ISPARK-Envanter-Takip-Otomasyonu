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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace EnvanterTakip
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("server=DESKTOP-RK7MA7J ;Initial Catalog= EnvanterTakip;Trusted_Connection=True;");
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Kullanıcılar(SicilNo,CalısanAd,CalısanSoyad,DepartmanAd,Pozisyon,Parola) values(@SicilNo,@Ad,@Soyad,@Dpt,@Pzs,@Prl)", baglanti);
            komut.Parameters.AddWithValue("@SicilNo", txtSicilNo.Text);
            komut.Parameters.AddWithValue("@Ad", txtAd.Text);
            komut.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("@Dpt", combodpt.Text);
            komut.Parameters.AddWithValue("@Pzs", txtPzs.Text);
            komut.Parameters.AddWithValue("@Prl", txtPrl.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel kaydı eklendi.");
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
            SqlCommand komut = new SqlCommand("select*from Departman", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                combodpt.Items.Add(read["DepartmanAd"].ToString());
            }
            baglanti.Close();
        }
        private void Form7_Load(object sender, EventArgs e)
        {
            kategorigetir();
        }
    }
}
