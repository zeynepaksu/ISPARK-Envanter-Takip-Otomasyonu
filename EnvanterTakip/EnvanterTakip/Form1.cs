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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace EnvanterTakip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("server=DESKTOP-RK7MA7J ;Initial Catalog= EnvanterTakip;Trusted_Connection=True;");
        public static int sicilNo;
        public int parola;

        public int girenSicilNo;

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUser.Text == "admin" && txtPass.Text == "123")
                {
                    // Admin girişi
                    Form2 form2sec = new Form2();
                    form2sec.Show();
                    this.Hide();
                }
                else
                {
                    // Normal kullanıcı girişi
                    string sorgu = "SELECT * FROM Kullanıcılar WHERE Parola=@pass AND SicilNo = @pID";
                    using (SqlConnection conn = new SqlConnection(baglanti.ConnectionString))
                    {
                        baglanti.Open();
                        using (SqlCommand cmd = new SqlCommand(sorgu, baglanti))
                        {
                            cmd.Parameters.AddWithValue("@pID", txtUser.Text);
                            cmd.Parameters.AddWithValue("@pass", txtPass.Text);
                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.Read())
                            {
                                // Kullanıcının giriş yaptığı SicilNo'yu al ve değişkene ata
                                girenSicilNo = Convert.ToInt32(reader["SicilNo"]);

                                // Form9'a SicilNo'yu göndererek aç
                                Form9 viewOne = new Form9();
                                viewOne.sicilNo = girenSicilNo;
                                viewOne.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Geçersiz kullanıcı adı veya parola.");
                            }
                            reader.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

