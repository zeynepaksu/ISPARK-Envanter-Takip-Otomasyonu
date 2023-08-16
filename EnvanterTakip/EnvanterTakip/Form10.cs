using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvanterTakip
{
    public partial class Form10 : Form
    {
        private SqlConnection baglanti = new SqlConnection("server=DESKTOP-RK7MA7J;Initial Catalog=EnvanterTakip;Trusted_Connection=True;");
        public Form10()
        {
            InitializeComponent();
        }

        private void grpclsnblg_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Ürün ID ve Sicil No'yu al
                int urunID = Convert.ToInt32(txtUrunID.Text);
                int sicilNo = Convert.ToInt32(txtSicilNo.Text);

                // Talebi veritabanına kaydet
                baglanti.Open();
                string talepEkleSorgu = "INSERT INTO UrunTalepleri (UrunID, SicilNo, OnayDurumu,Islem) VALUES (@UrunID, @SicilNo, @OnayDurumu,'Talep')";
                SqlCommand command = new SqlCommand(talepEkleSorgu, baglanti);
                command.Parameters.AddWithValue("@UrunID", urunID);
                command.Parameters.AddWithValue("@SicilNo", sicilNo);
                command.Parameters.AddWithValue("@OnayDurumu", 0); // Yeni talep başlangıçta onay bekliyor olacak
                command.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Ürün talebi başarıyla kaydedildi. Onay bekleniyor.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            string sorgu = "SELECT Urun.UrunID, Urun.UrunAd, Urun.UrunKategori " +
                           "FROM Urun " +
                           "LEFT JOIN UrunTakip ON Urun.UrunID = UrunTakip.UrunID " +
                           "WHERE UrunTakip.UrunID IS NULL";

            SqlDataAdapter adapter = new SqlDataAdapter(sorgu, baglanti);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Form9 form9sec = new Form9();
            //form9sec.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
