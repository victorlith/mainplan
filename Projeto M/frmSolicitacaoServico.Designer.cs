
namespace Projeto_M
{
	partial class frmSolicitacaoServico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolicitacaoServico));
            this.tbNumeroSolicitacao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rtTexto = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbModelo = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbFabricante = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbCodEquipamento = new System.Windows.Forms.TextBox();
            this.tbLocal = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tbEquipamento = new System.Windows.Forms.TextBox();
            this.tbArea = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbFuncao = new System.Windows.Forms.TextBox();
            this.dtAtendimento = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.mkbContatoUsuario = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbMatricula = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbNome = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbSolicitantes = new System.Windows.Forms.ComboBox();
            this.cbClientes = new System.Windows.Forms.ComboBox();
            this.dtSolicitacao = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.mkbContatoSolicitante = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCodCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSolicitante = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label20 = new System.Windows.Forms.Label();
            this.lbTotalDeCaracteres = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbNumeroSolicitacao
            // 
            this.tbNumeroSolicitacao.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbNumeroSolicitacao.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNumeroSolicitacao.Location = new System.Drawing.Point(668, 93);
            this.tbNumeroSolicitacao.MaxLength = 6;
            this.tbNumeroSolicitacao.Name = "tbNumeroSolicitacao";
            this.tbNumeroSolicitacao.ReadOnly = true;
            this.tbNumeroSolicitacao.Size = new System.Drawing.Size(133, 24);
            this.tbNumeroSolicitacao.TabIndex = 9;
            this.tbNumeroSolicitacao.TabStop = false;
            this.tbNumeroSolicitacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(666, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nº Solicitação Serviço";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(286, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 28);
            this.label1.TabIndex = 7;
            this.label1.Text = "Solicitação de Serviço";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rtTexto);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(13, 396);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(788, 106);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Descrição da Necessidade: ";
            // 
            // rtTexto
            // 
            this.rtTexto.Location = new System.Drawing.Point(6, 34);
            this.rtTexto.MaxLength = 255;
            this.rtTexto.Name = "rtTexto";
            this.rtTexto.Size = new System.Drawing.Size(776, 66);
            this.rtTexto.TabIndex = 13;
            this.rtTexto.Text = "";
            this.rtTexto.TextChanged += new System.EventHandler(this.rtTexto_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbModelo);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.tbFabricante);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.tbCodEquipamento);
            this.groupBox3.Controls.Add(this.tbLocal);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.tbEquipamento);
            this.groupBox3.Controls.Add(this.tbArea);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(13, 305);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(789, 80);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dados Serviço:";
            // 
            // tbModelo
            // 
            this.tbModelo.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbModelo.Location = new System.Drawing.Point(668, 48);
            this.tbModelo.Name = "tbModelo";
            this.tbModelo.Size = new System.Drawing.Size(115, 22);
            this.tbModelo.TabIndex = 12;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(668, 28);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 17);
            this.label19.TabIndex = 21;
            this.label19.Text = "Modelo:";
            // 
            // tbFabricante
            // 
            this.tbFabricante.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFabricante.Location = new System.Drawing.Point(555, 48);
            this.tbFabricante.Name = "tbFabricante";
            this.tbFabricante.Size = new System.Drawing.Size(108, 22);
            this.tbFabricante.TabIndex = 11;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(555, 28);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 17);
            this.label18.TabIndex = 19;
            this.label18.Text = "Fabricante:";
            // 
            // tbCodEquipamento
            // 
            this.tbCodEquipamento.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCodEquipamento.Location = new System.Drawing.Point(441, 48);
            this.tbCodEquipamento.Name = "tbCodEquipamento";
            this.tbCodEquipamento.Size = new System.Drawing.Size(108, 22);
            this.tbCodEquipamento.TabIndex = 10;
            // 
            // tbLocal
            // 
            this.tbLocal.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLocal.Location = new System.Drawing.Point(112, 48);
            this.tbLocal.Name = "tbLocal";
            this.tbLocal.Size = new System.Drawing.Size(167, 22);
            this.tbLocal.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(441, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 17);
            this.label14.TabIndex = 17;
            this.label14.Text = "Cód. Equip.";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(6, 28);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 17);
            this.label17.TabIndex = 10;
            this.label17.Text = "Área/Setor:";
            // 
            // tbEquipamento
            // 
            this.tbEquipamento.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEquipamento.Location = new System.Drawing.Point(285, 48);
            this.tbEquipamento.Name = "tbEquipamento";
            this.tbEquipamento.Size = new System.Drawing.Size(150, 22);
            this.tbEquipamento.TabIndex = 9;
            // 
            // tbArea
            // 
            this.tbArea.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbArea.Location = new System.Drawing.Point(6, 48);
            this.tbArea.Name = "tbArea";
            this.tbArea.Size = new System.Drawing.Size(100, 22);
            this.tbArea.TabIndex = 7;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(285, 28);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(90, 17);
            this.label15.TabIndex = 16;
            this.label15.Text = "Equipamento:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(112, 28);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(110, 17);
            this.label16.TabIndex = 14;
            this.label16.Text = "Local Instalação:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbFuncao);
            this.groupBox2.Controls.Add(this.dtAtendimento);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.mkbContatoUsuario);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.tbMatricula);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.tbNome);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(13, 214);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(788, 80);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dados do Responsável: MENPLAN";
            // 
            // tbFuncao
            // 
            this.tbFuncao.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFuncao.Location = new System.Drawing.Point(369, 48);
            this.tbFuncao.Name = "tbFuncao";
            this.tbFuncao.ReadOnly = true;
            this.tbFuncao.Size = new System.Drawing.Size(180, 22);
            this.tbFuncao.TabIndex = 15;
            this.tbFuncao.TabStop = false;
            // 
            // dtAtendimento
            // 
            this.dtAtendimento.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtAtendimento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtAtendimento.Location = new System.Drawing.Point(668, 48);
            this.dtAtendimento.Name = "dtAtendimento";
            this.dtAtendimento.Size = new System.Drawing.Size(114, 22);
            this.dtAtendimento.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(669, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 17);
            this.label9.TabIndex = 11;
            this.label9.Text = "Data de atend.:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(555, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 17);
            this.label13.TabIndex = 10;
            this.label13.Text = "Contato:";
            // 
            // mkbContatoUsuario
            // 
            this.mkbContatoUsuario.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mkbContatoUsuario.Location = new System.Drawing.Point(555, 48);
            this.mkbContatoUsuario.Mask = "(00) 0000-0000";
            this.mkbContatoUsuario.Name = "mkbContatoUsuario";
            this.mkbContatoUsuario.ReadOnly = true;
            this.mkbContatoUsuario.Size = new System.Drawing.Size(108, 22);
            this.mkbContatoUsuario.TabIndex = 9;
            this.mkbContatoUsuario.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 17);
            this.label12.TabIndex = 10;
            this.label12.Text = "Matricula:";
            // 
            // tbMatricula
            // 
            this.tbMatricula.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMatricula.Location = new System.Drawing.Point(6, 48);
            this.tbMatricula.Name = "tbMatricula";
            this.tbMatricula.ReadOnly = true;
            this.tbMatricula.Size = new System.Drawing.Size(100, 22);
            this.tbMatricula.TabIndex = 6;
            this.tbMatricula.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(112, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 17);
            this.label11.TabIndex = 14;
            this.label11.Text = "Nome:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(369, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 17);
            this.label10.TabIndex = 17;
            this.label10.Text = "Função:";
            // 
            // tbNome
            // 
            this.tbNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNome.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNome.Location = new System.Drawing.Point(112, 48);
            this.tbNome.Name = "tbNome";
            this.tbNome.ReadOnly = true;
            this.tbNome.Size = new System.Drawing.Size(251, 22);
            this.tbNome.TabIndex = 4;
            this.tbNome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNome_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbSolicitantes);
            this.groupBox1.Controls.Add(this.cbClientes);
            this.groupBox1.Controls.Add(this.dtSolicitacao);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.mkbContatoSolicitante);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbEmail);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbCodCliente);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(788, 80);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados Cliente:";
            // 
            // cbSolicitantes
            // 
            this.cbSolicitantes.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSolicitantes.FormattingEnabled = true;
            this.cbSolicitantes.Items.AddRange(new object[] {
            "-Selecione-"});
            this.cbSolicitantes.Location = new System.Drawing.Point(285, 46);
            this.cbSolicitantes.Name = "cbSolicitantes";
            this.cbSolicitantes.Size = new System.Drawing.Size(150, 24);
            this.cbSolicitantes.TabIndex = 10;
            this.cbSolicitantes.Text = "-Selecione-";
            this.cbSolicitantes.SelectedIndexChanged += new System.EventHandler(this.cbSolicitantes_SelectedIndexChanged);
            this.cbSolicitantes.TextChanged += new System.EventHandler(this.cbSolicitantes_TextChanged);
            // 
            // cbClientes
            // 
            this.cbClientes.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbClientes.FormattingEnabled = true;
            this.cbClientes.Items.AddRange(new object[] {
            "-Selecione uma Empresa-"});
            this.cbClientes.Location = new System.Drawing.Point(6, 47);
            this.cbClientes.Name = "cbClientes";
            this.cbClientes.Size = new System.Drawing.Size(167, 24);
            this.cbClientes.TabIndex = 0;
            this.cbClientes.Text = "-Selecione uma Empresa-";
            this.cbClientes.SelectedIndexChanged += new System.EventHandler(this.cbClientes_SelectedIndexChanged);
            this.cbClientes.TextChanged += new System.EventHandler(this.cbClientes_TextChanged);
            this.cbClientes.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbClientes_MouseClick);
            // 
            // dtSolicitacao
            // 
            this.dtSolicitacao.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSolicitacao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSolicitacao.Location = new System.Drawing.Point(668, 48);
            this.dtSolicitacao.Name = "dtSolicitacao";
            this.dtSolicitacao.Size = new System.Drawing.Size(114, 22);
            this.dtSolicitacao.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(669, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "Data Solitação:";
            // 
            // mkbContatoSolicitante
            // 
            this.mkbContatoSolicitante.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mkbContatoSolicitante.Location = new System.Drawing.Point(555, 48);
            this.mkbContatoSolicitante.Mask = "(00) 0 0000-0000";
            this.mkbContatoSolicitante.Name = "mkbContatoSolicitante";
            this.mkbContatoSolicitante.Size = new System.Drawing.Size(108, 22);
            this.mkbContatoSolicitante.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(555, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "Contato:";
            // 
            // tbEmail
            // 
            this.tbEmail.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEmail.Location = new System.Drawing.Point(441, 48);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(108, 22);
            this.tbEmail.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(441, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "E-mail:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(285, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Solicitante:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nome Empresa:";
            // 
            // tbCodCliente
            // 
            this.tbCodCliente.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbCodCliente.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCodCliente.Location = new System.Drawing.Point(179, 48);
            this.tbCodCliente.Name = "tbCodCliente";
            this.tbCodCliente.ReadOnly = true;
            this.tbCodCliente.Size = new System.Drawing.Size(100, 22);
            this.tbCodCliente.TabIndex = 1;
            this.tbCodCliente.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(179, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cód. Cliente:";
            // 
            // tbSolicitante
            // 
            this.tbSolicitante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbSolicitante.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSolicitante.Location = new System.Drawing.Point(651, 25);
            this.tbSolicitante.Name = "tbSolicitante";
            this.tbSolicitante.Size = new System.Drawing.Size(150, 22);
            this.tbSolicitante.TabIndex = 2;
            this.tbSolicitante.Visible = false;
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Image = global::Projeto_M.Properties.Resources.icons8_save_close_30;
            this.btnSalvar.Location = new System.Drawing.Point(695, 508);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(100, 45);
            this.btnSalvar.TabIndex = 14;
            this.btnSalvar.Text = "  Salvar";
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Projeto_M.Properties.Resources.logo_mp;
            this.pictureBox1.Location = new System.Drawing.Point(13, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(16, 505);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(73, 17);
            this.label20.TabIndex = 15;
            this.label20.Text = "Caracteres:";
            // 
            // lbTotalDeCaracteres
            // 
            this.lbTotalDeCaracteres.AutoSize = true;
            this.lbTotalDeCaracteres.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalDeCaracteres.Location = new System.Drawing.Point(95, 505);
            this.lbTotalDeCaracteres.Name = "lbTotalDeCaracteres";
            this.lbTotalDeCaracteres.Size = new System.Drawing.Size(23, 17);
            this.lbTotalDeCaracteres.TabIndex = 16;
            this.lbTotalDeCaracteres.Text = "---";
            // 
            // frmSolicitacaoServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 566);
            this.Controls.Add(this.lbTotalDeCaracteres);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbSolicitante);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbNumeroSolicitacao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSolicitacaoServico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solicitação de Serviço";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSolicitacaoServico_FormClosed);
            this.Load += new System.EventHandler(this.frmSolicitao_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmSolicitacao_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmSolicitacao_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmSolicitacao_MouseUp);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox tbNumeroSolicitacao;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox tbModelo;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox tbFabricante;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox tbCodEquipamento;
		private System.Windows.Forms.TextBox tbLocal;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox tbEquipamento;
		private System.Windows.Forms.TextBox tbArea;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.DateTimePicker dtAtendimento;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.MaskedTextBox mkbContatoUsuario;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox tbMatricula;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox tbNome;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.MaskedTextBox mkbContatoSolicitante;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbEmail;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbSolicitante;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbCodCliente;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbFuncao;
		private System.Windows.Forms.Button btnSalvar;
		private System.Windows.Forms.RichTextBox rtTexto;
		private System.Windows.Forms.DateTimePicker dtSolicitacao;
		private System.Windows.Forms.ComboBox cbClientes;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lbTotalDeCaracteres;
        private System.Windows.Forms.ComboBox cbSolicitantes;
    }
}