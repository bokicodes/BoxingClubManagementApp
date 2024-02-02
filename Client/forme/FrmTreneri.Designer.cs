namespace Client.forme
{
    partial class FrmTreneri
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
            this.btnUnesi = new System.Windows.Forms.Button();
            this.btnDetalji = new System.Windows.Forms.Button();
            this.dgvTreneri = new System.Windows.Forms.DataGridView();
            this.tbPretraziTrenere = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreneri)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUnesi
            // 
            this.btnUnesi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUnesi.Location = new System.Drawing.Point(639, 259);
            this.btnUnesi.Name = "btnUnesi";
            this.btnUnesi.Size = new System.Drawing.Size(143, 32);
            this.btnUnesi.TabIndex = 11;
            this.btnUnesi.Text = "Unesi novog trenera";
            this.btnUnesi.UseVisualStyleBackColor = true;
            this.btnUnesi.Click += new System.EventHandler(this.btnUnesi_Click);
            // 
            // btnDetalji
            // 
            this.btnDetalji.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDetalji.Location = new System.Drawing.Point(639, 201);
            this.btnDetalji.Name = "btnDetalji";
            this.btnDetalji.Size = new System.Drawing.Size(143, 30);
            this.btnDetalji.TabIndex = 10;
            this.btnDetalji.Text = "Detalji";
            this.btnDetalji.UseVisualStyleBackColor = true;
            // 
            // dgvTreneri
            // 
            this.dgvTreneri.AllowUserToAddRows = false;
            this.dgvTreneri.AllowUserToDeleteRows = false;
            this.dgvTreneri.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvTreneri.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTreneri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTreneri.Location = new System.Drawing.Point(24, 127);
            this.dgvTreneri.Name = "dgvTreneri";
            this.dgvTreneri.ReadOnly = true;
            this.dgvTreneri.Size = new System.Drawing.Size(594, 297);
            this.dgvTreneri.TabIndex = 9;
            // 
            // tbPretraziTrenere
            // 
            this.tbPretraziTrenere.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbPretraziTrenere.Location = new System.Drawing.Point(202, 84);
            this.tbPretraziTrenere.Name = "tbPretraziTrenere";
            this.tbPretraziTrenere.Size = new System.Drawing.Size(416, 20);
            this.tbPretraziTrenere.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Pretraži trenere po imenu:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Treneri";
            // 
            // FrmTreneri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnUnesi);
            this.Controls.Add(this.btnDetalji);
            this.Controls.Add(this.dgvTreneri);
            this.Controls.Add(this.tbPretraziTrenere);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmTreneri";
            this.Text = "Treneri";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreneri)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUnesi;
        private System.Windows.Forms.Button btnDetalji;
        private System.Windows.Forms.DataGridView dgvTreneri;
        private System.Windows.Forms.TextBox tbPretraziTrenere;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}