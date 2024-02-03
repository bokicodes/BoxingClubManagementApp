namespace Client.forme
{
    partial class FrmDodela
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnUnesi = new System.Windows.Forms.Button();
            this.btnDetalji = new System.Windows.Forms.Button();
            this.dgvDodela = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDodela)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(150, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Dodeljeni takmičari i treneri";
            // 
            // btnUnesi
            // 
            this.btnUnesi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUnesi.Location = new System.Drawing.Point(580, 280);
            this.btnUnesi.Name = "btnUnesi";
            this.btnUnesi.Size = new System.Drawing.Size(143, 32);
            this.btnUnesi.TabIndex = 14;
            this.btnUnesi.Text = "Unesi novu dodelu";
            this.btnUnesi.UseVisualStyleBackColor = true;
            this.btnUnesi.Click += new System.EventHandler(this.btnUnesi_Click);
            // 
            // btnDetalji
            // 
            this.btnDetalji.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDetalji.Location = new System.Drawing.Point(580, 190);
            this.btnDetalji.Name = "btnDetalji";
            this.btnDetalji.Size = new System.Drawing.Size(143, 30);
            this.btnDetalji.TabIndex = 13;
            this.btnDetalji.Text = "Izmeni dodelu";
            this.btnDetalji.UseVisualStyleBackColor = true;
            // 
            // dgvDodela
            // 
            this.dgvDodela.AllowUserToAddRows = false;
            this.dgvDodela.AllowUserToDeleteRows = false;
            this.dgvDodela.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDodela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDodela.Location = new System.Drawing.Point(96, 101);
            this.dgvDodela.Name = "dgvDodela";
            this.dgvDodela.ReadOnly = true;
            this.dgvDodela.Size = new System.Drawing.Size(430, 289);
            this.dgvDodela.TabIndex = 15;
            // 
            // FrmDodela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvDodela);
            this.Controls.Add(this.btnUnesi);
            this.Controls.Add(this.btnDetalji);
            this.Controls.Add(this.label1);
            this.Name = "FrmDodela";
            this.Text = "FrmDodela";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDodela)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUnesi;
        private System.Windows.Forms.Button btnDetalji;
        private System.Windows.Forms.DataGridView dgvDodela;
    }
}