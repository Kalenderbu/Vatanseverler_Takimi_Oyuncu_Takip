
namespace PatriotsTeamAnalysis
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.oyuncubtn = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.takimbtn = new System.Windows.Forms.Button();
            this.devamsizlikbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::PatriotsTeamAnalysis.Properties.Resources.VatanSeverler;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.oyuncubtn);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // oyuncubtn
            // 
            this.oyuncubtn.BackgroundImage = global::PatriotsTeamAnalysis.Properties.Resources.Oebuton1;
            resources.ApplyResources(this.oyuncubtn, "oyuncubtn");
            this.oyuncubtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.oyuncubtn.ForeColor = System.Drawing.Color.Blue;
            this.oyuncubtn.Name = "oyuncubtn";
            this.oyuncubtn.UseVisualStyleBackColor = true;
            this.oyuncubtn.Click += new System.EventHandler(this.oyuncubtn_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PatriotsTeamAnalysis.Properties.Resources._6fc0439c_5fcb_4f61_80e5_11e65247d406;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // takimbtn
            // 
            this.takimbtn.BackColor = System.Drawing.Color.Transparent;
            this.takimbtn.BackgroundImage = global::PatriotsTeamAnalysis.Properties.Resources.Tobuton;
            resources.ApplyResources(this.takimbtn, "takimbtn");
            this.takimbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.takimbtn.Name = "takimbtn";
            this.takimbtn.UseVisualStyleBackColor = false;
            this.takimbtn.Click += new System.EventHandler(this.takimbtn_Click);
            // 
            // devamsizlikbtn
            // 
            this.devamsizlikbtn.BackColor = System.Drawing.Color.Transparent;
            this.devamsizlikbtn.BackgroundImage = global::PatriotsTeamAnalysis.Properties.Resources.ddbuton;
            resources.ApplyResources(this.devamsizlikbtn, "devamsizlikbtn");
            this.devamsizlikbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.devamsizlikbtn.Name = "devamsizlikbtn";
            this.devamsizlikbtn.UseVisualStyleBackColor = false;
            this.devamsizlikbtn.Click += new System.EventHandler(this.devamsizlikbtn_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.devamsizlikbtn);
            this.Controls.Add(this.takimbtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox2);
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MdiChildActivate += new System.EventHandler(this.MainForm_MdiChildActivate);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button oyuncubtn;
        private System.Windows.Forms.Button takimbtn;
        private System.Windows.Forms.Button devamsizlikbtn;
    }
}