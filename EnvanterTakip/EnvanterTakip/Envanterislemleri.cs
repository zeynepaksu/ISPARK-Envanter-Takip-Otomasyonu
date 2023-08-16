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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("server=DESKTOP-RK7MA7J ;Initial Catalog= EnvanterTakip;Trusted_Connection=True;");
        SqlCommand command;
        SqlDataAdapter da;
        SqlDataReader dr;


        public int sicilNo;
        public int parola;
        public int girenSicilNo;

        void createDataTable(string sorgu, int parola)
        {
            baglanti.Open();
            da = new SqlDataAdapter(sorgu, baglanti);
            baglanti.Close();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2sec = new Form2();
            form2sec.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form10 form10sec = new Form10();
            form10sec.Show();
           //this.Hide();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            label2.Text = sicilNo.ToString();
            string sorgu2 = "SELECT k.SicilNo, k.CalısanAd, k.CalısanSoyad, ur.UrunID, ur.UrunAd, ur.UrunKategori \r\nFROM Kullanıcılar k\r\nINNER JOIN UrunTakip ut on ut.SicilNo=k.SicilNo\r\nINNER JOIN Urun ur on ur.UrunID=ut.UrunID\r\nINNER JOIN UrunKategori uk on ur. UrunKategori = uk.UrunKategori\r\nwhere k.SicilNo=" + sicilNo;
            baglanti.Open();
            da = new SqlDataAdapter(sorgu2, baglanti);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
            baglanti.Close();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
             
                // DataGridView'de tam bir satırın seçildiğinden emin ol
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    // Seçilen ürünün ID'sini al
                    int urunID = Convert.ToInt32(selectedRow.Cells["UrunID"].Value);
                    int sicilNo = Convert.ToInt32(selectedRow.Cells["SicilNo"].Value);
                    Form11 fr = new Form11();

                    fr.sicil = int.Parse(label2.Text);
                    fr.urID = urunID;

                    // Ürün iade talebini "UrunTalepleri" tablosuna ekle
                    baglanti.Open();
                    string onaySorgu = "INSERT INTO UrunTalepleri (UrunID, SicilNo, OnayDurumu, Islem) " +
                                       "VALUES (@UrunID, @SicilNo, @OnayDurumu, 'İade')";
                    SqlCommand commandOnayBekliyor = new SqlCommand(onaySorgu, baglanti);
                    commandOnayBekliyor.Parameters.AddWithValue("@UrunID", urunID);
                    commandOnayBekliyor.Parameters.AddWithValue("@SicilNo", sicilNo); 
                    commandOnayBekliyor.Parameters.AddWithValue("@OnayDurumu", 0); // Yeni talep olduğu için onay durumu 0 (beklemede) olarak ayarlanır.
                    int affectedRows = commandOnayBekliyor.ExecuteNonQuery();
                    baglanti.Close();

                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Ürün iade talebi gönderildi ve onay bekliyor.");
                    }
                    else
                    {
                        MessageBox.Show("Geçersiz ürün iade seçimi.");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen ürün iade talebi seçin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1sec = new Form1();
            form1sec.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBoxUrunDevret.Visible = true; 
            
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                int urunID = int.Parse(txtUrunID.Text);
                int devredilecekSicilNo = int.Parse(txtDevredilecekSicilNo.Text);
                Form11 fr = new Form11();
                fr.devirSicil = int.Parse(txtDevredilecekSicilNo.Text);
                fr.sicil = int.Parse(label2.Text);
                fr.urID = int.Parse(txtUrunID.Text);
               

                // Ürün Devir Talebini ÜrünTalepleri tablosuna ekle
                string ekleSorgu = "INSERT INTO UrunTalepleri (UrunID, SicilNo, DevredilecekSicilNo, OnayDurumu, Islem) " +
                                   "VALUES (@UrunID, @SicilNo, @DevredilecekSicilNo, 0,'Devir')";
                SqlCommand commandEkle = new SqlCommand(ekleSorgu, baglanti);
                commandEkle.Parameters.AddWithValue("@UrunID", urunID);
                commandEkle.Parameters.AddWithValue("@SicilNo", girenSicilNo);
                commandEkle.Parameters.AddWithValue("@DevredilecekSicilNo", devredilecekSicilNo);
                commandEkle.ExecuteNonQuery();

               
                // GroupBox'u tekrar gizle ve TextBoxları temizle
                groupBoxUrunDevret.Visible = false;
                txtUrunID.Text = "";
                txtDevredilecekSicilNo.Text = "";

                // Admin sayfasına onay düşeceğini varsayıyorum, gerekirse bildirimi burada gönderebilirsiniz

                baglanti.Close();
                MessageBox.Show("Ürün devir talebi başarıyla kaydedildi. Onay bekleniyor.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }
    }
    
}
