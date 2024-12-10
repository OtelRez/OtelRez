namespace OtelRez.PersonelForm
{
    partial class GirisEkrani
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
            btn_giris = new Button();
            grp_giris = new GroupBox();
            txt_Mail = new TextBox();
            lbl_kullaniciAdi = new Label();
            txt_Sifre = new TextBox();
            lbl_sifre = new Label();
            grp_giris.SuspendLayout();
            SuspendLayout();
            // 
            // btn_giris
            // 
            btn_giris.Location = new Point(344, 289);
            btn_giris.Name = "btn_giris";
            btn_giris.Size = new Size(113, 45);
            btn_giris.TabIndex = 12;
            btn_giris.Text = "GİRİŞ";
            btn_giris.UseVisualStyleBackColor = true;
            btn_giris.Click += btn_giris_Click;
            // 
            // grp_giris
            // 
            grp_giris.Controls.Add(txt_Mail);
            grp_giris.Controls.Add(lbl_kullaniciAdi);
            grp_giris.Controls.Add(txt_Sifre);
            grp_giris.Controls.Add(lbl_sifre);
            grp_giris.Location = new Point(247, 116);
            grp_giris.Name = "grp_giris";
            grp_giris.Size = new Size(306, 147);
            grp_giris.TabIndex = 11;
            grp_giris.TabStop = false;
            // 
            // txt_Mail
            // 
            txt_Mail.Location = new Point(144, 38);
            txt_Mail.Name = "txt_Mail";
            txt_Mail.Size = new Size(125, 27);
            txt_Mail.TabIndex = 2;
            // 
            // lbl_kullaniciAdi
            // 
            lbl_kullaniciAdi.AutoSize = true;
            lbl_kullaniciAdi.ForeColor = Color.Black;
            lbl_kullaniciAdi.Location = new Point(75, 41);
            lbl_kullaniciAdi.Name = "lbl_kullaniciAdi";
            lbl_kullaniciAdi.Size = new Size(45, 20);
            lbl_kullaniciAdi.TabIndex = 0;
            lbl_kullaniciAdi.Text = "Mail :";
            // 
            // txt_Sifre
            // 
            txt_Sifre.Location = new Point(144, 89);
            txt_Sifre.Name = "txt_Sifre";
            txt_Sifre.Size = new Size(125, 27);
            txt_Sifre.TabIndex = 3;
            // 
            // lbl_sifre
            // 
            lbl_sifre.AutoSize = true;
            lbl_sifre.ForeColor = Color.Black;
            lbl_sifre.Location = new Point(75, 92);
            lbl_sifre.Name = "lbl_sifre";
            lbl_sifre.Size = new Size(46, 20);
            lbl_sifre.TabIndex = 1;
            lbl_sifre.Text = "Şifre :";
            // 
            // GirisEkrani
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_giris);
            Controls.Add(grp_giris);
            Name = "GirisEkrani";
            Text = "GirisEkrani";
            grp_giris.ResumeLayout(false);
            grp_giris.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btn_giris;
        private GroupBox grp_giris;
        private TextBox txt_Mail;
        private Label lbl_kullaniciAdi;
        private TextBox txt_Sifre;
        private Label lbl_sifre;
    }
}