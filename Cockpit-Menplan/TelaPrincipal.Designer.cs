namespace Cockpit_Menplan
{
    partial class TelaPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaPrincipal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lbDataAtual = new System.Windows.Forms.Label();
            this.lbHoraAtual = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timerCockpit = new System.Windows.Forms.Timer(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.btnSharePoint = new System.Windows.Forms.Button();
            this.btnBancodoc = new System.Windows.Forms.Button();
            this.btnServidor = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnSafety4life = new System.Windows.Forms.Button();
            this.btnAppMenplan = new System.Windows.Forms.Button();
            this.btnEmail = new System.Windows.Forms.Button();
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(98)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbDataAtual);
            this.panel1.Controls.Add(this.lbHoraAtual);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Century Gothic", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 88);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(802, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hora:";
            // 
            // lbDataAtual
            // 
            this.lbDataAtual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDataAtual.AutoSize = true;
            this.lbDataAtual.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDataAtual.ForeColor = System.Drawing.Color.White;
            this.lbDataAtual.Location = new System.Drawing.Point(863, 48);
            this.lbDataAtual.Name = "lbDataAtual";
            this.lbDataAtual.Size = new System.Drawing.Size(25, 21);
            this.lbDataAtual.TabIndex = 5;
            this.lbDataAtual.Text = "---";
            // 
            // lbHoraAtual
            // 
            this.lbHoraAtual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbHoraAtual.AutoSize = true;
            this.lbHoraAtual.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHoraAtual.ForeColor = System.Drawing.Color.White;
            this.lbHoraAtual.Location = new System.Drawing.Point(863, 20);
            this.lbHoraAtual.Name = "lbHoraAtual";
            this.lbHoraAtual.Size = new System.Drawing.Size(25, 21);
            this.lbHoraAtual.TabIndex = 4;
            this.lbHoraAtual.Text = "---";
            this.lbHoraAtual.Click += new System.EventHandler(this.lbHoraAtual_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(802, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Data:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(293, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(399, 49);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cock-pit - Menplan";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cockpit_Menplan.Properties.Resources.Logo_Branca;
            this.pictureBox1.Location = new System.Drawing.Point(12, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // timerCockpit
            // 
            this.timerCockpit.Tick += new System.EventHandler(this.timerCockpit_Tick);
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Enabled = false;
            this.button5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(756, 189);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(140, 130);
            this.button5.TabIndex = 5;
            this.button5.Text = "Requisitos Legais";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // btnSharePoint
            // 
            this.btnSharePoint.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSharePoint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSharePoint.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSharePoint.Image = global::Cockpit_Menplan.Properties.Resources.icons8_microsoft_sharepoint_45;
            this.btnSharePoint.Location = new System.Drawing.Point(88, 401);
            this.btnSharePoint.Name = "btnSharePoint";
            this.btnSharePoint.Size = new System.Drawing.Size(140, 130);
            this.btnSharePoint.TabIndex = 10;
            this.btnSharePoint.Text = "SharePoint";
            this.btnSharePoint.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnSharePoint.UseVisualStyleBackColor = true;
            this.btnSharePoint.Click += new System.EventHandler(this.btnSharePoint_Click);
            // 
            // btnBancodoc
            // 
            this.btnBancodoc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBancodoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBancodoc.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBancodoc.Image = global::Cockpit_Menplan.Properties.Resources.icons8_database_45;
            this.btnBancodoc.Location = new System.Drawing.Point(255, 401);
            this.btnBancodoc.Name = "btnBancodoc";
            this.btnBancodoc.Size = new System.Drawing.Size(140, 130);
            this.btnBancodoc.TabIndex = 9;
            this.btnBancodoc.Text = "Bancodoc";
            this.btnBancodoc.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnBancodoc.UseVisualStyleBackColor = true;
            this.btnBancodoc.Click += new System.EventHandler(this.btnBancodoc_Click);
            // 
            // btnServidor
            // 
            this.btnServidor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnServidor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServidor.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServidor.Image = global::Cockpit_Menplan.Properties.Resources.icons8_shared_folder_45;
            this.btnServidor.Location = new System.Drawing.Point(422, 401);
            this.btnServidor.Name = "btnServidor";
            this.btnServidor.Size = new System.Drawing.Size(140, 130);
            this.btnServidor.TabIndex = 8;
            this.btnServidor.Text = "Servidor";
            this.btnServidor.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnServidor.UseVisualStyleBackColor = true;
            this.btnServidor.Click += new System.EventHandler(this.btnServidor_Click);
            // 
            // button9
            // 
            this.button9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button9.Enabled = false;
            this.button9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Image = global::Cockpit_Menplan.Properties.Resources.icons8_storage_45;
            this.button9.Location = new System.Drawing.Point(589, 401);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(140, 130);
            this.button9.TabIndex = 7;
            this.button9.Text = "Estoque";
            this.button9.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button10.Enabled = false;
            this.button10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Image = global::Cockpit_Menplan.Properties.Resources.icons8_pay_date_45;
            this.button10.Location = new System.Drawing.Point(756, 401);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(140, 130);
            this.button10.TabIndex = 6;
            this.button10.Text = "Controle de Atividades";
            this.button10.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Enabled = false;
            this.button4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Image = global::Cockpit_Menplan.Properties.Resources.plano_de_acao;
            this.button4.Location = new System.Drawing.Point(589, 189);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(140, 130);
            this.button4.TabIndex = 4;
            this.button4.Text = "Plano de Ação";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnSafety4life
            // 
            this.btnSafety4life.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSafety4life.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSafety4life.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSafety4life.Image = global::Cockpit_Menplan.Properties.Resources.safety4life;
            this.btnSafety4life.Location = new System.Drawing.Point(422, 189);
            this.btnSafety4life.Name = "btnSafety4life";
            this.btnSafety4life.Size = new System.Drawing.Size(140, 130);
            this.btnSafety4life.TabIndex = 3;
            this.btnSafety4life.Text = "Safety4life";
            this.btnSafety4life.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnSafety4life.UseVisualStyleBackColor = true;
            this.btnSafety4life.Click += new System.EventHandler(this.btnSafety4life_Click);
            // 
            // btnAppMenplan
            // 
            this.btnAppMenplan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAppMenplan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAppMenplan.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAppMenplan.Image = global::Cockpit_Menplan.Properties.Resources.icone_menplan;
            this.btnAppMenplan.Location = new System.Drawing.Point(255, 189);
            this.btnAppMenplan.Name = "btnAppMenplan";
            this.btnAppMenplan.Size = new System.Drawing.Size(140, 130);
            this.btnAppMenplan.TabIndex = 2;
            this.btnAppMenplan.Text = "Solicitação de Serviços";
            this.btnAppMenplan.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnAppMenplan.UseVisualStyleBackColor = true;
            this.btnAppMenplan.Click += new System.EventHandler(this.btnAppMenplan_Click);
            // 
            // btnEmail
            // 
            this.btnEmail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmail.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmail.Image = global::Cockpit_Menplan.Properties.Resources.icons8_email_open_45;
            this.btnEmail.Location = new System.Drawing.Point(88, 189);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(140, 130);
            this.btnEmail.TabIndex = 1;
            this.btnEmail.Text = "E-mail";
            this.btnEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // notify
            // 
            this.notify.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notify_MouseDoubleClick);
            // 
            // TelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.btnSharePoint);
            this.Controls.Add(this.btnBancodoc);
            this.Controls.Add(this.btnServidor);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnSafety4life);
            this.Controls.Add(this.btnAppMenplan);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TelaPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cockpit-Menplan v1.0.0";
            this.Load += new System.EventHandler(this.TelaPrincipal_Load);
            this.Resize += new System.EventHandler(this.TelaPrincipal_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbDataAtual;
        private System.Windows.Forms.Label lbHoraAtual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerCockpit;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Button btnAppMenplan;
        private System.Windows.Forms.Button btnSafety4life;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnSharePoint;
        private System.Windows.Forms.Button btnBancodoc;
        private System.Windows.Forms.Button btnServidor;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label3;
    }
}

