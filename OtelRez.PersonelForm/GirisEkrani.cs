using Microsoft.Data.SqlClient;
using OtelRez.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelRez.PersonelForm
{
    public partial class GirisEkrani : Form
    {
        public GirisEkrani()
        {
            InitializeComponent();
        }

        SqlConnection cnn = new SqlConnection("server=.;Database=OtelRezDb;Trusted_Connection=true;TrustServerCertificate=true");

        private void btn_giris_Click(object sender, EventArgs e)
        {
            PersonelGiris personel = new PersonelGiris();
            personel.Mail = txt_Mail.Text;
            personel.Sifre = txt_Sifre.Text;

            if (!string.IsNullOrEmpty(txt_Mail.Text) && !string.IsNullOrEmpty(txt_Sifre.Text))
            {
                //Veritabanındaki veriyle ekrandan girilen verileri karşılaştırır.
                string query = $@"SELECT pg.Mail, pg.Sifre, p.PersonelMeslekId 
                    FROM PersonelGiris pg
                    INNER JOIN Personeller p ON pg.PersonelId = p.Id
                    WHERE pg.Mail = '{personel.Mail}' AND pg.Sifre = '{personel.Sifre}'";

                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                //Girilen veriler doğruysa anasayfaya geçiş yapar.
                if (reader.HasRows)
                {
                    reader.Read();
                    int personelMeslekId = Convert.ToInt32(reader["PersonelMeslekId"]);
                    
                    if (personelMeslekId == 1)
                    {
                        YoneticiAnasayfa yoneticiAnasayfa = new YoneticiAnasayfa();
                        yoneticiAnasayfa.Show();
                        this.Hide();
                    }

                    else  if (personelMeslekId == 2)
                    {
                        ResepsiyonAnasayfa resepsiyonAnasayfa = new ResepsiyonAnasayfa();
                        resepsiyonAnasayfa.Show();
                        this.Hide();
                    }

                    else
                    {
                        MessageBox.Show("Bu meslek ID'si için yönlendirme tanımlı değil.");
                    }

                }

                //Girilen veriler yanlışsa hata mesajı verir ve alanları temizler.
                else
                {
                    txt_Mail.Clear();
                    txt_Sifre.Clear();
                    MessageBox.Show("Hatalı Giriş!");
                }
            }

            else
            {
                MessageBox.Show("Zorunlu Alanlar Boş Bırakılamaz!");
            }
            cnn.Close();
        }
    }
}
