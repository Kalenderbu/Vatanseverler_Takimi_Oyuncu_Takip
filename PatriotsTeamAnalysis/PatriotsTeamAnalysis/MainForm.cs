using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PatriotsTeamAnalysis
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Oee_FormClosed(object sender, FormClosedEventArgs e)
        {
            pictureBox2.BringToFront();         // pencereler kapandığında pitcureBoxlar öne getirilir.
            pictureBox1.BringToFront();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Programı kapatmak için çarpı tuşuna tıklandığında, kullanıcıya evet-hayır butonları bulunan uyarı kutusu gösterilir ve seçime göre işlem yapılır.
            DialogResult kapanis = MessageBox.Show("Programı kapatmak istediğinizden eminmisiniz? ", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); 
            if (kapanis == DialogResult.No)     // eğer kullanıcı hayır butonuna tıklarsa 
            {
                e.Cancel = true;
                return;
            }
            Environment.Exit(0);                //evet butonuna tıklarsa program kapatılır.
        }
        //Ana form içerisinde açılacak formlar için Fonksiyon. (MainForm özelliklerinden IsMdiContainer özelliği true ayarlanır)
        void ShowForm(ref Form form)
        {
            Form f = form;
            Form tempform = null;
            foreach (Form child in this.MdiChildren) 
            {
                if (child.Text==f.Text) 
                {
                    tempform = child;
                    break;
                }
                
            }
            if (tempform!=null)
            {
                tempform.BringToFront();        
                
            }
            else
            {
                f.MdiParent = this;
                f.Show();
                f.FormClosed += Oee_FormClosed;
                TabPage tabPage = new TabPage();
                tabPage.Text = f.Text;
                pictureBox2.SendToBack();
                pictureBox1.SendToBack();
                
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        
            pictureBox2.Controls.Add(pictureBox1);
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BringToFront();
            pictureBox1.BringToFront();
        }
        private void MainForm_MdiChildActivate(object sender, EventArgs e)
        {

            if (this.MdiChildren.Count() > 1)
            {
                foreach (Form childForm in this.MdiChildren)
                {
                    if (childForm != this.ActiveMdiChild)
                    {
                        childForm.Close();
                        return;
                    }
                }
            }
        }
                //Takım butonu tıklandığında
        private void takimbtn_Click(object sender, EventArgs e)
        {   
            Form takimE = new TakimEkrani();    //takımekranı formu için takimE adında yeni nesne oluşturuldu.
            ShowForm(ref takimE);               //takimE nesnesi showform fonksiyonunda kullanılarak form açılması sağlanır.
        }

        private void devamsizlikbtn_Click(object sender, EventArgs e)
        {
            Form devamE = new DevamsizlikEkrani(); //Devamsızlıkekranı formu için devamE adında yeni nesne oluşturuldu.
            ShowForm(ref devamE);                 //devamE nesnesi showform fonksiyonunda kullanılarak form açılması sağlanır.
        }

        private void oyuncubtn_Click(object sender, EventArgs e)
        {
            Form oee = new OyuncuEkleEkrani();   //OyuncuEklemeEkranı formu için yeni oee adında yeni nesne oluşturuldu.
            ShowForm(ref oee);                   //oee nesnesi showform fonksiyonunda kullanılarak form açılması sağlanır.
        }
    }
}
