namespace Client.forme
{
    partial class FrmUnesiDodelu
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
            this.cbTreneri = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDodajUListu = new System.Windows.Forms.Button();
            this.dgvDodela = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTakmicari = new System.Windows.Forms.ComboBox();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDodela)).BeginInit();
            this.SuspendLayout();
            // 
            // cbTreneri
            // 
            this.cbTreneri.FormattingEnabled = true;
            this.cbTreneri.Location = new System.Drawing.Point(52, 54);
            this.cbTreneri.Name = "cbTreneri";
            this.cbTreneri.Size = new System.Drawing.Size(235, 21);
            this.cbTreneri.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Trener:";
            // 
            // btnDodajUListu
            // 
            this.btnDodajUListu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodajUListu.Location = new System.Drawing.Point(623, 44);
            this.btnDodajUListu.Name = "btnDodajUListu";
            this.btnDodajUListu.Size = new System.Drawing.Size(94, 39);
            this.btnDodajUListu.TabIndex = 2;
            this.btnDodajUListu.Text = "Dodaj u listu";
            this.btnDodajUListu.UseVisualStyleBackColor = true;
            this.btnDodajUListu.Click += new System.EventHandler(this.btnDodajUListu_Click);
            // 
            // dgvDodela
            // 
            this.dgvDodela.AllowUserToAddRows = false;
            this.dgvDodela.AllowUserToDeleteRows = false;
            this.dgvDodela.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDodela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDodela.Location = new System.Drawing.Point(112, 125);
            this.dgvDodela.Name = "dgvDodela";
            this.dgvDodela.ReadOnly = true;
            this.dgvDodela.Size = new System.Drawing.Size(430, 289);
            this.dgvDodela.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(343, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Takmičar:";
            // 
            // cbTakmicari
            // 
            this.cbTakmicari.FormattingEnabled = true;
            this.cbTakmicari.Location = new System.Drawing.Point(346, 54);
            this.cbTakmicari.Name = "cbTakmicari";
            this.cbTakmicari.Size = new System.Drawing.Size(235, 21);
            this.cbTakmicari.TabIndex = 7;
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSacuvaj.Location = new System.Drawing.Point(623, 375);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(94, 39);
            this.btnSacuvaj.TabIndex = 8;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // FrmUnesiDodelu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.cbTakmicari);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvDodela);
            this.Controls.Add(this.btnDodajUListu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbTreneri);
            this.Name = "FrmUnesiDodelu";
            this.Text = "FrmUnesiDodelu";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDodela)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTreneri;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDodajUListu;
        private System.Windows.Forms.DataGridView dgvDodela;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTakmicari;
        private System.Windows.Forms.Button btnSacuvaj;
    }
}