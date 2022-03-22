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

namespace Projeto_M
{
    public partial class frmEditarMaterial : Form
    {
        Conexao con = new Conexao();
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataReader dr;


        public string IDnota, IDitem;
        public string chave;

        public frmEditarMaterial()
        {
            InitializeComponent();
        }

        private void frmEditarMaterial_Load(object sender, EventArgs e)
        {
            if (chave == "Add")
            {
                lbNumeroNota.Text = IDnota;
                ContagemDosItens();
            }
            else
            {
                BuscarDados();
            }
        }

        private void BuscarDados()
        {
            txtNumeroItem.Text = IDitem;
            lbNumeroNota.Text = IDnota;

            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "select * from tabela_material where n_nota_serv = '"+IDnota+"' and n_item_material = '"+IDitem+"'";
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    txtDescricaoMaterial.Text = (string)dr["descricao_material"];
                    cbEspecialidadeMaterial.Text = (string)dr["especialidade_material"];
                    cbUnidadeMaterial.Text = (string)dr["unidade_medida"];
                    txtQuantidade.Text = (string)dr["total_material"];
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro - Buscar info Material", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Desconectar();
            }
        }

        private void ContagemDosItens()
        {
            try
            {
                int numeroItem = 0;

                cmd.Connection = con.Conectar();

                //cmd.CommandText = "SELECT * FROM TABELA_MATERIAL WHERE N_ITEM_MATERIAL = (SELECT Max(N_ITEM_MATERIAL) FROM TABELA_MATERIAL) AND N_NOTA_SERV = '"+IDnota+"'";
                cmd.CommandText = "SELECT * FROM TABELA_MATERIAL WHERE N_NOTA_SERV = '" + IDnota + "' AND N_ITEM_MATERIAL = (SELECT Max(N_ITEM_MATERIAL) FROM TABELA_MATERIAL)";
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    numeroItem = Convert.ToInt32(dr["n_item_material"]);
                    numeroItem++;

                    txtNumeroItem.Text = numeroItem.ToString().PadLeft(2, '0');
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro - Contagem dos Itens", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Desconectar();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {         
            if (chave == "Add")
            {
                AdicionarMaterial();
            }
            else
            {
                AtualizarDados();
            }

            this.Close();
        }

        private void AtualizarDados()
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "update tabela_material set " +
                    "descricao_material = @descricao, " +
                    "especialidade_material = @especialidade, " +
                    "unidade_medida = @unidade_medida, " +
                    "total_material = @total_material " +
                    "where n_nota_serv = @IDnota and n_item_material = @IDitem";

                cmd.Parameters.AddWithValue("@descricao", txtDescricaoMaterial.Text);
                cmd.Parameters.AddWithValue("@especialidade", cbEspecialidadeMaterial.Text);
                cmd.Parameters.AddWithValue("@unidade_medida", cbUnidadeMaterial.Text);
                cmd.Parameters.AddWithValue("@total_material", txtQuantidade.Text);
                cmd.Parameters.AddWithValue("@IDnota", lbNumeroNota.Text);
                cmd.Parameters.AddWithValue("@IDitem", txtNumeroItem.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Item modificado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro - Atualizar Material", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Desconectar();
            }
        }

        private void AdicionarMaterial()
        {
            try
            {
                string valorTotal = "0";

                cmd.Connection = con.Conectar();

                cmd.CommandText = "insert into tabela_material (n_nota_serv, n_item_material, especialidade_material, descricao_material, unidade_medida, total_material, valor_total) values (@nota, @IDitem, @especialidade, @descricao, @unidade_medida, @total_material, @valorTotal)";

                cmd.Parameters.AddWithValue("@descricao", txtDescricaoMaterial.Text);
                cmd.Parameters.AddWithValue("@especialidade", cbEspecialidadeMaterial.Text);
                cmd.Parameters.AddWithValue("@unidade_medida", cbUnidadeMaterial.Text);
                cmd.Parameters.AddWithValue("@total_material", txtQuantidade.Text);
                cmd.Parameters.AddWithValue("@nota", lbNumeroNota.Text);
                cmd.Parameters.AddWithValue("@IDitem", txtNumeroItem.Text);
                cmd.Parameters.AddWithValue("@valorTotal", valorTotal);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Item adicionado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro - Adicionar Material", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Desconectar();
            }
        }
    }


}
