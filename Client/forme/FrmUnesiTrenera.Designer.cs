namespace Client.forme
{
    partial class FrmUnesiTrenera
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
            this.label3 = new System.Windows.Forms.Label();
            this.tbPrezimeTrenera = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.cbGrad = new System.Windows.Forms.ComboBox();
            this.tbImeTrenera = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "Mesto življenja:";
            // 
            // tbPrezimeTrenera
            // 
            this.tbPrezimeTrenera.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbPrezimeTrenera.Location = new System.Drawing.Point(200, 99);
            this.tbPrezimeTrenera.Name = "tbPrezimeTrenera";
            this.tbPrezimeTrenera.Size = new System.Drawing.Size(230, 20);
            this.tbPrezimeTrenera.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Prezime trenera:";
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSacuvaj.Location = new System.Drawing.Point(177, 223);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(114, 29);
            this.btnSacuvaj.TabIndex = 10;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // cbGrad
            // 
            this.cbGrad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbGrad.FormattingEnabled = true;
            this.cbGrad.Location = new System.Drawing.Point(200, 157);
            this.cbGrad.Name = "cbGrad";
            this.cbGrad.Size = new System.Drawing.Size(230, 21);
            this.cbGrad.TabIndex = 9;
            // 
            // tbImeTrenera
            // 
            this.tbImeTrenera.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbImeTrenera.Location = new System.Drawing.Point(200, 39);
            this.tbImeTrenera.Name = "tbImeTrenera";
            this.tbImeTrenera.Size = new System.Drawing.Size(230, 20);
            this.tbImeTrenera.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ime trenera:";
            // 
            // FrmUnesiTrenera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 289);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPrezimeTrenera);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.cbGrad);
            this.Controls.Add(this.tbImeTrenera);
            this.Controls.Add(this.label1);
            this.Name = "FrmUnesiTrenera";
            this.Text = "Unos Trenera";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPrezimeTrenera;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.ComboBox cbGrad;
        private System.Windows.Forms.TextBox tbImeTrenera;
        private System.Windows.Forms.Label label1;
    }
}