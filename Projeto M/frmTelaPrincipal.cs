using Projeto_M.Class;
using Projeto_M.Class01;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Projeto_M
{
    public partial class frmTelaPrincipal : Form
    {
        Conexao con = new Conexao();
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataAdapter da;
        SQLiteDataReader dr;

        LogsDoSistema logs = new LogsDoSistema();

        //Classes Personalizadas
        ExibirTabela tabela = new ExibirTabela(); // Preecher DataGridView
        ListasDeServico listaService = new ListasDeServico();

        private int linhaAtual = 1;

        public string id, numeroSrvico, idNota, idCliente; //Variavel que sera usada no DataGridView

        public string codigoCliente, matriculaUsuario;

        // Variaveis do grupobox Dados Cliente
        public string nomeEmpresa, codCliente, solicitante, emailCliente, contatoCliente, dataSli;

        // Variaveis do grupobox Dados Responsavel MENPLAN
        public string matricula, nomeUsuario, funcao, contatoUsuario, dataAtend;

        //Variaveis do grupobox Dados Serviço
        public string area, local, equipamento, codEquipamento, fabricante, modelo;

        //Variavel do campo Descrição Serviço
        public string descricao;

        //variaveis para solicitação de serviço
        public string usuario_s, matricula_s, funcao_s, contato_s;

        //Nome e Nivel de Acesso do Usuario
        public string usuario, nivel;

        //Variavel para armazer o numero da Nota de Serviço
        public string numeroNota;

        private string idNotaServico;

        //private frmLogin login;

        public frmTelaPrincipal()
        {
            //login = log;
            InitializeComponent();
        }

        Point DragCursor;
        Point DragForm;
        bool Dragging;

        public void DadosCliente()
        {

            dgvClientes.DataSource = tabela.ExibirClientes();
            dgvClientes.Columns[0].Visible = false;
            dgvClientes.Columns[2].Visible = false;
            dgvClientes.Columns[3].Visible = false;
            dgvClientes.Columns[7].Visible = false;
            dgvClientes.Columns[8].Visible = false;
            dgvClientes.Columns[9].Visible = false;
            dgvClientes.Columns[10].Visible = false;
            dgvClientes.Columns[11].Visible = false;
            dgvClientes.Columns[14].Visible = false;
        }

        public void AtualizarSolicitacoes()
        {
            dgvSolicitacoes.DataSource = tabela.ExibirTabelaSolicitacao();
            dgvSolicitacoes.Columns[0].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PopularGridListaServico()
        {
            dgvListaServico.DataSource = tabela.DGVListsDeServico();
            dgvListaServico.Columns[0].Width = 100;
            dgvListaServico.Columns[2].Width = 70;
            dgvListaServico.Columns[5].Width = 100;
        }

        private void btn_listaservico_Click(object sender, EventArgs e)
        {

            if (pnListaServico.Visible == false)
            {
                pnListaServico.Visible = true;
                pnListaServico.Enabled = true;

                pnSolicitacaoServico.Visible = false;
                pnSolicitacaoServico.Enabled = false;

                pnNotaServico.Visible = false;
                pnNotaServico.Enabled = false;

                pnConsultaOrcamento.Visible = false;
                pnConsultaOrcamento.Enabled = false;

                pnCliente.Visible = false;
                pnCliente.Enabled = false;

                pnUsuario.Visible = false;
                pnUsuario.Enabled = false;

                pnPrincipal.Visible = false;
                pnPrincipal.Enabled = false;
            }
            else if (pnListaServico.Visible == true)
            {
                pnListaServico.Visible = false;
                pnPrincipal.Visible = true;
                pnPrincipal.Enabled = true;
            }

            PopularComboboxListaServico();

            PopularGridListaServico();

        }

        private void PopularComboboxListaServico()
        {
            //Combobox Nº Solicitação de Servico
            cbNumeroSolicitacaoListaServico.DataSource = listaService.DadosNumeroSolicitacao();
            cbNumeroSolicitacaoListaServico.DisplayMember = "numero_servico";

            ////Comobox Nº Nota de Serviço
            //cbNumeroNotaListaServico.DataSource = listaService.DadosNotaServico();
            //cbNumeroNotaListaServico.DisplayMember = "numero_nota";

            ////Combobox Nome Cliente
            //cbNomeClienteListaServico.DataSource = listaService.DadosNomeCliente();
            //cbNomeClienteListaServico.DisplayMember = "nome_fantasia";

            ////Comobobox Responsavel Menplan
            //cbResponsavelListaServico.DataSource = listaService.DadosResponsavelMenplan();
            //cbResponsavelListaServico.DisplayMember = "nome"; 
        }

        private void frmNovoMenu_Load(object sender, EventArgs e)
        {

            lbUsuario.Text = usuario;
            lbNivel.Text = nivel;

            logs.Log_AcessoAoSistema("Login", usuario, nivel);

            //Código de restrição de acesso do Programa
            if (nivel == "Técnico")
            {

                //Orçamento Comercial
                btnCriarOrcamento.Enabled = false;
                btn7.Enabled = false;
                btnConsultarOrcamento.Enabled = false;
                btn6.Enabled = false;

                //Cadastro de Usuario
                btnCadastroUsuario.Enabled = false;
                btn1.Enabled = false;
            }
        }

        private void frmNovoMenu_MouseUp(object sender, MouseEventArgs e)
        {
            Dragging = false;
        }

        private void frmNovoMenu_MouseDown(object sender, MouseEventArgs e)
        {
            Dragging = true;
            DragCursor = Cursor.Position;
            DragForm = this.Location;
        }

        private void frmNovoMenu_MouseMove(object sender, MouseEventArgs e)
        {
            if (Dragging == true)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(DragCursor));
                this.Location = Point.Add(DragForm, new Size(dif));
            }
        }

        private void btnSolicatacao_Click(object sender, EventArgs e)
        {

            if (pnSolicitacaoServico.Visible == false)
            {
                pnSolicitacaoServico.Visible = true;
                pnSolicitacaoServico.Enabled = true;

                pnPrincipal.Visible = false;
                pnPrincipal.Enabled = false;

                pnListaServico.Visible = false;
                pnListaServico.Enabled = false;

                pnNotaServico.Visible = false;
                pnNotaServico.Enabled = false;

                pnConsultaOrcamento.Visible = false;
                pnConsultaOrcamento.Enabled = false;

                pnCliente.Visible = false;
                pnCliente.Enabled = false;

                pnUsuario.Visible = false;
                pnUsuario.Enabled = false;

                pnPrincipal.Visible = false;
                pnPrincipal.Enabled = false;

                AtualizarDadosGridSolicitacoes();
                
            }
            else if (pnSolicitacaoServico.Visible == true)
            {
                ExibirMenu();
            }
        }

        private void ExibirMenu()
        {
            pnSolicitacaoServico.Visible = false;
            pnSolicitacaoServico.Enabled = false;

            pnListaServico.Visible = false;
            pnListaServico.Enabled = false;

            pnNotaServico.Visible = false;
            pnNotaServico.Enabled = false;


            pnConsultaOrcamento.Visible = false;
            pnConsultaOrcamento.Enabled = false;

            pnCliente.Visible = false;
            pnCliente.Enabled = false;

            pnUsuario.Visible = false;
            pnUsuario.Enabled = false;

            pnPrincipal.Visible = true;
            pnPrincipal.Enabled = true;
        }

        private void AtualizarDadosGridSolicitacoes()
        {
            //Tabela Solicitação de Servico
            dgvSolicitacoes.DataSource = tabela.ExibirTabelaSolicitacao();
            dgvSolicitacoes.Columns[0].Visible = false;
            dgvSolicitacoes.Columns[2].Visible = false;
            dgvSolicitacoes.Columns[4].Visible = false;
            dgvSolicitacoes.Columns[5].Visible = false;
            dgvSolicitacoes.Columns[6].Visible = false;
            dgvSolicitacoes.Columns[7].Visible = false;
            dgvSolicitacoes.Columns[8].Visible = false;
            dgvSolicitacoes.Columns[9].Visible = false;
            dgvSolicitacoes.Columns[10].Visible = false;
            dgvSolicitacoes.Columns[14].Visible = false;
            dgvSolicitacoes.Columns[15].Visible = false;
            dgvSolicitacoes.Columns[16].Visible = false;

        }

        private void dgvSolicitacaoServico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            linhaAtual = int.Parse(e.RowIndex.ToString());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (pnCliente.Visible == false)
            {
                pnCliente.Visible = true;
                pnNotaServico.Visible = false;
                pnConsultaOrcamento.Visible = false;
                pnUsuario.Visible = false;
                pnListaServico.Visible = false;
                pnPrincipal.Visible = false;

                tbRazaoSocial.Select();
            }
            else if (pnCliente.Visible == true)
            {
                pnCliente.Visible = false;
                pnPrincipal.Visible = true;
            }
        }

        private void checkSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSenha.Checked)
            {
                tbSenha.UseSystemPasswordChar = false;
            }
            else
            {
                tbSenha.UseSystemPasswordChar = true;
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_USUARIO WHERE NOME = @NOME";

                cmd.Parameters.AddWithValue("@NOME", lbUsuario.Text);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    matricula_s = Convert.ToString(dr["matricula"]);
                    usuario_s = (string)dr["nome"];
                    funcao_s = (string)dr["funcao"];
                    contato_s = Convert.ToString(dr["celular"]);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Conectar();
            }

            frmSolicitacaoServico solicitacao = new frmSolicitacaoServico();
            solicitacao.matriucla_s = matricula_s;
            solicitacao.usuario_s = usuario_s;
            solicitacao.funcao_s = funcao_s;
            solicitacao.contato_s = contato_s;
            solicitacao.Show();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (pnNotaServico.Visible == false)
            {
                pnSolicitacaoServico.Visible = true;
                pnNotaServico.Visible = false;
                pnCliente.Visible = false;
                pnConsultaOrcamento.Visible = false;
                pnUsuario.Visible = false;
                pnListaServico.Visible = false;
                pnPrincipal.Visible = false;

                AtualizarDadosGridSolicitacoes();

                
            }
            else if (pnNotaServico.Visible == true)
            {
                pnNotaServico.Visible = false;
                pnPrincipal.Visible = true;
                tbBuscaSolicitacao.Clear();
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (pnListaServico.Visible == false)
            {
                pnListaServico.Visible = true;
                pnNotaServico.Visible = false;
                pnConsultaOrcamento.Visible = false;
                pnCliente.Visible = false;
                pnUsuario.Visible = false;
                pnPrincipal.Visible = false;

                PopularComboboxListaServico();
            }
            else if (pnListaServico.Visible == true)
            {
                pnListaServico.Visible = false;
                pnPrincipal.Visible = true;
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (pnConsultaOrcamento.Visible == false)
            {
                pnConsultaOrcamento.Visible = true;
                pnNotaServico.Visible = false;
                pnCliente.Visible = false;
                pnUsuario.Visible = false;
                pnListaServico.Visible = false;
                pnPrincipal.Visible = false;
            }
            else if (pnConsultaOrcamento.Visible == true)
            {
                pnConsultaOrcamento.Visible = false;
                pnPrincipal.Visible = true;

            }
        }

        private void pbDeslogar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCadastraEmpresa_Click(object sender, EventArgs e)
        {
            if (tbNomeEmpresa.Text == "")
            {
                MessageBox.Show("Preencha o Nome da Empresa!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbNomeEmpresa.Focus();
                return;
            }
            if (!mkbCnpj.MaskFull)
            {
                MessageBox.Show("Preencha o CNPJ!", "Antenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mkbCnpj.Focus();
                return;
            }
            if (tbEmailCliente.Text == "")
            {
                MessageBox.Show("Preencha o Email!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbEmailCliente.Focus();
                return;
            }
            if (!mkbTelefoneCliente.MaskFull)
            {
                MessageBox.Show("Preencha o Contato!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DialogResult resultado = MessageBox.Show("Todas as Informações estão corretas?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (resultado == DialogResult.Yes)
                {
                    GeraNovoID novoID = new GeraNovoID();

                    //Cadastra a Empresa no banco de dados
                    CadastroEmpresa cad = new CadastroEmpresa(novoID.GerarCodigoCliente(), tbRazaoSocial.Text, tbNomeFantasia.Text, tbNomeEmpresa.Text, mkbCnpj.Text, tbSiglaEmpresa.Text, mkbCep.Text, tbLorgradouro.Text,
                        tbNumeroEndereco.Text, tbComplemento.Text, tbBairro.Text, tbCidade.Text, tbUf.Text, tbSetorContato.Text, mkbTelefoneCliente.Text, tbRamal.Text, tbEmailCliente.Text, tbPessoaResponsavel.Text, mkbContatoResponsavel.Text, tbSetorContato.Text);

                    logs.Log_Clientes("Cadastro", usuario, tbNomeFantasia.Text);

                    MessageBox.Show(cad.mensagem, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Limpeza dos campos
                    //TextBox
                    tbRazaoSocial.Clear();
                    tbNomeFantasia.Clear();
                    tbNomeEmpresa.Clear();
                    tbLorgradouro.Clear();
                    tbNumeroEndereco.Clear();
                    tbComplemento.Clear();
                    tbBairro.Clear();
                    tbCidade.Clear();
                    tbUf.Clear();
                    tbRamal.Clear();
                    tbRamal.Clear();
                    tbSetorContato.Clear();
                    tbPessoaResponsavel.Clear();
                    tbEmailCliente.Clear();
                    tbSiglaEmpresa.Clear();
                    tbSite.Clear();

                    //MaskedBox
                    mkbCep.Clear();
                    mkbTelefoneCliente.Clear();
                    mkbContatoResponsavel.Clear();
                    mkbCnpj.Clear();

                    DadosCliente();

                }
                else if (resultado == DialogResult.No)
                {
                    return;
                }
            }
        }

        private void btnAtualizarCliente_Click(object sender, EventArgs e)
        {
            AtualizarEmpresa atualizar = new AtualizarEmpresa();

            atualizar.AtualizarCliente(txtCodigoCliente.Text, txtPessoaResponsavel.Text, txtContatoResponsavel.Text, txtSetorContato.Text, txtTelefone.Text, txtRamal.Text);
            MessageBox.Show(atualizar.mensagem, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            logs.Log_Clientes("Alteracao", usuario, txtNomeFantasia.Text);

            DadosCliente();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            //tabControlCliente.SelectedTab = tabPage3;
            //txtPessoaResponsavel.Focus();

            if (string.IsNullOrEmpty(tbxCodCliente.Text) && string.IsNullOrEmpty(tbCadEmpresa.Text))
            {
                MessageBox.Show("Preencha \"Cod. Cliente\" ou \"Nome da Empresa\" ", "Menssagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (!string.IsNullOrEmpty(tbxCodCliente.Text))
            {
                dgvClientes.DataSource = tabela.BuscarClienteCodigo(tbxCodCliente.Text);

            }
            else if (!string.IsNullOrEmpty(tbCadEmpresa.Text))
            {
                dgvClientes.DataSource = tabela.BuscarClienteNomeEmpresa(tbCadEmpresa.Text);
            }

            if (dgvClientes.Rows.Count == 1)
            {
                MessageBox.Show("Cadastro não encontrado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAtualizarDados_Click(object sender, EventArgs e)
        {
            try
            {
                codCliente = dgvClientes[1, linhaAtual].Value.ToString();

                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_CLIENTE WHERE COD_CLIENTE = '" + codCliente + "'";
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    txtCodigoCliente.Text = (string)dr["cod_cliente"];
                    txtRazaoSocial.Text = (string)dr["razao_social"];
                    txtNomeFantasia.Text = (string)dr["nome_fantasia"];
                    txtNomeEmpresa.Text = (string)dr["nome_empresa"];
                    txtCnpj.Text = (string)dr["cnpj"];
                    txtSiglaEmpresa.Text = (string)dr["sigla_empresa"];
                    txtCep.Text = (string)dr["cep"];
                    txtLorgradouro.Text = (string)dr["lorgradouro"];
                    txtNumero.Text = (string)dr["numero_endereco"];
                    txtComplemento.Text = (string)dr["complemento"];
                    txtBairro.Text = (string)dr["bairro"];
                    txtCidade.Text = (string)dr["cidade"];
                    txtUf.Text = (string)dr["uf"];
                    txtSiteEmpresa.Text = (string)dr["site"];
                    txtTelefone.Text = (string)dr["telefone_cliente"];
                    txtRamal.Text = (string)dr["ramal"];
                    txtEmail.Text = (string)dr["email"];
                    txtPessoaResponsavel.Text = (string)dr["pessoa_responsavel"];
                    txtContatoResponsavel.Text = (string)dr["contato_responsavel"];
                    txtSetorContato.Text = (string)dr["setor_contato"];
                }
                dr.Close();

                tabControlCliente.SelectedTab = tabPage3;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Desconectar();
            }
        }

        private void btnAtualizarTabela_Click(object sender, EventArgs e)
        {
            AtualizarGridNotaDeServico();
        }

        private void btnFiltraOrcamento_Click(object sender, EventArgs e)
        {
            if (tbNumeroNotaConsultaOrcamento.Text == "" && tbNomeClienteCosultaOrcamento.Text == "")
            {
                MessageBox.Show("Preencha os campos Nº Nota Serviço ou Nome Cliente", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (tbNumeroNotaConsultaOrcamento.Text != "")
            {
                dgvConsultaOrcamento.DataSource = tabela.FiltraOrcamento(tbNumeroNotaConsultaOrcamento.Text);
                dgvConsultaOrcamento.Columns[0].Width = 85;
            }

            if (tbNomeClienteCosultaOrcamento.Text != "")
            {
                dgvConsultaOrcamento.DataSource = tabela.FiltrarOrcamento_Nome(tbNomeClienteCosultaOrcamento.Text);
                dgvConsultaOrcamento.Columns[0].Width = 85;
            }


        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            linhaAtual = int.Parse(e.RowIndex.ToString());
        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                matriculaUsuario = dgvUsuarios[0, linhaAtual].Value.ToString();

                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_USUARIO WHERE matricula = '" + matriculaUsuario + "'";
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    tbM_Usuario.Text = (string)dr["matricula"];
                    tbN_Usuario.Text = (string)dr["nome"];
                    cbE_Usuario.Text = (string)dr["especialidade"];
                    cbF_Usuario.Text = (string)dr["funcao"];
                    cbNivel_Usuario.Text = (string)dr["nivel_acesso"];
                    tbD_Usuario.Text = (string)dr["data_nascimento"];
                    tbS_Usuario.Text = (string)dr["sexo"];
                    tbR_Usuario.Text = (string)dr["rg"];
                    tbC_Usuario.Text = (string)dr["cpf"];
                    tbCelular_Usuario.Text = (string)dr["celular"];
                    tbTelefone_Usuario.Text = (string)dr["telefone"];
                    tbEmail_Usuario.Text = (string)dr["email"];
                    tbLinkeDin_Usuario.Text = (string)dr["linkedin"];
                    tbSenha_Usuario.Text = (string)dr["senha"];
                }
                dr.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Desconectar();
            }

            tabControl_Usuarios.SelectedTab = tabPage6;
            btnAtualizarUsuario.Enabled = true;
        }

        private void btnAtualizarUsuario_Click(object sender, EventArgs e)
        {
            AtualizarUsuario usuario = new AtualizarUsuario();

            usuario.AtualizarUser(tbM_Usuario.Text, cbE_Usuario.Text, cbF_Usuario.Text, cbNivel_Usuario.Text, tbCelular_Usuario.Text, tbTelefone_Usuario.Text, tbEmail_Usuario.Text, tbLinkeDin_Usuario.Text, tbSenha_Usuario.Text);
            MessageBox.Show(usuario.mensagem, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

            logs.Log_Funcionarios("Alteracao", this.usuario, tbN_Usuario.Text);

            dgvUsuarios.DataSource = tabela.DadosUsuario();
            tabControl_Usuarios.SelectedTab = tabPage4;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSenha.Checked)
            {
                tbSenha_Usuario.UseSystemPasswordChar = false;
            }
            else
            {
                tbSenha_Usuario.UseSystemPasswordChar = true;
            }

        }

        private void btnExcluirUsuarioSelecionado_Click(object sender, EventArgs e)
        {
            string nomeUser = dgvUsuarios[1, linhaAtual].Value.ToString();

            if (nomeUser == lbUsuario.Text)
            {
                MessageBox.Show("VOCÊ NÃO PODE EXCLUIR UM USUÁRIO QUE ESTA LOGADO", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Desaja o Usuário selecionado?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (resultado == DialogResult.Yes)
            {
                try
                {

                    cmd.Connection = con.Conectar();

                    cmd.CommandText = "DELETE FROM TABELA_USUARIO WHERE MATRICULA = '" + dgvUsuarios.CurrentRow.Cells[0].Value + "' AND NOME = '" + nomeUser + "'";
                    cmd.ExecuteNonQuery();

                    string nomeFuncionario = dgvUsuarios.CurrentRow.Cells[1].Value.ToString();

                    logs.Log_Funcionarios("Exclusao", usuario, nomeFuncionario);

                    MessageBox.Show("Usuário excluido com sucesso!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Desconectar();
                }

                dgvUsuarios.DataSource = tabela.DadosUsuario();
            }
            else if (resultado == DialogResult.No)
            {
                return;
            }
        }

        private void checkSenha_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkSenha.Checked)
            {
                tbSenha.UseSystemPasswordChar = false;
            }
            else
            {
                tbSenha.UseSystemPasswordChar = true;
            }
        }

        private void btnFiltrarUsuarios_Click(object sender, EventArgs e)
        {

            dgvUsuarios.DataSource = tabela.FiltraUsuario_Matricula(tbFiltro_Matricula.Text);

            if (dgvUsuarios.Rows.Count == 1)
            {
                MessageBox.Show("Cadastro não enontrado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }



        }

        private void btnNovaSolicitacao_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_USUARIO WHERE NOME = @NOME";

                cmd.Parameters.AddWithValue("@NOME", lbUsuario.Text);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    matricula_s = Convert.ToString(dr["matricula"]);
                    usuario_s = (string)dr["nome"];
                    funcao_s = (string)dr["funcao"];
                    contato_s = Convert.ToString(dr["celular"]);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Conectar();
            }

            frmSolicitacaoServico solicitacao = new frmSolicitacaoServico();
            solicitacao.matriucla_s = matricula_s;
            solicitacao.usuario_s = usuario_s;
            solicitacao.funcao_s = funcao_s;
            solicitacao.contato_s = contato_s;
            solicitacao.ShowDialog();

            AtualizarDadosGridSolicitacoes();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

        private void btnNota_Click(object sender, EventArgs e)
        {
            CriarNota();
        }

        private void btnExcluirSolicitacao_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Deseja excluir esta Solicitação?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    cmd.Connection = con.Conectar();

                    cmd.CommandText = "DELETE FROM TABELA_SOLICITACAO_SERVICO WHERE NUMERO_SERVICO = '" + dgvSolicitacoes.CurrentRow.Cells[1].Value + "'";
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Solicitação excluida com sucesso!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgvSolicitacoes.DataSource = tabela.ExibirTabelaSolicitacao();
                    dgvSolicitacoes.Columns[0].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Desconectar();
                }
            }
            else if (resultado == DialogResult.No)
            {
                return;
            }
        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            if (tbBuscaSolicitacao.Text == "")
            {
                MessageBox.Show("Digite a numero da Solicitação de serviço", "Anteção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbBuscaSolicitacao.Focus();
                return;
            }

            //Busca na TABELA_SOLICITACAO_SERVICO
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_SOLICITACAO_SERVICO WHERE NUMERO_SERVICO = @NUMERO_SERVICO";

                cmd.Parameters.AddWithValue("@NUMERO_SERVICO", tbBuscaSolicitacao.Text);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    codCliente = Convert.ToString(dr["id_cliente"]);
                    solicitante = (string)dr["solicitante"];
                    matricula = Convert.ToString(dr["matricula_responsavel"]);
                    area = (string)dr["area"];
                    local = (string)dr["local_instalacao"];
                    equipamento = (string)dr["equipamento"];
                    codEquipamento = Convert.ToString(dr["cod_equipamento"]);
                    fabricante = (string)dr["fabricante"];
                    modelo = (string)dr["modelo"];
                    descricao = (string)dr["descricao"];
                    dataSli = Convert.ToString(dr["data_solicitacao"]);
                    dataAtend = Convert.ToString(dr["data_atendimento"]);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Desconectar();
            }

            //Iformações que serao exibidas no Fomulario de Nota de Serviço
            frmNotaServico frmS = new frmNotaServico(); // Instacia do Formulário Nota de Serviço

            //GrupoBox Dados Cliente
            frmS.codCliente = codCliente;
            frmS.solicitante = solicitante;
            frmS.dataSli = dataSli;

            //GrupoBox Dados Responsável MENPLAN
            frmS.matricula = matricula;
            frmS.dataAtend = dataAtend;

            //GrupoBox Dados Serviço
            frmS.area = area;
            frmS.local = local;
            frmS.equipamento = equipamento;
            frmS.codEquipamento = codEquipamento;
            frmS.fabricante = fabricante;
            frmS.modelo = modelo;
            frmS.descricao = descricao;

            //Exibir Formulário Nota de Serviço
            frmS.Show();
        }

        private void dgvSolicitacoes_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            CriarNota();
        }

        private void CriarNota()
        {
            try
            {

                id = dgvSolicitacoes[1, linhaAtual].Value.ToString();

                //cmd.Connection = con.Conectar();

                //cmd.CommandText = "select * from tabela_nota_servico where id_solicitacao = '" + id + "'";
                //dr = cmd.ExecuteReader();

                //while (dr.Read())
                //{
                //    idNotaServico = (string)dr["id_solicitacao"];
                //}
                //dr.Close();

                if (linhaAtual >= 0)
                {
                    ObterDados();
                    frmNotaServico frmN = new frmNotaServico();

                    frmN.idSolicitacao = numeroSrvico;
                    frmN.codCliente = codCliente;
                    frmN.solicitante = solicitante;
                    frmN.matricula = matricula;
                    frmN.area = area;
                    frmN.local = local;
                    frmN.equipamento = equipamento;
                    frmN.codEquipamento = codEquipamento;
                    frmN.fabricante = fabricante;
                    frmN.modelo = modelo;
                    frmN.descricao = descricao;
                    frmN.dataSli = dataSli;
                    frmN.dataAtend = dataAtend;

                    frmN.ShowDialog();
                }

                //if (idNotaServico == id)
                //{
                //    /*MessageBox.Show("Já existe uma \"Nota de Serviço\" para esta solicitacação. \nCrie uma \"Nova Solicitação\" para criar uma nova Nota de Serviço!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;*/
                //}
                //else
                //{
                    
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Desconectar();
            }    
        }

        private void btnExcluirCadastroCliente_Click(object sender, EventArgs e)
        {

            DialogResult resultado = MessageBox.Show("Deseja excluir o cliente selecionado?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    string nameCliente = dgvClientes.CurrentRow.Cells[2].Value.ToString();

                    cmd.Connection = con.Conectar();

                    cmd.CommandText = "DELETE FROM TABELA_CLIENTE WHERE COD_CLIENTE = '" + dgvClientes.CurrentRow.Cells[1].Value + "'";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "DELETE FROM TABELA_SOLICITANTES WHERE FK_CLIENTE = '" + dgvClientes.CurrentRow.Cells[1].Value + "'";
                    cmd.ExecuteNonQuery();

                    logs.Log_Clientes("Exclusao", usuario, nameCliente);

                    MessageBox.Show("Cliente excluido com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    con.Desconectar();
                }
            }
            else if (resultado == DialogResult.No)
            {
                return;
            }

            DadosCliente();

        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            linhaAtual = int.Parse(e.RowIndex.ToString());
        }

        private void btnBuscarListaServico_Click(object sender, EventArgs e)
        {
            dgvListaServico.DataSource = tabela.FiltroListaServico(cbNumeroSolicitacaoListaServico.Text);
            dgvListaServico.Columns[0].Width = 105;
            dgvListaServico.Columns[2].Width = 70;
            dgvListaServico.Columns[5].Width = 100;
        }

        private void btnLimparListaServico_Click(object sender, EventArgs e)
        {
            PopularGridListaServico();
        }

        private void btnAtualizarGridSolicitacoes_Click(object sender, EventArgs e)
        {
            AtualizarDadosGridSolicitacoes();
        }

        private void dgvSolicitacoes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            linhaAtual = int.Parse(e.RowIndex.ToString());
        }

        private void btnVisualizarSolicitacao_Click(object sender, EventArgs e)
        {
            VisualizarSolicitacao();
        }

        private void VisualizarSolicitacao()
        {
            try
            {
                id = dgvSolicitacoes[1, linhaAtual].Value.ToString();

                frmVisualizarSolicitacao frv = new frmVisualizarSolicitacao();

                frv.numeroSolicitacao = id;
                frv.ShowDialog();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn7_Click(object sender, EventArgs e)
        {
            pnPrincipal.Visible = false;
            pnNotaServico.Visible = true;

            AtualizarGridNotaDeServico();
        }

        private void frmTelaPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7)
            {
                Process.Start(@"ConsoleApp1.exe");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            
        }

        private void pnListaServico_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAcessarNota_Click_1(object sender, EventArgs e)
        {
            //if (idNota == "" || linhaAtual < 0)
            //{
            //    MessageBox.Show("Selecione uma Nota para criar o orçamento", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            idNota = dgvNotaServico[0, linhaAtual].Value.ToString();

            try
            {
                if (linhaAtual >= 0)
                {
                    numeroNota = dgvNotaServico[1, linhaAtual].Value.ToString();

                    frmOrcComercial ocr = new frmOrcComercial();

                    ocr.numeroNota = numeroNota;

                    ocr.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Desconectar();
            }
        }

        private void btnSelecionarNota_Click(object sender, EventArgs e)
        {
            if (tbNumeroNotaComercial.Text == "" && tbNomeClienteComercial.Text == "")
            {
                MessageBox.Show("Preencha o Nº Nota Serviço ou Nome do Cliente para filtrar as informações!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbNumeroNotaComercial.Focus();
                return;
            }
            else if (tbNomeClienteComercial.Text == "")
            {
                dgvNotaServico.DataSource = tabela.FiltrarNotaServico(tbNumeroNotaComercial.Text);
                dgvNotaServico.Columns[0].Visible = false;
                dgvNotaServico.Columns[3].Visible = false;
                dgvNotaServico.Columns[4].Visible = false;
                dgvNotaServico.Columns[5].Visible = false;
                dgvNotaServico.Columns[6].Visible = false;
                dgvNotaServico.Columns[8].Visible = false; // Matricula de Usuario
                dgvNotaServico.Columns[9].Visible = false;
                dgvNotaServico.Columns[10].Visible = false;
                dgvNotaServico.Columns[11].Visible = false;
                dgvNotaServico.Columns[12].Visible = false;
                dgvNotaServico.Columns[7].Visible = false;
                dgvNotaServico.Columns[16].Visible = false;
                dgvNotaServico.Columns[17].Visible = false;
                dgvNotaServico.Columns[18].Visible = false;
                dgvNotaServico.Columns[21].Visible = false;
            }
            else if (tbNumeroNotaComercial.Text == "")
            {
                try
                {
                    cmd.Connection = con.Conectar();

                    cmd.CommandText = "SELECT * FROM TABELA_NOTA_SERVICO WHERE N_CLIENTE = '" + tbNomeClienteComercial.Text + "'";
                    cmd.ExecuteNonQuery();

                    da = new SQLiteDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvNotaServico.DataSource = dt;

                    dgvNotaServico.Columns[0].Visible = false;
                    dgvNotaServico.Columns[3].Visible = false;
                    dgvNotaServico.Columns[4].Visible = false;
                    dgvNotaServico.Columns[5].Visible = false;
                    dgvNotaServico.Columns[6].Visible = false;
                    dgvNotaServico.Columns[8].Visible = false; // Matricula de Usuario
                    dgvNotaServico.Columns[9].Visible = false;
                    dgvNotaServico.Columns[10].Visible = false;
                    dgvNotaServico.Columns[11].Visible = false;
                    dgvNotaServico.Columns[12].Visible = false;

                    dgvNotaServico.Columns[7].Visible = false;
                    dgvNotaServico.Columns[16].Visible = false;
                    dgvNotaServico.Columns[17].Visible = false;
                    dgvNotaServico.Columns[18].Visible = false;
                    dgvNotaServico.Columns[21].Visible = false;

                    dgvNotaServico.Columns[1].HeaderText = "Nº Nota";
                    dgvNotaServico.Columns[2].HeaderText = "Nome Cliente";
                    dgvNotaServico.Columns[13].HeaderText = "Area/Setor";
                    dgvNotaServico.Columns[14].HeaderText = "Local";
                    dgvNotaServico.Columns[15].HeaderText = "Equipamento";
                    dgvNotaServico.Columns[19].HeaderText = "Descrição";
                    dgvNotaServico.Columns[20].HeaderText = "Detalhamento";
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Desconectar();
                }
            }
            else if (tbNumeroNotaComercial.Text != null && tbNomeClienteComercial.Text != null)
            {
                MessageBox.Show("Preencha apenas um campo", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbNomeClienteComercial.Clear();
                tbNumeroNotaComercial.Clear();
                return;
            }
        }

        private void dgvNotaServico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            linhaAtual = int.Parse(e.RowIndex.ToString());
        }

        private void dgvNotaServico_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idNota = dgvNotaServico[0, linhaAtual].Value.ToString();

                if (linhaAtual >= 0)
                {
                    numeroNota = dgvNotaServico[1, linhaAtual].Value.ToString();

                    frmOrcComercial ocr = new frmOrcComercial();

                    ocr.numeroNota = numeroNota;

                    ocr.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Desconectar();
            }
        }

        private void btnExcluirNota_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Deseja excluir a Nota selecionada?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    cmd.Connection = con.Conectar();

                    cmd.CommandText = "DELETE FROM TABELA_NOTA_SERVICO WHERE NUMERO_NOTA = '" + dgvNotaServico.CurrentRow.Cells[1].Value + "'";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "DELETE FROM TABELA_MAODEOBRA WHERE N_NOTA_SERV = '" + dgvNotaServico.CurrentRow.Cells[1].Value + "'";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "DELETE FROM TABELA_MATERIAL WHERE N_NOTA_SERV = '" + dgvNotaServico.CurrentRow.Cells[1].Value + "' ";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "DELETE FROM TABELA_RISCOS WHERE N_NOTA = '" + dgvNotaServico.CurrentRow.Cells[1].Value + "'";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "DELETE FROM TABELA_VALORES_ENTRADA WHERE NUMERO_NOTA = '" + dgvNotaServico.CurrentRow.Cells[1].Value + "'";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "DELETE FROM TABELA_CUSTOS_DESPESAS WHERE NUMERO_NOTA = '" + dgvNotaServico.CurrentRow.Cells[1].Value + "'";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "DELETE FROM TABELA_RESUMO_VALORES WHERE NUMERO_NOTA = '" + dgvNotaServico.CurrentRow.Cells[1].Value + "'";
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Nota excluida com sucesso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Desconectar();
                }
            }
            else if (resultado == DialogResult.No)
            {
                return;
            }

            //Tabela Nota de Serviço
            dgvNotaServico.DataSource = tabela.ExibirTabelaNotaServico();
            dgvNotaServico.Columns[0].Visible = false;
            dgvNotaServico.Columns[3].Visible = false;
            dgvNotaServico.Columns[4].Visible = false;
            dgvNotaServico.Columns[5].Visible = false;
            dgvNotaServico.Columns[6].Visible = false;
            dgvNotaServico.Columns[8].Visible = false; // Matricula de Usuario
            dgvNotaServico.Columns[9].Visible = false;
            dgvNotaServico.Columns[10].Visible = false;
            dgvNotaServico.Columns[11].Visible = false;
            dgvNotaServico.Columns[12].Visible = false;
            dgvNotaServico.Columns[7].Visible = false;
            dgvNotaServico.Columns[16].Visible = false;
            dgvNotaServico.Columns[17].Visible = false;
            dgvNotaServico.Columns[18].Visible = false;
            dgvNotaServico.Columns[21].Visible = false;
            dgvNotaServico.Columns[22].Visible = false;
            dgvNotaServico.Columns[23].Visible = false;
            dgvNotaServico.Columns[24].Visible = false;

        }

        private void frmTelaPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnUsuarioSelecionado_Click(object sender, EventArgs e)
        {
            try
            {
                matriculaUsuario = dgvUsuarios[0, linhaAtual].Value.ToString();

                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_USUARIO WHERE matricula = '" + matriculaUsuario + "'";
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    tbM_Usuario.Text = (string)dr["matricula"];
                    tbN_Usuario.Text = (string)dr["nome"];
                    cbE_Usuario.Text = (string)dr["especialidade"];
                    cbF_Usuario.Text = (string)dr["funcao"];
                    cbNivel_Usuario.Text = (string)dr["nivel_acesso"];
                    tbD_Usuario.Text = (string)dr["data_nascimento"];
                    tbS_Usuario.Text = (string)dr["sexo"];
                    tbR_Usuario.Text = (string)dr["rg"];
                    tbC_Usuario.Text = (string)dr["cpf"];
                    tbCelular_Usuario.Text = (string)dr["celular"];
                    tbTelefone_Usuario.Text = (string)dr["telefone"];
                    tbEmail_Usuario.Text = (string)dr["email"];
                    tbLinkedin.Text = (string)dr["linkedin"];
                }
                dr.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Desconectar();
            }

            tabControl_Usuarios.SelectedTab = tabPage6;
            btnAtualizarUsuario.Enabled = true;

        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                linhaAtual = int.Parse(e.RowIndex.ToString());

                idCliente = dgvClientes[0, linhaAtual].Value.ToString();

                if (linhaAtual >= 0)
                {
                    codCliente = dgvClientes[1, linhaAtual].Value.ToString();
                }

                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_CLIENTE WHERE COD_CLIENTE = '" + codCliente + "'";
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    txtCodigoCliente.Text = (string)dr["cod_cliente"];
                    txtRazaoSocial.Text = (string)dr["razao_social"];
                    txtNomeFantasia.Text = (string)dr["nome_fantasia"];
                    txtNomeEmpresa.Text = (string)dr["nome_empresa"];
                    txtCnpj.Text = (string)dr["cnpj"];
                    txtSiglaEmpresa.Text = (string)dr["sigla_empresa"];
                    txtCep.Text = (string)dr["cep"];
                    txtLorgradouro.Text = (string)dr["lorgradouro"];
                    txtNumero.Text = (string)dr["numero_endereco"];
                    txtComplemento.Text = (string)dr["complemento"];
                    txtBairro.Text = (string)dr["bairro"];
                    txtCidade.Text = (string)dr["cidade"];
                    txtUf.Text = (string)dr["uf"];
                    txtSiteEmpresa.Text = (string)dr["site"];
                    txtTelefone.Text = (string)dr["telefone_cliente"];
                    txtRamal.Text = (string)dr["ramal"];
                    txtEmail.Text = (string)dr["email"];
                    txtPessoaResponsavel.Text = (string)dr["pessoa_responsavel"];
                    txtContatoResponsavel.Text = (string)dr["contato_responsavel"];
                    txtSetorContato.Text = (string)dr["setor_contato"];
                }
                dr.Close();

                tabControlCliente.SelectedTab = tabPage3;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Desconectar();
            }
        }

        private void dgvNotasServicoComercial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            linhaAtual = int.Parse(e.RowIndex.ToString());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (pnUsuario.Visible == false)
            {
                pnUsuario.Visible = true;
                pnNotaServico.Visible = false;
                pnCliente.Visible = false;
                pnConsultaOrcamento.Visible = false;
                pnListaServico.Visible = false;
                pnPrincipal.Visible = false;

                tbNomeUsuario.Select();
            }
            else if (pnUsuario.Visible == true)
            {
                pnUsuario.Visible = false;
                pnPrincipal.Visible = true;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            pnListaServico.Visible = false;
            pnNotaServico.Visible = false;
            pnConsultaOrcamento.Visible = false;
            pnCliente.Visible = false;
            pnUsuario.Visible = false;
            pnPrincipal.Visible = false;
            pnSolicitacaoServico.Visible = false;

            pnPrincipal.Visible = true;
            pnPrincipal.Enabled = true;
        }

        private void ObterDados()
        {
            numeroSrvico = dgvSolicitacoes[1, linhaAtual].Value.ToString();
            codCliente = dgvSolicitacoes[2, linhaAtual].Value.ToString();
            solicitante = dgvSolicitacoes[3, linhaAtual].Value.ToString();
            matricula = dgvSolicitacoes[4, linhaAtual].Value.ToString();
            area = dgvSolicitacoes[5, linhaAtual].Value.ToString();
            local = dgvSolicitacoes[6, linhaAtual].Value.ToString();
            equipamento = dgvSolicitacoes[7, linhaAtual].Value.ToString();
            codEquipamento = dgvSolicitacoes[8, linhaAtual].Value.ToString();
            fabricante = dgvSolicitacoes[9, linhaAtual].Value.ToString();
            modelo = dgvSolicitacoes[10, linhaAtual].Value.ToString();
            descricao = dgvSolicitacoes[11, linhaAtual].Value.ToString();
            dataSli = dgvSolicitacoes[12, linhaAtual].Value.ToString();
            dataAtend = dgvSolicitacoes[13, linhaAtual].Value.ToString();
        }

        private void btnCriarNota_Click(object sender, EventArgs e)
        {
            if (pnNotaServico.Visible == false)
            {
                pnNotaServico.Visible = true;
                pnNotaServico.Enabled = true;

                pnSolicitacaoServico.Visible = false;
                pnSolicitacaoServico.Enabled = false;

                pnCliente.Visible = false;
                pnCliente.Enabled = false;

                pnConsultaOrcamento.Visible = false;
                pnConsultaOrcamento.Enabled = false;

                pnUsuario.Visible = false;
                pnUsuario.Enabled = false;

                pnListaServico.Visible = false;
                pnListaServico.Enabled = false;

                pnPrincipal.Visible = false;
                pnPrincipal.Enabled = false;

                AtualizarGridNotaDeServico();
               
            }
            else if (pnNotaServico.Visible == true)
            {
                pnNotaServico.Visible = false;
                pnPrincipal.Visible = true;
                pnPrincipal.Enabled = true;
                tbBuscaSolicitacao.Clear();
            }
        }

        private void AtualizarGridNotaDeServico()
        {
            //Tabela Nota de Serviço
            dgvNotaServico.DataSource = tabela.ExibirTabelaNotaServico();
            dgvNotaServico.Columns[0].Visible = false;
            dgvNotaServico.Columns[3].Visible = false;
            dgvNotaServico.Columns[4].Visible = false;
            dgvNotaServico.Columns[5].Visible = false;
            dgvNotaServico.Columns[6].Visible = false;
            dgvNotaServico.Columns[8].Visible = false; // Matricula de Usuario
            dgvNotaServico.Columns[9].Visible = false;
            dgvNotaServico.Columns[10].Visible = false;
            dgvNotaServico.Columns[11].Visible = false;
            dgvNotaServico.Columns[12].Visible = false;
            dgvNotaServico.Columns[7].Visible = false;
            dgvNotaServico.Columns[16].Visible = false;
            dgvNotaServico.Columns[17].Visible = false;
            dgvNotaServico.Columns[18].Visible = false;
            dgvNotaServico.Columns[21].Visible = false;
            dgvNotaServico.Columns[22].Visible = false;
            dgvNotaServico.Columns[23].Visible = false;
            dgvNotaServico.Columns[24].Visible = false;
            dgvNotaServico.Columns[25].Visible = false;
        }

        private void btnCadastroUsuario_Click(object sender, EventArgs e)
        {
            if (pnUsuario.Visible == false)
            {
                pnUsuario.Visible = true;
                pnUsuario.Enabled = true;

                pnSolicitacaoServico.Visible = false;
                pnSolicitacaoServico.Enabled = false;

                pnNotaServico.Visible = false;
                pnNotaServico.Enabled = false;

                pnCliente.Visible = false;
                pnCliente.Enabled = false;

                pnConsultaOrcamento.Visible = false;
                pnConsultaOrcamento.Enabled = false;

                pnListaServico.Visible = false;
                pnListaServico.Enabled = false;

                pnPrincipal.Visible = false;
                pnPrincipal.Enabled = false;

                //tbNomeUsuario.Select();
                dgvUsuarios.DataSource = tabela.DadosUsuario();
            }
            else if (pnUsuario.Visible == true)
            {
                pnUsuario.Visible = false;
                pnPrincipal.Visible = true;
                pnPrincipal.Enabled = true;
            }
        }

        private void btnCadastroClientes_Click(object sender, EventArgs e)
        {
            if (pnCliente.Visible == false)
            {

                pnCliente.Visible = true;
                pnCliente.Enabled = true;

                pnNotaServico.Visible = false;
                pnNotaServico.Enabled = false;

                pnConsultaOrcamento.Visible = false;
                pnConsultaOrcamento.Enabled = false;

                pnUsuario.Visible = false;
                pnUsuario.Enabled = false;

                pnListaServico.Visible = false;
                pnListaServico.Enabled = false;

                pnPrincipal.Visible = false;
                pnPrincipal.Enabled = false;

                pnSolicitacaoServico.Visible = false;
                pnSolicitacaoServico.Enabled = false;

                DadosCliente();
            }
            else if (pnCliente.Visible == true)
            {
                pnCliente.Visible = false;
                pnPrincipal.Visible = true;
                pnPrincipal.Enabled = true;
            }
        }

        private void btnConsultarOrcamento_Click(object sender, EventArgs e)
        {
            if (pnConsultaOrcamento.Visible == false)
            {
                pnConsultaOrcamento.Visible = true;
                pnConsultaOrcamento.Enabled = true;

                pnSolicitacaoServico.Visible = false;
                pnSolicitacaoServico.Enabled = false;

                pnNotaServico.Visible = false;
                pnNotaServico.Enabled = false;

                pnCliente.Visible = false;
                pnCliente.Enabled = false;

                pnUsuario.Visible = false;
                pnUsuario.Enabled = false;

                pnListaServico.Visible = false;
                pnListaServico.Enabled = false;

                pnPrincipal.Visible = false;
                pnPrincipal.Enabled = false;

                dgvConsultaOrcamento.DataSource = tabela.ConsultaOrcamento();
                dgvConsultaOrcamento.Columns[0].Width = 85;

            }
            else if (pnConsultaOrcamento.Visible == true)
            {
                pnConsultaOrcamento.Visible = false;
                pnPrincipal.Visible = true;
                pnPrincipal.Enabled = true;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (tbNomeUsuario.Text == "")
            {
                MessageBox.Show("Preencha o nome do Usuário", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbNomeUsuario.Focus();
                return;
            }
            if (cbFuncaoUsuario.Text == "")
            {
                MessageBox.Show("Seleciona a função", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbFuncaoUsuario.Focus();
                return;
            }
            if (tbMatriculaUsuario.Text == "")
            {
                MessageBox.Show("Nº de Matricula Obrigatorio", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbMatriculaUsuario.Focus();
                return;
            }
            if (!mkbCelular.MaskFull)
            {
                MessageBox.Show("Preencha o contato do Usuario", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mkbCelular.Focus();
                return;
            }
            else
            {
                //Cadastro do Usuário no Banco de Dados
                CadastroUsuario cad = new CadastroUsuario(tbMatriculaUsuario.Text, tbSenha.Text, cbNivelAcesso.Text, tbNomeUsuario.Text, cbEspecialidade.Text, cbFuncaoUsuario.Text, mkbDataNascimento.Text, cbSexoUsuario.Text, mkbRGUsuario.Text, mkbCPFUsuario.Text, mkbCelular.Text, mkbTelefoneUsuario.Text, tbEmail.Text, tbLinkedin.Text);
                MessageBox.Show(cad.mensagem, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Registro de Log
                logs.Log_Funcionarios("Cadastro", usuario, tbNomeUsuario.Text);

                //Limpeza dos Campos
                //TextBox
                tbSenha.Clear();
                tbMatriculaUsuario.Clear();
                tbNomeUsuario.Clear();
                tbEmail.Clear();
                tbLinkedin.Clear();

                //Combobox
                cbFuncaoUsuario.Text = "";
                cbNivelAcesso.Text = "";
                cbFuncaoUsuario.Text = "";
                cbSexoUsuario.Text = "";
                cbEspecialidade.Text = "";

                //MaskedBox
                mkbDataNascimento.Clear();
                mkbCelular.Clear();
                mkbRGUsuario.Clear();
                mkbCPFUsuario.Clear();
                mkbTelefoneUsuario.Clear();
            }

            dgvUsuarios.DataSource = tabela.DadosUsuario();
            tabControl_Usuarios.SelectedTab = tabPage4;
        }

        private void pbSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //Minimizar Menu Principal
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            pbRestaura.Visible = true;
            pbMaximizar.Visible = false;
        }

        private void pbWindow_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            pbMaximizar.Visible = true;
            pbRestaura.Visible = false;
        }
    }
}
