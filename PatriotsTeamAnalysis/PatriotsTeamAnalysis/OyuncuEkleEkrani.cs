using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PatriotsTeamAnalysis
{
    public partial class OyuncuEkleEkrani : Form
    {
        public OyuncuEkleEkrani()
        {
            InitializeComponent();
        }
        SQLiteConnection baglan = new SQLiteConnection("Data Source=takim.sqlite;Version=3;");
       
        bool durum;
        private void formanukontrol()
        {
            durum = true;
            baglan.Open();
            SQLiteCommand komut = new SQLiteCommand("select *from Oyuncular", baglan);
            SQLiteDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (formanutxt.Text == read["FormaNu"].ToString() || formanutxt.Text == "")
                {
                    durum = false;
                }
            }
            baglan.Close();
        }

        private void oyuncueklebtn_Click_1(object sender, EventArgs e)
        {
            formanukontrol();
            if (durum == true)
            {
                try
                {
                    baglan.Open();
                    SQLiteCommand komut = new SQLiteCommand("insert into Oyuncular(FormaNu, Ad, Soyad,Pozisyon, Boy, Kilo, Yas, KatilmaTarihi, Devamsizlik,TelefonNu) values(@Formanu,@Ad,@Soyad,@Pozisyon,@Boy,@Kilo,@Yas,@Ktarih,@Devamsizlik,@TelefonNu)", baglan);
                    komut.Parameters.AddWithValue("@Formanu", int.Parse(formanutxt.Text));
                    komut.Parameters.AddWithValue("@Ad", adtxt.Text);
                    komut.Parameters.AddWithValue("@Soyad", soyadtxt.Text);
                    komut.Parameters.AddWithValue("@Pozisyon", pozisyontxt.Text);
                    komut.Parameters.AddWithValue("@Boy", double.Parse(boytxt.Text));
                    komut.Parameters.AddWithValue("@Kilo", double.Parse(kilotxt.Text));
                    komut.Parameters.AddWithValue("@Yas", int.Parse(yastxt.Text));
                    komut.Parameters.AddWithValue("@Ktarih", ktarihtxt.Text);
                    komut.Parameters.AddWithValue("@Devamsizlik", 0);
                    komut.Parameters.AddWithValue("@TelefonNu", txttelefonekle.Text);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("Oyuncu Eklendi.", "ONAY");
                }
                catch (Exception)
                {

                    MessageBox.Show("Girdiğiniz bilgileri kontrol ediniz!", "HATA");
                }
                
                foreach (Control item in panel1.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }
            else
            {
                MessageBox.Show("Girdiğiniz Forma Numarası Kayıtlı.", "HATA!");
            }
            
        }
        
        private void kapatbtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guncellebtn_Click(object sender, EventArgs e)
        {
            if (formaguncelletxt.Text==""||adguncelletxt.Text=="" || soyadguncelletxt.Text == "" || kiloguncelletxt.Text == "" || boyguncelletxt.Text == "" || pozisyonguncelletxt.Text == "" || yasguncelletxt.Text == "" || ktarihguncelletxt.Text == "")
            {
                MessageBox.Show("Girdiğiniz Bilgileri Kontrol Ediniz.", "HATA");
            }
            else
            {
                baglan.Open();
                SQLiteCommand komut = new SQLiteCommand("update Oyuncular set Ad=@Ad,Soyad=@Soyad,Kilo=@Kilo,Boy=@Boy,Pozisyon=@Pozisyon,Yas=@Yas,KatilmaTarihi=@KTarihi,TelefonNu=@TelefonNu where FormaNu=@FormaNu", baglan);
                komut.Parameters.AddWithValue("@FormaNu", int.Parse(formaguncelletxt.Text));
                komut.Parameters.AddWithValue("@Ad", adguncelletxt.Text);
                komut.Parameters.AddWithValue("@Soyad", soyadguncelletxt.Text);
                komut.Parameters.AddWithValue("@Kilo", double.Parse(kiloguncelletxt.Text));
                komut.Parameters.AddWithValue("@Boy", double.Parse(boyguncelletxt.Text));
                komut.Parameters.AddWithValue("@Pozisyon", pozisyonguncelletxt.Text);
                komut.Parameters.AddWithValue("@Yas", int.Parse(yasguncelletxt.Text));
                komut.Parameters.AddWithValue("@KTarihi", ktarihguncelletxt.Text);
                komut.Parameters.AddWithValue("@TelefonNu", txttelefonguncelle.Text);
                komut.ExecuteNonQuery();
                baglan.Close();
                formanukontrol();
                MessageBox.Show("Oyuncu Bilgileri Güncellendi.", "ONAY");
                foreach (Control item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }
            
        }

        private void formaguncelletxt_TextChanged(object sender, EventArgs e)
        {
            if (formaguncelletxt.Text == "")
            {
                foreach (Control item in panel2.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                        
                    }
                }
            }
            baglan.Open();
            SQLiteCommand komut = new SQLiteCommand("select *from Oyuncular where FormaNu like '" + formaguncelletxt.Text + "'", baglan);
            SQLiteDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                adguncelletxt.Text = read["Ad"].ToString();
                soyadguncelletxt.Text = read["Soyad"].ToString();
                kiloguncelletxt.Text = read["Kilo"].ToString();
                boyguncelletxt.Text = read["Boy"].ToString();
                pozisyonguncelletxt.Text = read["Pozisyon"].ToString();
                yasguncelletxt.Text = read["Yas"].ToString();
                ktarihguncelletxt.Text = read["KatilmaTarihi"].ToString();
                txttelefonguncelle.Text = read["TelefonNu"].ToString();
            }
            baglan.Close();
        }
    }
}
