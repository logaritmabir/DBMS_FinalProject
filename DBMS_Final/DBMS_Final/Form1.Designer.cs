namespace DBMS_Final
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelKullanici = new System.Windows.Forms.Label();
            this.labelSifre = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonGiris = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelKullanici
            // 
            this.labelKullanici.AutoSize = true;
            this.labelKullanici.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelKullanici.Location = new System.Drawing.Point(75, 105);
            this.labelKullanici.Name = "labelKullanici";
            this.labelKullanici.Size = new System.Drawing.Size(161, 31);
            this.labelKullanici.TabIndex = 0;
            this.labelKullanici.Text = "Kullanıcı Adı";
            // 
            // labelSifre
            // 
            this.labelSifre.AutoSize = true;
            this.labelSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelSifre.Location = new System.Drawing.Point(166, 150);
            this.labelSifre.Name = "labelSifre";
            this.labelSifre.Size = new System.Drawing.Size(70, 31);
            this.labelSifre.TabIndex = 1;
            this.labelSifre.Text = "Şifre";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1.Location = new System.Drawing.Point(258, 105);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(184, 31);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox2.Location = new System.Drawing.Point(258, 153);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(184, 31);
            this.textBox2.TabIndex = 3;
            // 
            // buttonGiris
            // 
            this.buttonGiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonGiris.Location = new System.Drawing.Point(258, 207);
            this.buttonGiris.Name = "buttonGiris";
            this.buttonGiris.Size = new System.Drawing.Size(184, 46);
            this.buttonGiris.TabIndex = 4;
            this.buttonGiris.Text = "Giriş Yap";
            this.buttonGiris.UseVisualStyleBackColor = true;
            this.buttonGiris.Click += new System.EventHandler(this.buttonGiris_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 354);
            this.Controls.Add(this.buttonGiris);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelSifre);
            this.Controls.Add(this.labelKullanici);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labelKullanici;
        public System.Windows.Forms.Label labelSifre;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.Button buttonGiris;
    }
}

