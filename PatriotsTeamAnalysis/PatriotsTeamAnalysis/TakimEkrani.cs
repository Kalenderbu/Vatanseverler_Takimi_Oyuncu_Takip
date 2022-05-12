using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatriotsTeamAnalysis
{
    public partial class TakimEkrani : Form
    {
        bool durum;
        public TakimEkrani()
        {
            InitializeComponent();
        }
        SQLiteConnection baglan;
        SQLiteDataAdapter da;
        DataSet ds;
        
        public void Listele()       //Veri tabanındaki verileri listelemek için prosedür oluşturuldu.
        {
            baglan = new SQLiteConnection("Data Source=takim.sqlite;Version=3;");   //Veri tabanı bağlantısı için dosya yolu tanımlandı.
            da = new SQLiteDataAdapter("Select FormaNu As 'Forma Numarası',Ad,Soyad,Pozisyon,Boy,Kilo,Yas AS 'Yaş',TelefonNu AS 'Telefon Numarası',KatilmaTarihi AS 'Katılma Tarihi' From Oyuncular", baglan);
            ds = new DataSet();         //Veri tabanında Oyuncular tablosu içerisindeki alan adları okunabilirliğini arttırmak için AS komutuyla e
            baglan.Open();
            da.Fill(ds, "Oyuncular");
            dataGridView1.DataSource = ds.Tables["Oyuncular"];
            baglan.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Listele();
        }

        private void silbtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Oyuncu Çıkartılsın mı?", "UYARI", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                baglan.Open();
                SQLiteCommand komut = new SQLiteCommand("Delete From Oyuncular where FormaNu='" + dataGridView1.CurrentRow.Cells["Forma Numarası"].Value.ToString() + "'", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Oyuncu Çıkartıldı.", "ONAY");
                ds.Tables["Oyuncular"].Clear();
                Listele();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void barkodkontrol()
        {
            durum = true;
            baglan.Open();
            SQLiteCommand komut = new SQLiteCommand("select *from Oyuncular", baglan);
            SQLiteDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (textBox1.Text == read["FormaNu"].ToString())
                {
                    durum = false;
                }
            }
            baglan.Close();
        }
        private void yenile()
        {
            if (textBox1.Text == "")
            {
                foreach (Control item in panel1.Controls)
                {
                    if (item is TextBox)
                    {
                        if (item != textBox1)
                        {
                            item.Text = "";
                        }
                    }
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = ds.Tables[0].DefaultView;
            dv.RowFilter = "Ad Like '%" + textBox1.Text + "%' or Soyad Like '%" + textBox1.Text + "%'";
            dataGridView1.DataSource = dv;
        }

        private void TakimEkrani_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Delete)
            {
                if (MessageBox.Show("Oyuncu Çıkartılsın mı?", "UYARI", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    baglan.Open();
                    SQLiteCommand komut = new SQLiteCommand("Delete From Oyuncular where FormaNu='" + dataGridView1.CurrentRow.Cells["FormaNu"].Value.ToString() + "'", baglan);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("Oyuncu Çıkartıldı.", "ONAY");
                    ds.Tables["Oyuncular"].Clear();
                    Listele();
                }
            }
        }
    }
}
