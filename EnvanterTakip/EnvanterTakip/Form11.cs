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
    public partial class Form11 : Form
    {
        private SqlConnection baglanti = new SqlConnection("server=DESKTOP-RK7MA7J;Initial Catalog=EnvanterTakip;Trusted_Connection=True;");

        public  int devirSicil;
        public int sicil;
        public int urID;
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                baglanti.Open();
                string onayBekleyenSorgu = "SELECT * FROM UrunTalepleri WHERE OnayDurumu = 0";
                SqlDataAdapter adapter = new SqlDataAdapter(onayBekleyenSorgu, baglanti);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }


        // Onayla butonu için Click olayı
        private void btnOnayla_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    int talepID = Convert.ToInt32(selectedRow.Cells["TalepID"].Value);
                    string talepTipi = selectedRow.Cells["Islem"].Value.ToString();

                    if (talepTipi.Equals("Talep"))
                    {
                        // Talep işlemi onaylama kodları
                        UpdateTalepOnayDurumu(talepID, 1);
                        InsertUrunTakip(selectedRow);
                        MessageBox.Show("Talep onaylandı ve kaydedildi.");
                        Form11_Load(sender, e); // Listeyi yenile
                    }
                    else if (talepTipi.Equals("İade"))
                    {
                        // İade işlemi onaylama kodları
                        UpdateTalepOnayDurumu(talepID, 1);
                        InsertUrunGecmis(selectedRow);
                        DeleteFromUrunTakip(selectedRow);
                     
                        MessageBox.Show("Ürün iade işlemi başarıyla gerçekleştirildi.");
                        Form11_Load(sender, e); // Listeyi yenile
                    }
                    else if (talepTipi.Equals("Devir"))
                    {
                        // İade işlemi onaylama kodları
                        UpdateTalepOnayDurumu(talepID, 1);

                        InsertUrunGecmis(selectedRow);
                        UpdateUrunTakip(selectedRow);
                        

                        MessageBox.Show("Ürün devir işlemi başarıyla gerçekleştirildi.");
                        Form11_Load(sender, e); // Listeyi yenile
                    }

                    else
                    {
                        MessageBox.Show("Geçersiz talep seçimi.");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen talep seçin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }

        }

        // Reddet butonu için Click olayı
        private void btnReddet_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    int talepID = Convert.ToInt32(selectedRow.Cells["TalepID"].Value);
                    UpdateTalepOnayDurumu(talepID, -1);
                    MessageBox.Show("Talep reddedildi.");
                    Form11_Load(sender, e); // Listeyi yenile
                }
                else
                {
                    MessageBox.Show("Lütfen talep seçin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }


        private void UpdateTalepOnayDurumu(int talepID, int onayDurumu)
        {
            try
            {
                baglanti.Open();
                string onaylaSorgu = "UPDATE UrunTalepleri SET OnayDurumu = @OnayDurumu WHERE TalepID = @TalepID";
                SqlCommand command = new SqlCommand(onaylaSorgu, baglanti);
                command.Parameters.AddWithValue("@TalepID", talepID);
                command.Parameters.AddWithValue("@OnayDurumu", onayDurumu);
                int affectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void InsertUrunTakip(DataGridViewRow selectedRow)
        {
            try
            {
                int urunID = Convert.ToInt32(selectedRow.Cells[1].Value);
                int SicilNo = Convert.ToInt32(selectedRow.Cells[2].Value);

                baglanti.Open();
                string kaydetSorgu = "INSERT INTO UrunTakip (UrunID, SicilNo, KayıtTarihi, FaaliyetTarihi, OnayTarihi) " +
                                     "VALUES (@UrunID, @SicilNo, @KayıtTarihi, @FaaliyetTarihi, @OnayTarihi)";
                SqlCommand commandKaydet = new SqlCommand(kaydetSorgu, baglanti);
                commandKaydet.Parameters.AddWithValue("@UrunID", urunID);
                commandKaydet.Parameters.AddWithValue("@SicilNo", SicilNo);
                commandKaydet.Parameters.AddWithValue("@KayıtTarihi", DateTime.Now);
                commandKaydet.Parameters.AddWithValue("@FaaliyetTarihi", DateTime.Now);
                commandKaydet.Parameters.AddWithValue("@OnayTarihi", DateTime.Now);
                commandKaydet.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void InsertUrunGecmis(DataGridViewRow selectedRow)
        {
            try
            {
                baglanti.Open();
              
               
                 


                    

                   string eklemeSorgu = "INSERT INTO UrunGecmis (UrunID, SicilNo, KayıtTarihi, FaaliyetTarihi, OnayTarihi, Islem) " +
                    "VALUES (@UrunID, @SicilNo, @kayıttarih, @faaltarih,@onaytarih, 'Islem')";
                    SqlCommand commandEkleme = new SqlCommand(eklemeSorgu, baglanti);
                    commandEkleme.Parameters.AddWithValue("@UrunID", urID);
                    commandEkleme.Parameters.AddWithValue("@SicilNo", sicil);
                    commandEkleme.Parameters.AddWithValue("@kayıttarih", DateTime.Now);
                    commandEkleme.Parameters.AddWithValue("@faaltarih", DateTime.Now);
                    commandEkleme.Parameters.AddWithValue("@onaytarih", DateTime.Now);







            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }
     

        private void DeleteFromUrunTakip(DataGridViewRow selectedRow)
        {
            try
            {
                int urunID = Convert.ToInt32(selectedRow.Cells[1].Value);
                int SicilNo = Convert.ToInt32(selectedRow.Cells[2].Value);

                baglanti.Open();
                string silmeSorgu = "DELETE FROM UrunTakip WHERE UrunID = @UrunID AND SicilNo = @SicilNo";
                SqlCommand commandSilme = new SqlCommand(silmeSorgu, baglanti);
                commandSilme.Parameters.AddWithValue("@UrunID", urunID);
                commandSilme.Parameters.AddWithValue("@SicilNo", SicilNo);
                commandSilme.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }
        private void UpdateUrunTakip(DataGridViewRow selectedRow)
        {
            try
            {
                int urunID = Convert.ToInt32(selectedRow.Cells[1].Value);
                int sicilNo = Convert.ToInt32(selectedRow.Cells[5].Value);

                baglanti.Open();
                string updateSorgu = "UPDATE UrunTakip SET SicilNo = @SicilNo WHERE UrunID = @UrunID";
                SqlCommand commandUpdate = new SqlCommand(updateSorgu, baglanti);
                commandUpdate.Parameters.AddWithValue("@SicilNo", sicilNo);
                commandUpdate.Parameters.AddWithValue("@UrunID", urunID);
                commandUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }

        }
    }
}
