using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace Projeto_M
{
    public partial class frmSolicitacaoServico : Form
    {
        Conexao con = new Conexao();
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataReader dr;
        SQLiteDataAdapter da;

        public string matriucla_s, usuario_s, funcao_s, contato_s;

        private string ID_solicitante;

        public frmSolicitacaoServico()
        {

            InitializeComponent();
        }

        Point DragCursor;
        Point DragForm;
        bool Dragging;

        private void frmSolicitao_Load(object sender, EventArgs e)
        {
            //Gerar numero de nota
            if (tbNumeroSolicitacao.Text == "")
            {
                int numeroSoli = 1;
                tbNumeroSolicitacao.Text = numeroSoli.ToString().PadLeft(4, '0');
            }

            try
            {
                int numero;

                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_SOLICITACAO_SERVICO WHERE NUMERO_SERVICO = (SELECT Max(NUMERO_SERVICO) FROM TABELA_SOLICITACAO_SERVICO)";
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    numero = Convert.ToInt32(dr["numero_servico"]);
                    numero++;

                    tbNumeroSolicitacao.Text = numero.ToString().PadLeft(4, '0');
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

            //Preenche a combobox com o nome dos clientes
            //try
            //{
            //	cmd.Connection = con.conectar();

            //	cmd.CommandText = "SELECT * FROM TABELA_CLIENTE";

            //	da = new SQLiteDataAdapter(cmd);
            //	DataSet ds = new DataSet();
            //	da.Fill(ds);

            //	cbClientes.DataSource = ds.Tables[0];
            //	cbClientes.DisplayMember = "nome_fantasia";
            //	cbClientes.ValueMember = "id";
            //	cbClientes.SelectedItem = "";

            //}
            //catch (Exception ex)
            //{

            //	MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //	con.desconectar();
            //}

            //Gerar();

            //TextBox do grupobox responsavel menplan
            tbMatricula.Text = matriucla_s;
            tbNome.Text = usuario_s;
            tbFuncao.Text = funcao_s;
            mkbContatoUsuario.Text = contato_s;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSolicitacao_MouseUp(object sender, MouseEventArgs e)
        {
            Dragging = false;
        }

        private void frmSolicitacao_MouseDown(object sender, MouseEventArgs e)
        {
            Dragging = true;
            DragCursor = Cursor.Position;
            DragForm = this.Location;
        }

        private void frmSolicitacao_MouseMove(object sender, MouseEventArgs e)
        {
            if (Dragging == true)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(DragCursor));
                this.Location = Point.Add(DragForm, new Size(dif));
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            //if (tbSolicitante.Text == "")
            //{
            //    MessageBox.Show("Preencha o camo (Solicitante)", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            if (string.IsNullOrEmpty(cbClientes.Text) || cbClientes.Text == "-Selecione uma Empresa-")
            {
                tbCodCliente.Clear();
            }

            try
            {
                SolicitacaoServico servico = new SolicitacaoServico();

                if (tbCodCliente.Text == " ")
                {
                    ID_solicitante = servico.SalvarNovoCliente(cbClientes.Text, tbCodCliente.Text, cbSolicitantes.Text, tbEmail.Text, mkbContatoSolicitante.Text);
                }
                else
                {
                    servico.SalvarNovoSolicitante(tbCodCliente.Text, cbSolicitantes.Text, tbEmail.Text, mkbContatoSolicitante.Text);
                }

                //Classe de cadastro dos Dados do Serviço
                servico.SalvarSolicitacao(tbCodCliente.Text, cbSolicitantes.Text, tbMatricula.Text, tbNumeroSolicitacao.Text, tbArea.Text, tbLocal.Text, tbEquipamento.Text, tbCodEquipamento.Text, tbFabricante.Text, tbModelo.Text, rtTexto.Text, dtSolicitacao.Text, dtAtendimento.Text, tbEmail.Text, mkbContatoSolicitante.Text);
                MessageBox.Show(servico.mensagem, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tbArea.Clear();
                tbLocal.Clear();
                tbEquipamento.Clear();
                tbCodEquipamento.Clear();
                tbFabricante.Clear();
                tbModelo.Clear();
                rtTexto.Clear();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_CLIENTE WHERE NOME_EMPRESA = '" + cbClientes.Text + "'";
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    tbCodCliente.Text = Convert.ToString(dr["cod_cliente"]);
                }
                dr.Close();

                ListaDeSolicitantes();
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

        private void cbClientes_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_CLIENTE";

                da = new SQLiteDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                cbClientes.DataSource = ds.Tables[0];
                cbClientes.ValueMember = "id";
                cbClientes.DisplayMember = "nome_empresa";
                cbClientes.SelectedItem = "";
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

        private void ListaDeSolicitantes()
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_SOLICITANTES WHERE FK_CLIENTE = '" + tbCodCliente.Text + "'";

                da = new SQLiteDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                cbSolicitantes.DataSource = ds.Tables[0];
                cbSolicitantes.ValueMember = "id_solicitante";
                cbSolicitantes.DisplayMember = "nome";
                cbSolicitantes.SelectedItem = "";

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

        private void cbClientes_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbClientes.Text))
            {
                tbCodCliente.Clear();
                cbSolicitantes.Text = "";
                tbEmail.Clear();
                mkbContatoSolicitante.Clear();
                
            }
        }

        private void rtTexto_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtTexto.Text))
            {
                lbTotalDeCaracteres.Text = "---";
                return;
            }
            else
            {
                int totalChar = rtTexto.TextLength;
                lbTotalDeCaracteres.Text = totalChar.ToString();

                if (totalChar == 255)
                {
                    lbTotalDeCaracteres.Text = Convert.ToString(totalChar + " MAX");
                }
            }
        }

        private void cbSolicitantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string IDsolicitante = Convert.ToString(cbSolicitantes.SelectedValue);

                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_SOLICITANTES WHERE ID_SOLICITANTE = '" + IDsolicitante + "' and fk_cliente = '"+tbCodCliente.Text+"'";
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    tbEmail.Text = (string)dr["email"];
                    mkbContatoSolicitante.Text = (string)dr["telefone"];
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
        }

        private void cbSolicitantes_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbSolicitantes_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbSolicitantes.Text))
            {
                tbEmail.Clear();
                mkbContatoSolicitante.Clear();
            }
        }

        private void frmSolicitacaoServico_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmTelaPrincipal principal = new frmTelaPrincipal();
            principal.AtualizarSolicitacoes();
        }

        private void tbEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            // Evento ao pressionar a tecla BACKSPACE no campo Nome Empresa
            if (e.KeyValue == 8)
            {
                tbCodCliente.Clear();
                tbSolicitante.Clear();
                tbEmail.Clear();
                mkbContatoSolicitante.Clear();
            }
        }

        private void tbNome_KeyDown(object sender, KeyEventArgs e)
        {
            // Evento ao pressionar a tecla BACKSPACE no campo Nome
            if (e.KeyValue == 8)
            {
                tbMatricula.Clear();
                tbFuncao.Clear();
                mkbContatoUsuario.Clear();
            }
        }
    }
}
