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
    public partial class DevamsizlikEkrani : Form
    {
        public DevamsizlikEkrani()
        {
            InitializeComponent();
        }
        SQLiteConnection baglan = new SQLiteConnection("Data Source=takim.sqlite;Version=3;");
        DataSet ds = new DataSet();
        private void Listele()
        {
            baglan.Open();
            SQLiteDataAdapter adtr = new SQLiteDataAdapter("Select FormaNu AS 'Forma Numarası', Ad, Soyad, Devamsizlik AS 'Devamsızlık',DisiplinCezasi AS 'Disiplin Cezaları', Zimmet AS 'Ekipmanlar' From Oyuncular", baglan);
            adtr.Fill(ds, "Oyuncular");
            dataGridView1.DataSource = ds.Tables["Oyuncular"];
            baglan.Close();

        }
        
        private void DevamsizlikEkrani_Load(object sender, EventArgs e)
        {
            Listele();
            
        }

        private void kapatbtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = ds.Tables[0].DefaultView;
            dv.RowFilter = "Ad Like '%" + textBox1.Text + "%' or Soyad Like '%" + textBox1.Text + "%'";
            dataGridView1.DataSource = dv;
        }

        private void dEklebtn_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SQLiteCommand komut = new SQLiteCommand("update Oyuncular set Devamsizlik=Devamsizlik+'" + int.Parse(dEkletxt.Text) + "' where FormaNu='" + dataGridView1.CurrentRow.Cells["Forma Numarası"].Value.ToString() + "'", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Devamsızlık Eklendi", "Onay");
            ds.Tables["Oyuncular"].Clear();
            Listele();
            dEkletxt.Clear();
        }

        private void silbtn_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Seçili Oyuncunun Devamsızlığı Silinsin mi? ", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                baglan.Open();
                SQLiteCommand komut = new SQLiteCommand("update Oyuncular set Devamsizlik='" + 0 + "' where FormaNu='" + dataGridView1.CurrentRow.Cells["Forma Numarası"].Value.ToString() + "'", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Devamsızlık Silindi", "Onay");
                ds.Tables["Oyuncular"].Clear();
                Listele();
            }
                 }
        private void disiplineklebtn_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SQLiteCommand komut = new SQLiteCommand("update Oyuncular set DisiplinCezasi='"+disiplinmultitxt.Text+"' where FormaNu='" + dataGridView1.CurrentRow.Cells["Forma Numarası"].Value.ToString() + "'", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Disiplin Cezası Güncellendi", "Onay");
            ds.Tables["Oyuncular"].Clear();
            Listele();
            disiplinmultitxt.Clear();
            baglan.Close();
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            disiplinmultitxt.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Disiplin Cezaları"].Value.ToString();
            ekipmanmultitxt.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Ekipmanlar"].Value.ToString();

            if (disiplinmultitxt.Lines.Length > 2)
            {
                disiplinsinirtxt.Text = "Seçili Oyuncu\nDisiplin Sınırını\nAşmış!";
                //MessageBox.Show("Oyuncu Disiplin Sınırını Aşmış!","UYARI");
            }
            else if (disiplinmultitxt.Lines.Length > 1)
            {
              //  MessageBox.Show("Oyuncu Disiplin Sınırında!", "UYARI");
                disiplinsinirtxt.Text = "Seçili Oyuncu\nDisiplin Sınırında!";
            }
            else
            {
                disiplinsinirtxt.Text = "";
            }
        }

        private void disiplinsilbtn_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Seçili Oyuncunun Disiplin Cezaları Silinsin mi? ", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                baglan.Open();
                SQLiteCommand komut = new SQLiteCommand("update Oyuncular set DisiplinCezasi='" + "" + "' where FormaNu='" + dataGridView1.CurrentRow.Cells["Forma Numarası"].Value.ToString() + "'", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Disiplin Cezası Silindi", "Onay");
                ds.Tables["Oyuncular"].Clear();
                Listele();
                disiplinmultitxt.Clear();
                dataGridView1.ClearSelection();
            }
        }

        private void ekipmaneklebtn_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SQLiteCommand komut = new SQLiteCommand("update Oyuncular set Zimmet='" + ekipmanmultitxt.Text + "' where FormaNu='" + dataGridView1.CurrentRow.Cells["Forma Numarası"].Value.ToString() + "'", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Oyuncu Ekipmanı Güncellendi", "Onay");
            ds.Tables["Oyuncular"].Clear();
            Listele();
            ekipmanmultitxt.Clear();
            baglan.Close();
            dataGridView1.ClearSelection();
        }

        private void ekipmansilbtn_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Seçili Oyuncunun Ekipmanları Silinsin mi? ", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                baglan.Open();
                SQLiteCommand komut = new SQLiteCommand("update Oyuncular set Zimmet='" + "" + "' where FormaNu='" + dataGridView1.CurrentRow.Cells["Forma Numarası"].Value.ToString() + "'", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Ekipmanlar Silindi", "Onay");
                ds.Tables["Oyuncular"].Clear();
                Listele();
                ekipmanmultitxt.Clear();
                dataGridView1.ClearSelection();
            }
        }
    }
}