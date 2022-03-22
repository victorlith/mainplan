using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Projeto_M
{
    public partial class frmEditarMaoDeObra : Form
    {
        Conexao con = new Conexao();
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataAdapter da;
        SQLiteDataReader dr;

        CalculoDeHora calculoHora;

        public string numeroNota;

        private int totalDeDias = 0;

        public frmEditarMaoDeObra()
        {
            InitializeComponent();
        }

        private void PopularComboboxMaoDeObra()
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_MAODEOBRA WHERE N_NOTA_SERV = @NOTA";
                cmd.Parameters.AddWithValue("@NOTA", tbNotaServicoComercial.Text);
                dr = cmd.ExecuteReader();

                da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                dt.Load(dr);

                cbItemMaoObra.DataSource = dt;
                cbItemMaoObra.ValueMember = "id_item";
                cbItemMaoObra.DisplayMember = "n_item_maodeobra";
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

        private void MensagemDeErro(string periodo)
        {
            MessageBox.Show("Preencha a Hora Inicial e a Hora Final do (" + periodo + ") ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        private void frmEditarMaoDeObra_Load(object sender, EventArgs e)
        {
            tbNotaServicoComercial.Text = numeroNota;
            PopularComboboxMaoDeObra();
        }

        private void RotinaDeCalculoDeHaras()
        {
            string[] resultadosHora;

            calculoHora = new CalculoDeHora();

            resultadosHora = calculoHora.ResultadoHora(dtInicial1.Text, dtFinal1.Text, tbHoraInicial1.Text, tbHoraFinal1.Text, double.Parse(tbTempoRefeicao1.Text));
            tbTempoRefeicao1.Text = resultadosHora[5];
            tbTotalHs1.Text = resultadosHora[0];
            tbHsNormais1.Text = resultadosHora[1];
            tbHsExtra501.Text = resultadosHora[2];
            tbHsExtra1001.Text = resultadosHora[3];
            totalDeDias = calculoHora.QuantidaDeDeDias();



            if (checkBox2.Checked) //2º Período
            {
                try
                {
                    calculoHora = new CalculoDeHora();
                    resultadosHora = calculoHora.ResultadoHora(dtInicial2.Text, dtFinal2.Text, tbHoraInicial2.Text, tbHoraFinal2.Text, double.Parse(tbTempoRefeicao2.Text));
                    tbTempoRefeicao2.Text = resultadosHora[5];
                    tbTotalHs2.Text = resultadosHora[0];
                    tbHsNormais2.Text = resultadosHora[1];
                    tbHsExtra502.Text = resultadosHora[2];
                    tbHsExtra1002.Text = resultadosHora[3];
                    totalDeDias = calculoHora.QuantidaDeDeDias() + totalDeDias;
                }
                catch (Exception)
                {
                    MensagemDeErro(lbPeriodo2.Text);
                }

            }

            if (checkBox3.Checked) //3º Período
            {
                try
                {
                    calculoHora = new CalculoDeHora();
                    resultadosHora = calculoHora.ResultadoHora(dtInicial3.Text, dtFinal3.Text, tbHoraInicial3.Text, tbHoraFinal3.Text, double.Parse(tbTempoRefeicao3.Text));
                    tbTempoRefeicao3.Text = resultadosHora[5];
                    tbTotalHs3.Text = resultadosHora[0];
                    tbHsNormais3.Text = resultadosHora[1];
                    tbHsExtra503.Text = resultadosHora[2];
                    tbHsExtra1003.Text = resultadosHora[3];
                    totalDeDias = calculoHora.QuantidaDeDeDias() + totalDeDias;
                }
                catch (Exception)
                {
                    MensagemDeErro(lbPeriodo3.Text);
                }
            }

            if (checkBox4.Checked) //4º Período
            {
                try
                {
                    calculoHora = new CalculoDeHora();
                    resultadosHora = calculoHora.ResultadoHora(dtInicial4.Text, dtFinal4.Text, tbHoraInicial4.Text, tbHoraFinal4.Text, double.Parse(tbTempoRefeicao4.Text));
                    tbTempoRefeicao4.Text = resultadosHora[5];
                    tbTotalHs4.Text = resultadosHora[0];
                    tbHsNormais4.Text = resultadosHora[1];
                    tbHsExtra504.Text = resultadosHora[2];
                    tbHsExtra1004.Text = resultadosHora[3];
                    totalDeDias = calculoHora.QuantidaDeDeDias() + totalDeDias;
                }
                catch (Exception)
                {
                    MensagemDeErro(lbPeriodo4.Text);
                }
            }

            if (checkBox5.Checked) //5º Período
            {
                try
                {
                    calculoHora = new CalculoDeHora();
                    resultadosHora = calculoHora.ResultadoHora(dtInicial5.Text, dtFinal5.Text, tbHoraInicial5.Text, tbHoraFinal5.Text, double.Parse(tbTempoRefeicao5.Text));
                    tbTempoRefeicao5.Text = resultadosHora[5];
                    tbTotalHs5.Text = resultadosHora[0];
                    tbHsNormais5.Text = resultadosHora[1];
                    tbHsExtra505.Text = resultadosHora[2];
                    tbHsExtra1005.Text = resultadosHora[3];
                    totalDeDias = calculoHora.QuantidaDeDeDias() + totalDeDias;
                }
                catch (Exception)
                {
                    MensagemDeErro(lbPeriodo5.Text);
                }
            }
        }

        private void SomatoriaDasHoras()
        {
            tbTotalRefeicao.Text = calculoHora.SomaTempoRefeicao(double.Parse(tbTempoRefeicao1.Text), double.Parse(tbTempoRefeicao2.Text), double.Parse(tbTempoRefeicao3.Text), double.Parse(tbTempoRefeicao4.Text), double.Parse(tbTempoRefeicao5.Text)).ToString();
            tbTotalHr.Text = calculoHora.SomaTotalDeHoras(double.Parse(tbTotalHs1.Text), double.Parse(tbTotalHs2.Text), double.Parse(tbTotalHs3.Text), double.Parse(tbTotalHs4.Text), double.Parse(tbTotalHs5.Text)).ToString();
            tbTotalNormais.Text = calculoHora.SomaHoraNormal(double.Parse(tbHsNormais1.Text), double.Parse(tbHsNormais2.Text), double.Parse(tbHsNormais3.Text), double.Parse(tbHsNormais4.Text), double.Parse(tbHsNormais5.Text)).ToString();
            tbTotalExtra50.Text = calculoHora.SomaHoraExtra50(double.Parse(tbHsExtra501.Text), double.Parse(tbHsExtra502.Text), double.Parse(tbHsExtra503.Text), double.Parse(tbHsExtra504.Text), double.Parse(tbHsExtra505.Text)).ToString();
            tbTotalExtra100.Text = calculoHora.SomaHoraExtra100(double.Parse(tbHsExtra1001.Text), double.Parse(tbHsExtra1002.Text), double.Parse(tbHsExtra1003.Text), double.Parse(tbHsExtra1004.Text), double.Parse(tbHsExtra1005.Text)).ToString();
        }

        private void btnCalcularMaoObra_Click(object sender, EventArgs e)
        {
            RotinaDeCalculoDeHaras();
            SomatoriaDasHoras();
        }

        private void cbItemMaoObra_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "select * from tabela_maodeobra where n_nota_serv = '" + tbNotaServicoComercial.Text + "' and n_item_maodeobra = '" + cbItemMaoObra.Text + "'";
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cb_especialidade.Text = (string)dr["especialidade_maodeobra"];
                    cb_funcaoObra.Text = (string)dr["funcao"];
                    tbNomeEspecialista.Text = (string)dr["nome_especialista"];
                    tbTotalRefeicao.Text = (string)dr["tempo_refeicao"];
                    tbTotalHr.Text = (string)dr["total_de_horas"];
                    tbTotalNormais.Text = (string)dr["horas_normais"];
                    tbTotalExtra50.Text = (string)dr["hora_ex50"];
                    tbTotalExtra100.Text = (string)dr["hora_ex100"];
                }
                dr.Close();
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

        private void btnSalvarDadosMaoDeObra_Click(object sender, EventArgs e)
        {
            RotinaDeSalvamento();
        }

        private void RotinaDeSalvamento()
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "update tabela_maodeobra set " +
                    "especialidade_maodeobra = '" + cb_especialidade.Text + "', " +
                    "funcao = '" + cb_funcaoObra.Text + "', " +
                    "nome_especialista = '" + tbNomeEspecialista.Text + "', " +
                    "quantidade_dias = '" + totalDeDias + "', " +
                    "tempo_refeicao = '" + tbTotalRefeicao.Text + "', " +
                    "total_de_horas = '" + tbTotalHr.Text + "', " +
                    "horas_normais = '" + tbTotalNormais.Text + "', " +
                    "hora_ex50 = '" + tbTotalExtra50.Text + "', " +
                    "hora_ex100 = '" + tbTotalExtra100.Text + "' " +
                    "where n_nota_serv = '" + tbNotaServicoComercial.Text + "' and n_item_maodeobra = '" + cbItemMaoObra.Text + "'";
                cmd.ExecuteNonQuery();

                MessageBox.Show("As Horas do Item: " + cbItemMaoObra.Text + " foram editas com sucesso!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                tbTempoRefeicao2.Text = "0";
                dtInicial2.Enabled = true;
                dtFinal2.Enabled = true;
                tbHoraInicial2.ReadOnly = false;
                tbHoraFinal2.ReadOnly = false;
                tbTempoRefeicao2.ReadOnly = false;
                tbTotalHs2.ReadOnly = false;
                tbHsNormais2.ReadOnly = false;
                tbHsExtra502.ReadOnly = false;
                tbHsExtra1002.ReadOnly = false;
            }
            else
            {
                dtInicial2.Enabled = false;
                dtFinal2.Enabled = false;
                tbHoraInicial2.ReadOnly = true;
                tbHoraFinal2.ReadOnly = true;
                tbTempoRefeicao2.ReadOnly = true;
                tbTotalHs2.ReadOnly = true;
                tbHsNormais2.ReadOnly = true;
                tbHsExtra502.ReadOnly = true;
                tbHsExtra1002.ReadOnly = true;

                dtInicial2.ResetText();
                dtFinal2.ResetText();
                tbHoraInicial2.Clear();
                tbHoraFinal2.Clear();
                tbTempoRefeicao2.Text = "0";
                tbHsNormais2.Text = "0";
                tbTotalHs2.Text = "0";
                tbHsExtra502.Text = "0";
                tbHsExtra1002.Text = "0";
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                tbTempoRefeicao3.Text = "0";
                dtInicial3.Enabled = true;
                dtFinal3.Enabled = true;
                tbHoraInicial3.ReadOnly = false;
                tbHoraFinal3.ReadOnly = false;
                tbTempoRefeicao3.ReadOnly = false;
                tbTotalHs3.ReadOnly = false;
                tbHsNormais3.ReadOnly = false;
                tbHsExtra503.ReadOnly = false;
                tbHsExtra1003.ReadOnly = false;
            }
            else
            {
                dtInicial3.Enabled = false;
                dtFinal3.Enabled = false;
                tbHoraInicial3.ReadOnly = true;
                tbHoraFinal3.ReadOnly = true;
                tbTempoRefeicao3.ReadOnly = true;
                tbTotalHs3.ReadOnly = true;
                tbHsNormais3.ReadOnly = true;
                tbHsExtra503.ReadOnly = true;
                tbHsExtra1003.ReadOnly = true;

                dtInicial3.ResetText();
                dtFinal3.ResetText();
                tbHoraInicial3.Clear();
                tbHoraFinal3.Clear();
                tbTempoRefeicao3.Text = "0";
                tbTotalHs3.Text = "0";
                tbHsNormais3.Text = "0";
                tbHsExtra503.Text = "0";
                tbHsExtra1003.Text = "0";
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                tbTempoRefeicao4.Text = "0";
                dtInicial4.Enabled = true;
                dtFinal4.Enabled = true;
                tbHoraInicial4.ReadOnly = false;
                tbHoraFinal4.ReadOnly = false;
                tbTotalHs4.ReadOnly = false;
                tbHsNormais4.ReadOnly = false;
                tbTempoRefeicao4.ReadOnly = false;
                tbHsExtra504.ReadOnly = false;
                tbHsExtra1004.ReadOnly = false;

            }
            else
            {
                dtInicial4.Enabled = false;
                dtFinal4.Enabled = false;
                tbHoraInicial4.ReadOnly = true;
                tbHoraFinal4.ReadOnly = true;
                tbTotalHs4.ReadOnly = true;
                tbHsNormais4.ReadOnly = true;
                tbTempoRefeicao4.ReadOnly = true;
                tbHsExtra504.ReadOnly = true;
                tbHsExtra1004.ReadOnly = true;

                dtInicial4.ResetText();
                dtFinal4.ResetText();
                tbHoraInicial4.Clear();
                tbHoraFinal4.Clear();
                tbTotalHs2.Text = "0";
                tbHsNormais4.Text = "0";
                tbTempoRefeicao4.Text = "0";
                tbHsExtra504.Text = "0";
                tbHsExtra1004.Text = "0";
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                tbTempoRefeicao5.Text = "0";
                dtInicial5.Enabled = true;
                dtFinal5.Enabled = true;
                tbHoraInicial5.ReadOnly = false;
                tbHoraFinal5.ReadOnly = false;
                tbTotalHs5.ReadOnly = false;
                tbHsNormais5.ReadOnly = false;
                tbTempoRefeicao5.ReadOnly = false;
                tbHsExtra505.ReadOnly = false;
                tbHsExtra1005.ReadOnly = false;
            }
            else
            {
                dtInicial5.Enabled = false;
                dtFinal5.Enabled = false;
                tbHoraInicial5.ReadOnly = true;
                tbHoraFinal5.ReadOnly = true;
                tbTotalHs5.ReadOnly = false;
                tbHsNormais5.ReadOnly = true;
                tbTempoRefeicao5.ReadOnly = true;
                tbHsExtra505.ReadOnly = true;
                tbHsExtra1005.ReadOnly = true;

                dtInicial5.ResetText();
                dtFinal5.ResetText();
                tbHoraInicial5.Clear();
                tbHoraFinal5.Clear();
                tbTotalHs2.Text = "0";
                tbHsNormais5.Text = "0";
                tbTempoRefeicao5.Text = "0";
                tbHsExtra505.Text = "0";
                tbHsExtra1005.Text = "0";
            }
        }
    }
}
