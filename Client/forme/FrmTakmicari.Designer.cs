using System.Windows.Forms;

namespace Client.forme
{
    partial class FrmTakmicari
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbPretraziTakmicare = new System.Windows.Forms.TextBox();
            this.dgvTakmicari = new System.Windows.Forms.DataGridView();
            this.btnDetalji = new System.Windows.Forms.Button();
            this.btnUnesi = new System.Windows.Forms.Button();
            this.btnObrisiTakmicara = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTakmicari)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Takmičari";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pretraži takmičara po imenu:";
            // 
            // tbPretraziTakmicare
            // 
            this.tbPretraziTakmicare.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbPretraziTakmicare.Location = new System.Drawing.Point(195, 86);
            this.tbPretraziTakmicare.Name = "tbPretraziTakmicare";
            this.tbPretraziTakmicare.Size = new System.Drawing.Size(416, 20);
            this.tbPretraziTakmicare.TabIndex = 2;
            this.tbPretraziTakmicare.TextChanged += new System.EventHandler(this.tbPretraziTakmicare_TextChanged);
            // 
            // dgvTakmicari
            // 
            this.dgvTakmicari.AllowUserToAddRows = false;
            this.dgvTakmicari.AllowUserToDeleteRows = false;
            this.dgvTakmicari.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvTakmicari.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTakmicari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTakmicari.Location = new System.Drawing.Point(17, 129);
            this.dgvTakmicari.Name = "dgvTakmicari";
            this.dgvTakmicari.ReadOnly = true;
            this.dgvTakmicari.Size = new System.Drawing.Size(594, 297);
            this.dgvTakmicari.TabIndex = 3;
            // 
            // btnDetalji
            // 
            this.btnDetalji.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDetalji.Location = new System.Drawing.Point(632, 203);
            this.btnDetalji.Name = "btnDetalji";
            this.btnDetalji.Size = new System.Drawing.Size(143, 30);
            this.btnDetalji.TabIndex = 4;
            this.btnDetalji.Text = "Detalji";
            this.btnDetalji.UseVisualStyleBackColor = true;
            this.btnDetalji.Click += new System.EventHandler(this.btnDetalji_Click);
            // 
            // btnUnesi
            // 
            this.btnUnesi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUnesi.Location = new System.Drawing.Point(632, 261);
            this.btnUnesi.Name = "btnUnesi";
            this.btnUnesi.Size = new System.Drawing.Size(143, 32);
            this.btnUnesi.TabIndex = 5;
            this.btnUnesi.Text = "Unesi novog takmičara";
            this.btnUnesi.UseVisualStyleBackColor = true;
            this.btnUnesi.Click += new System.EventHandler(this.btnUnesi_Click);
            // 
            // btnObrisiTakmicara
            // 
            this.btnObrisiTakmicara.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnObrisiTakmicara.Location = new System.Drawing.Point(632, 394);
            this.btnObrisiTakmicara.Name = "btnObrisiTakmicara";
            this.btnObrisiTakmicara.Size = new System.Drawing.Size(143, 32);
            this.btnObrisiTakmicara.TabIndex = 6;
            this.btnObrisiTakmicara.Text = "Obriši takmičara";
            this.btnObrisiTakmicara.UseVisualStyleBackColor = true;
            this.btnObrisiTakmicara.Click += new System.EventHandler(this.btnObrisiTakmicara_Click);
            // 
            // FrmTakmicari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnObrisiTakmicara);
            this.Controls.Add(this.btnUnesi);
            this.Controls.Add(this.btnDetalji);
            this.Controls.Add(this.dgvTakmicari);
            this.Controls.Add(this.tbPretraziTakmicare);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmTakmicari";
            this.Text = "Takmičari";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTakmicari)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPretraziTakmicare;
        private System.Windows.Forms.DataGridView dgvTakmicari;
        private System.Windows.Forms.Button btnDetalji;
        private System.Windows.Forms.Button btnUnesi;
        private System.Windows.Forms.Button btnObrisiTakmicara;

        public Label Label1 { get => label1; set => label1 = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public TextBox TbPretraziTakmicare { get => tbPretraziTakmicare; set => tbPretraziTakmicare = value; }
        public DataGridView DgvTakmicari { get => dgvTakmicari; set => dgvTakmicari = value; }
        public Button BtnDetalji { get => btnDetalji; set => btnDetalji = value; }
        public Button BtnUnesi { get => btnUnesi; set => btnUnesi = value; }
        public Button BtnObrisiTakmicara { get => btnObrisiTakmicara; set => btnObrisiTakmicara = value; }
    }
}