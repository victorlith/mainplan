using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Projeto_M.Class;

namespace Projeto_M
{
    
    public partial class frmVisualizarSolicitacao : Form
    {
        Conexao con = new Conexao();
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataReader dr;
        TempoSolicitacao tps;

        public string numeroSolicitacao;

        private string idCliente, matriculaFuncionarioMenplan;

        public frmVisualizarSolicitacao()
        {
            InitializeComponent();
        }

        private void frmVisualizarSolicitacao_Load(object sender, EventArgs e)
        {
            InfoComponentes();

            lbNumeroSolicitacao.Text = numeroSolicitacao;
            BuscarDadosSolicitacao();

        }

        private void InfoComponentes()
        {
            toolTip1.ToolTipTitle = "Info: ";
            toolTip1.SetToolTip(lbTempoSolicitacao, "Tempo de atendimento da solicitação.");
            toolTip1.SetToolTip(label3, "Tempo de atendimento da solicitação.");
        }

        private void cbStatusSolicitacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStatusSolicitacao.Text == "Aprovado")
            {
                cbStatusSolicitacao.BackColor = Color.Lime;
            }
            else if (cbStatusSolicitacao.Text == "Em análise")
            {
                cbStatusSolicitacao.BackColor = Color.Gold;
            }
            else if (cbStatusSolicitacao.Text == "Recusado")
            {
                cbStatusSolicitacao.BackColor = Color.Red;
            }
        }

        private void BuscarDadosSolicitacao()
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "select * from tabela_solicitacao_servico where numero_servico = '"+numeroSolicitacao+"'";
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    idCliente = (string)dr["id_cliente"];
                    lbCodigoCliente.Text = idCliente;
                    matriculaFuncionarioMenplan = (string)dr["matricula_responsavel"];
                    lbMatriculaFuncionario.Text = matriculaFuncionarioMenplan;

                    lbSolicitante.Text = (string)dr["solicitante"];
                    lbContatoCliente.Text = (string)dr["contato_solicitante"];
                    lbEmailCliente.Text = (string)dr["email_solicitante"];
                    lbAreaSetor.Text = (string)dr["area"];
                    lbLocalInstalacao.Text = (string)dr["local_instalacao"];
                    lbEquipamento.Text = (string)dr["equipamento"];
                    lbCodigoEquipamento.Text = (string)dr["cod_equipamento"];
                    lbFabricante.Text = (string)dr["fabricante"];
                    lbModelo.Text = (string)dr["modelo"];
                    lbDataSolicitacao.Text = (string)dr["data_solicitacao"];
                    lbDataAtendimento.Text = (string)dr["data_atendimento"];
                    rtDescricaoNecessidades.Text = (string)dr["descricao"];
                }
                dr.Close();

                cmd.CommandText = "select * from tabela_cliente where cod_cliente = '"+idCliente+"'";
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lbNomeEmpresa.Text = (string)dr["nome_empresa"];                  
                }
                dr.Close();

                cmd.CommandText = "select * from tabela_usuario where matricula = '"+matriculaFuncionarioMenplan+"'";
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lbNomeFuncionario.Text = (string)dr["nome"];
                    lbFuncaoFuncionario.Text = (string)dr["funcao"];
                    lbContatoFuncionario.Text = (string)dr["celular"];
                }
                dr.Close();

                tps = new TempoSolicitacao();
                lbTempoSolicitacao.Text = tps.TempoSoli(lbDataSolicitacao.Text, lbDataAtendimento.Text).ToString().PadLeft(2, '0') + " Dia(s)";
           
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
    }

    public class TempoSolicitacao : CalculoDeHora
    {
        public int TempoSoli(string dtInicial, string dtFinal)
        {
            return CalculoDosDias(dtInicial, dtFinal);
        }
    }
}
