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
using System.Configuration;
using System.Xml;

namespace Projeto_M
{
    public partial class frmVisualizacaoNota : Form
    {
        InfoOrcamento info = new InfoOrcamento();
        Conexao con = new Conexao();
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataReader dr;

        public string numeroNota = "0001";

        public frmVisualizacaoNota()
        {
            InitializeComponent();
        }

        private void frmVisualizacaoNota_Load(object sender, EventArgs e)
        {
            lbNumeroNota.Text = numeroNota;
            //dgvMaoObraComercial.DataSource = info.DadosMaoDeObra();

            LoadConfiguracoes();
            
        }

        private void DadosNotaServico()
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "select * from tabela_nota_servico where numero_nota = '" + numeroNota + "'";
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    //Dados Cliente
                    lbNomeEmpresa.Text = (string)dr["n_cliente"];
                    lbCodigoCliente.Text = (string)dr["n_empresa"];
                    lbSolicitante.Text = (string)dr["n_solicitante"];
                    lbContatoCliente.Text = (string)dr["n_contato"];
                    lbDataSolicitacao.Text = (string)dr["n_data_soli"];
                    lbEmailCliente.Text = (string)dr["n_email"];

                    //Dados Responsavel Menplan
                    lbNomeFuncionario.Text = (string)dr["n_nome"];
                    lbMatriculaFuncionario.Text = (string)dr["n_matricula"];
                    lbFuncaoFuncionario.Text = (string)dr["n_funcao"];
                    lbContatoFuncionario.Text = (string)dr["n_contato2"];
                    lbDataAtendimento.Text = (string)dr["n_data_atend"];

                    //Info Nota
                    lbAreaSetor.Text = (string)dr["n_area"];
                    lbLocalInstalacao.Text = (string)dr["n_local"];
                    lbEquipamento.Text = (string)dr["n_equipamento"];
                    lbCodigoEquipamento.Text = (string)dr["n_cod_equipamento"];
                    lbFabricante.Text = (string)dr["n_fabricante"];
                    lbModelo.Text = (string)dr["n_modelo"];
                    rtDescricaoNecessidades.Text = (string)dr["n_descricao"];
                    rtDetalhamento.Text = (string)dr["n_detalhamento"];
                  
                }
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFiltroOrcamento.Text)
            {
                case "Mão de Obra":
                    pnMaoDeObra.Visible = true;
                    pnMeterial.Visible = false;
                    pnContigencias.Visible = false;
                    pnCustosFinais.Visible = false;
                    break;

                case "Material":
                    pnMaoDeObra.Visible = false;
                    pnMeterial.Visible = true;
                    pnContigencias.Visible = false;
                    pnCustosFinais.Visible = false;
                    break;

                case "Contigência":
                    pnMaoDeObra.Visible = false;
                    pnMeterial.Visible = false;
                    pnContigencias.Visible = true;
                    pnCustosFinais.Visible = false;
                    break;

                case "Custos Finais":
                    pnMaoDeObra.Visible = false;
                    pnMeterial.Visible = false;
                    pnContigencias.Visible = false;
                    pnCustosFinais.Visible = true;
                    break;

            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string tamanho = cbTamanhoTexto.Text;
            string key = "Key0";

            switch (tamanho)
            {
                case "12":
                    lbTextTeste.Text = tamanho;
                    Configuracoes(key, tamanho);;                  
                    break;

                case "14":
                    lbTextTeste.Text = "14";
                    Configuracoes(key, tamanho);
                    break;

                case "18":
                    lbTextTeste.Text = "18";
                    Configuracoes(key, tamanho);
                    break;

                case "20":
                    lbTextTeste.Text = tamanho;
                    Configuracoes(key, tamanho);
                    break;

                

                


            }
        }

        private void Configuracoes(string key, string valor)
        {
            var fileConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var config = fileConfig.AppSettings.Settings;

            if (config[key] == null)
            {
                config.Add(key, valor);
            }
            else
            {
                config[key].Value = valor;
            }

            fileConfig.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(fileConfig.AppSettings.SectionInformation.Name);
        }

        private void LoadConfiguracoes()
        {
            string config = ConfigurationManager.AppSettings.Get("Key0");

            lbTextTeste.Text = config;
        }
    } 

    public class InfoOrcamento : frmOrcComercial
    {
    }
}
