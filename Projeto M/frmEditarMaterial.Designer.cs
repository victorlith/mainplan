namespace Projeto_M
{
    partial class frmEditarMaterial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditarMaterial));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lbNumeroNota = new System.Windows.Forms.Label();
            this.txtNumeroItem = new System.Windows.Forms.TextBox();
            this.txtDescricaoMaterial = new System.Windows.Forms.TextBox();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbUnidadeMaterial = new System.Windows.Forms.ComboBox();
            this.cbEspecialidadeMaterial = new System.Windows.Forms.ComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(254, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Numero Nota:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Projeto_M.Properties.Resources.icons8_ok_30__1_;
            this.button1.Location = new System.Drawing.Point(285, 186);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 39);
            this.button1.TabIndex = 2;
            this.button1.Text = "Salvar";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbNumeroNota
            // 
            this.lbNumeroNota.AutoSize = true;
            this.lbNumeroNota.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumeroNota.Location = new System.Drawing.Point(358, 18);
            this.lbNumeroNota.Name = "lbNumeroNota";
            this.lbNumeroNota.Size = new System.Drawing.Size(27, 19);
            this.lbNumeroNota.TabIndex = 3;
            this.lbNumeroNota.Text = "---";
            // 
            // txtNumeroItem
            // 
            this.txtNumeroItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroItem.Location = new System.Drawing.Point(12, 68);
            this.txtNumeroItem.Name = "txtNumeroItem";
            this.txtNumeroItem.ReadOnly = true;
            this.txtNumeroItem.Size = new System.Drawing.Size(56, 24);
            this.txtNumeroItem.TabIndex = 5;
            this.txtNumeroItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDescricaoMaterial
            // 
            this.txtDescricaoMaterial.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricaoMaterial.Location = new System.Drawing.Point(74, 68);
            this.txtDescricaoMaterial.Name = "txtDescricaoMaterial";
            this.txtDescricaoMaterial.Size = new System.Drawing.Size(327, 24);
            this.txtDescricaoMaterial.TabIndex = 6;
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantidade.Location = new System.Drawing.Point(245, 128);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(52, 24);
            this.txtQuantidade.TabIndex = 8;
            this.txtQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "Nº Item:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(70, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "Descrição Material:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(152, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "Unid.:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(241, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 19);
            this.label7.TabIndex = 12;
            this.label7.Text = "Qtd.:";
            // 
            // cbUnidadeMaterial
            // 
            this.cbUnidadeMaterial.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUnidadeMaterial.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbUnidadeMaterial.FormattingEnabled = true;
            this.cbUnidadeMaterial.Items.AddRange(new object[] {
            "M2",
            "CM2",
            "M",
            "CM",
            "UN",
            "CX",
            "PA",
            "PÇ",
            "KG",
            "G",
            "HL",
            "L",
            "M3",
            "ML"});
            this.cbUnidadeMaterial.Location = new System.Drawing.Point(154, 128);
            this.cbUnidadeMaterial.Name = "cbUnidadeMaterial";
            this.cbUnidadeMaterial.Size = new System.Drawing.Size(84, 27);
            this.cbUnidadeMaterial.TabIndex = 15;
            // 
            // cbEspecialidadeMaterial
            // 
            this.cbEspecialidadeMaterial.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEspecialidadeMaterial.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbEspecialidadeMaterial.FormattingEnabled = true;
            this.cbEspecialidadeMaterial.Items.AddRange(new object[] {
            "Mecânica",
            "Elétrica",
            "Automação",
            "Civil",
            "Segurança",
            "Insumo",
            "Caldeiraria"});
            this.cbEspecialidadeMaterial.Location = new System.Drawing.Point(12, 128);
            this.cbEspecialidadeMaterial.Name = "cbEspecialidadeMaterial";
            this.cbEspecialidadeMaterial.Size = new System.Drawing.Size(136, 27);
            this.cbEspecialidadeMaterial.TabIndex = 19;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(8, 106);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(93, 19);
            this.label38.TabIndex = 18;
            this.label38.Text = "Especialidade:";
            // 
            // frmEditarMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 237);
            this.Controls.Add(this.cbEspecialidadeMaterial);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.cbUnidadeMaterial);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.txtDescricaoMaterial);
            this.Controls.Add(this.txtNumeroItem);
            this.Controls.Add(this.lbNumeroNota);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEditarMaterial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Material";
            this.Load += new System.EventHandler(this.frmEditarMaterial_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbNumeroNota;
        private System.Windows.Forms.TextBox txtNumeroItem;
        private System.Windows.Forms.TextBox txtDescricaoMaterial;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbUnidadeMaterial;
        private System.Windows.Forms.ComboBox cbEspecialidadeMaterial;
        private System.Windows.Forms.Label label38;
    }
}