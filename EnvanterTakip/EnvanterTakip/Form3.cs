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
    public partial class Form3 : Form
    {
       

        public Form3()
        {
            InitializeComponent();
            
        }
        SqlConnection baglanti = new SqlConnection("server=DESKTOP-RK7MA7J ;Initial Catalog= EnvanterTakip;Trusted_Connection=True;");
        DataSet daset = new DataSet();

        private void Form3_Load(object sender, EventArgs e)
        {
            Kayit_goster();
        }
        private void Kayit_goster()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select*from Kullanıcılar", baglanti);
            adtr.Fill(daset, "Kullanıcılar");
            dataGridView1.DataSource = daset.Tables["Kullanıcılar"];
            baglanti.Close();
        }

        private void Form3_DoubleClick(object sender, EventArgs e)
        {
            txtSicilNo.Text = dataGridView1.CurrentRow.Cells["SicilNo"].Value.ToString();
            txtAd.Text = dataGridView1.CurrentRow.Cells["CalısanAd"].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells["CalısanSoyad"].Value.ToString();
            txtDpt.Text = dataGridView1.CurrentRow.Cells["DepartmanAd"].Value.ToString();
            txtPzs.Text = dataGridView1.CurrentRow.Cells["Pozisyon"].Value.ToString();
            txtPrl.Text = dataGridView1.CurrentRow.Cells["Parola"].Value.ToString();

        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Kullanıcılar set ,CalısanAd=@Ad,CalısanSoyad=@Soyad,DepartmanAd=@Dpt,Pozisyon=@Pzs,Parola=@Prl  where SicilNo=SicilNo ",baglanti);

            komut.Parameters.AddWithValue("@SicilNo", txtSicilNo.Text);
            komut.Parameters.AddWithValue("@Ad", txtAd.Text);
            komut.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("@Dpt", txtDpt.Text);
            komut.Parameters.AddWithValue("@Pzs", txtPzs.Text);
            komut.Parameters.AddWithValue("@Prl", txtPrl.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["Kullanıcılar"].Clear();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
             int secilenId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            baglanti.Open();
            string sorgu = "delete from Kullanıcılar where SicilNo= @silinecekıd";
            SqlCommand command=new SqlCommand(sorgu,baglanti);
            command.Parameters.AddWithValue("@silinecekıd", secilenId);
            command.ExecuteNonQuery();
            baglanti.Close();
            Kayit_goster();
            MessageBox.Show("Kayıt Silindi");

        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {  
            DataTable tablo= new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select*from Kullanıcılar where SicilNo like '%"+txtAra.Text+"%'", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSicilNo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtDpt.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtPzs.Text= dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtPrl.Text= dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2sec = new Form2();
            form2sec.Show();
            this.Close();
        }
    }
}
