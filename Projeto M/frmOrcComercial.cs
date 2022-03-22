using Projeto_M.Class01;
using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace Projeto_M
{
    public partial class frmOrcComercial : Form
    {
        Conexao con = new Conexao();
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataAdapter da;
        SQLiteDataReader dr;
        DataTable dte;

        public string numeroNota;

        //Variavei para calculo dos items da mao de obra
        public double totalHoraNormal, totalHora50, totalHora100, tempoRefeicao, totaldeDias;

        //Variaveis para calulo dos itens do campo material
        public double totalMaterial, calcTotalMaterial;
        public double calculo1, calculo2, calculo3, calculo4, calculo5;

        //Variaveis de modificação
        public double mod1, mod2, mod3, mod4;

        public string notaServ, subtotalMaoDeObra, subtotalMaterial, subtotalContigencia;

        private string pathAnexo;

        private int linhaAtual;

        public frmOrcComercial()
        {
            InitializeComponent();
        }

        public object DadosMaoDeObra(string nota)
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_MAODEOBRA WHERE N_NOTA_SERV = '" + nota + "'";
                cmd.ExecuteNonQuery();

                da = new SQLiteDataAdapter(cmd);
                dte = new DataTable();
                da.Fill(dte);

                //Renomeia as Colunas
                dte.Columns[2].ColumnName = " Nº\nItem";
                dte.Columns[3].ColumnName = " Especialidade";
                dte.Columns[4].ColumnName = " Função";
                dte.Columns[5].ColumnName = " Nome Especialista";
                dte.Columns[6].ColumnName = " Qtd. Dias";
                dte.Columns[7].ColumnName = " Tp. Refeição";
                dte.Columns[8].ColumnName = " Total de Horas";
                dte.Columns[9].ColumnName = " Hr Normais";
                dte.Columns[10].ColumnName = " Hr Extra 50%";
                dte.Columns[11].ColumnName = " Hr Extra 100%";
                dte.Columns[12].ColumnName = " Total Hr Normais";
                dte.Columns[13].ColumnName = " Total Hr Extra 50%";
                dte.Columns[14].ColumnName = " Total Hr Extra 100%";
                dte.Columns[15].ColumnName = " Valor Hr Normais";
                dte.Columns[16].ColumnName = " Valor Hr Extra 50%";
                dte.Columns[17].ColumnName = " Valor Hr Extra 100%";
                dte.Columns[18].ColumnName = " Valor Total Hr Normais";
                dte.Columns[19].ColumnName = " Valor Total Hr EX 50%";
                dte.Columns[20].ColumnName = " Valor Total Hr EX 100%";
                dte.Columns[21].ColumnName = " Valor Refeição";
                dte.Columns[22].ColumnName = " Valor Total Refeição";
                dte.Columns[23].ColumnName = " Valor Total Horas";
                dte.Columns[24].ColumnName = " Valor Total";
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Desconectar();
            }

            return dte;
        }

        private void GridMaoDeObra()
        {
            dgvMaoObraComercial.DataSource = DadosMaoDeObra(tbNotaServicoComercial.Text);

            //Oculta as colunas ID_ITEM e Numero da Nota
            dgvMaoObraComercial.Columns[0].Visible = false;
            dgvMaoObraComercial.Columns[1].Visible = false;
            dgvMaoObraComercial.Columns[25].Visible = false;
            dgvMaoObraComercial.Columns[26].Visible = false;
            dgvMaoObraComercial.Columns[27].Visible = false;
            dgvMaoObraComercial.Columns[28].Visible = false;
            dgvMaoObraComercial.Columns[29].Visible = false;
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void DadosMaterial()
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_MATERIAL WHERE N_NOTA_SERV = '" + tbNotaServicoComercial.Text + "'";
                cmd.ExecuteNonQuery();

                da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvMaterialComercial.DataSource = dt;

                //Oculta a Coluna ID e Numero da Nota
                dgvMaterialComercial.Columns[0].Visible = false;
                dgvMaterialComercial.Columns[1].Visible = false;

                //Renomeia as colunas
                dgvMaterialComercial.Columns[2].HeaderText = "Nº Item";
                dgvMaterialComercial.Columns[3].HeaderText = "Especialidade";
                dgvMaterialComercial.Columns[4].HeaderText = "Descrição";
                dgvMaterialComercial.Columns[5].HeaderText = "Unid. Medida";
                dgvMaterialComercial.Columns[6].HeaderText = "Total Material";
                dgvMaterialComercial.Columns[7].HeaderText = "Valor Unitário";
                dgvMaterialComercial.Columns[8].HeaderText = "Subtotal Material";
                dgvMaterialComercial.Columns[9].HeaderText = "Valor Frete";
                //
                dgvMaterialComercial.Columns[10].HeaderText = "% ICMS";
                dgvMaterialComercial.Columns[10].Visible = false;
                dgvMaterialComercial.Columns[11].HeaderText = "Total ICMS";
                dgvMaterialComercial.Columns[11].Visible = false;
                dgvMaterialComercial.Columns[12].HeaderText = "% IPI";
                dgvMaterialComercial.Columns[12].Visible = false;
                dgvMaterialComercial.Columns[13].HeaderText = "Total IPI";
                dgvMaterialComercial.Columns[13].Visible = false;
                dgvMaterialComercial.Columns[14].HeaderText = "% Variação Preço";
                dgvMaterialComercial.Columns[14].Visible = false;
                dgvMaterialComercial.Columns[15].HeaderText = "Total Variação Preço";
                dgvMaterialComercial.Columns[15].Visible = false;
                //
                dgvMaterialComercial.Columns[16].HeaderText = "Valor Total";


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

        private void DadosContigencia()
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_RISCOS WHERE N_NOTA = '" + tbNotaServicoComercial.Text + "'";
                cmd.ExecuteNonQuery();

                da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvContigencia.DataSource = dt;

                dgvContigencia.Columns[0].Visible = false;
                dgvContigencia.Columns[1].Visible = false;
                dgvContigencia.Columns[2].HeaderText = "Nº Item";
                dgvContigencia.Columns[3].HeaderText = "Descrição Risco/Necessidade";
                dgvContigencia.Columns[4].HeaderText = "Ação de Bloqueio do Risco/Necessidade";
                dgvContigencia.Columns[5].HeaderText = "Custo";
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

        private void btnLimparItemMaoDeObra_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Deseja limpar o item selecionado?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    string nulo = "0";

                    cmd.Connection = con.Conectar();

                    cmd.CommandText = "UPDATE TABELA_MAODEOBRA SET VALOR_HORAS_NORMAIS = '" + nulo + "', VALOR_HR_EX50 = '" + nulo + "', VALOR_HR_EX100 = '" + nulo + "', " +
                            "VALOR_TOTAL_HR_NORMAIS = '" + nulo + "', VALOR_TOTAL_HR_EX50 = '" + nulo + "', VALOR_TOTAL_HR_EX100 = '" + nulo + "', VALOR_REFEICAO = '" + nulo + "', TOTAL_REFEICAO = '" + nulo + "', " +
                            "TOTAL_GERAL = '" + nulo + "' WHERE N_ITEM_MAODEOBRA = '" + dgvMaoObraComercial.CurrentRow.Cells[2].Value + "' AND N_NOTA_SERV = '"+tbNotaServicoComercial.Text+"'";
                    cmd.ExecuteNonQuery();

                    tbSubTotalMaoObra.Text = "0,00";

                    MessageBox.Show("Todos os valores foram limpos!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
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
            else
            {

            }

            GridMaoDeObra();
        }

        private void btnLimparItemMaterial_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Deseja limpar o item selecionado?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    string nulo = "0";

                    cmd.Connection = con.Conectar();

                    cmd.CommandText = "UPDATE TABELA_MATERIAL SET valor_unitario = '" + nulo + "', subtotal_material = '" + nulo + "', valor_frete = '" + nulo + "', " +
                        "icms = '" + nulo + "', total_icms = '" + nulo + "', ipi = '" + nulo + "', total_ipi = '" + nulo + "', variacao_preco = '" + nulo + "', total_variacao = '" + nulo + "', " +
                        "valor_total = '" + nulo + "' WHERE N_ITEM_MATERIAL = " + dgvMaterialComercial.CurrentRow.Cells[2].Value;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Todos os valores foram limpados!", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tbValorTotalMaterial.Text = "0,00";
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
            else
            {
                return;
            }

            DadosMaterial();
        }

        private void btnAnexar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Title = "Selecionar Arquivo";
            dlg.InitialDirectory = @"C:\";
            dlg.Filter = "All Files (*.*) | *.*";
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {               
                if (listaAnexos.Items.Count >= 5)
                {
                    MessageBox.Show("Limite máximo de anexos atingido!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    string file = dlg.FileName;
                    string arquivo1 = Path.GetFileName(file);

                    listaAnexos.Items.Add(arquivo1);

                    for (int i = 0; i <= listaAnexos.Items.Count - 1; i++)
                    {
                        //string origem = listaAnexos.Items[i].SubItems[0].Text;
                        string arquivo = Path.GetFileName(file);
                        string destino = Path.Combine(PastaDestino.CaminhoAnexo(), arquivo);

                        File.Copy(file, destino, true);
                    }
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            string arquivo = listaAnexos.SelectedItems[0].SubItems[0].Text;
            string destino = Path.Combine(PastaDestino.CaminhoAnexo(), arquivo);

            File.Delete(destino);

            listaAnexos.Items.RemoveAt(listaAnexos.SelectedIndices[0]);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbHoraNormais.Text = "0";
            tbRefeicao.Text = "0";
        }

        private void btnLimparCamposMaterial_Click(object sender, EventArgs e)
        {
            tbValorUnitario.Clear();
            tbValorFrete.Clear();
        }

        private void btnAdicionaContigencia_Click(object sender, EventArgs e)
        {
            if (tbCustoContigencia.Text == "")
            {
                MessageBox.Show("Preencha o campo (Custo)!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbCustoContigencia.Focus();
                return;
            }

            try
            {
                cmd.Connection = con.Conectar();

                double custo = Double.Parse(tbCustoContigencia.Text);

                cmd.CommandText = "UPDATE TABELA_RISCOS SET CUSTO_RISCO = '" + custo.ToString("F2") + "' WHERE N_NOTA = '" + tbNotaServicoComercial.Text + "' AND N_ITEM_RISCO = '" + cbItemContigencia.Text + "'";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Desconectar();
            }

            DadosContigencia();

            tbCustoContigencia.Clear();

            double somaItens = 0;
            foreach (DataGridViewRow custo in dgvContigencia.Rows)
            {
                somaItens = somaItens + Convert.ToDouble(custo.Cells[5].Value);
            }
            tbSubTotalContigencia.Text = somaItens.ToString("F2");

        }

        private void custosFinaisToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbNotaServicoComercial.Text = numeroNota; //TextBox recebe o Nº da Nota de Serviço

            //Metodo para criar a pasta da Nota de Serviço
            //PastaDestino.PastaDaCotacao(numeroNota);

            if (tbNotaServicoComercial.Text == "")
            {
                this.Close();
                MessageBox.Show("É necessário criar a Nota de Serviço primeiro!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Preenche o DataGrideView da Mão de Obra
            GridMaoDeObra();

            //Preenche o DataGridView do grupobox Material
            DadosMaterial();

            //Preenche o DataGridView do grupobox Contigência
            DadosContigencia();

            //Soma a coluna total geral - Mão de Obra
            SomarMaoDeObra();

            //Soma a coluna total geral - Material 
            double somaTotalMaterial = 0;
            foreach (DataGridViewRow col in dgvMaterialComercial.Rows)
            {

                somaTotalMaterial += Convert.ToDouble(col.Cells[16].Value);

            }
            tbValorTotalMaterial.Text = somaTotalMaterial.ToString("F2");

            //Soma Coluna Total Geral - Contigência
            double somaItensContigencia = 0;
            foreach (DataGridViewRow custo in dgvContigencia.Rows)
            {
                somaItensContigencia = somaItensContigencia + Convert.ToDouble(custo.Cells[5].Value);
            }
            tbSubTotalContigencia.Text = somaItensContigencia.ToString("F2");

            //Preenche a ComboBox Nº Item Mão de Obra
            PopularComboboxMaoDeObra();

            //Preencher ComboBox Nº Item Material
            PopularListaMaterial();

            //Preenche a combobox Item Contigência
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_RISCOS WHERE N_NOTA = @N_NOTA";
                cmd.Parameters.AddWithValue("@N_NOTA", tbNotaServicoComercial.Text);
                dr = cmd.ExecuteReader();

                da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                dt.Load(dr);

                cbItemContigencia.DataSource = dt;
                cbItemContigencia.ValueMember = "id";
                cbItemContigencia.DisplayMember = "n_item_risco";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Desconectar();
            }

            DirectoryInfo di = Directory.CreateDirectory(PastaDestino.PastaDaCotacao(numeroNota));
            Directory.GetCreationTime(PastaDestino.PastaDaCotacao(numeroNota));

        }

        private void PopularListaMaterial()
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_MATERIAL WHERE N_NOTA_SERV = @NOTA";
                cmd.Parameters.AddWithValue("@NOTA", tbNotaServicoComercial.Text);
                dr = cmd.ExecuteReader();

                da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                dt.Load(dr);

                cbItemMaterial.DataSource = dt;
                cbItemMaterial.ValueMember = "id";
                cbItemMaterial.DisplayMember = "n_item_material";
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

        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            AtualizarValoresMaoDeObra();
            GridMaoDeObra();
            SomarMaoDeObra();
            
        }

        private void AtualizarValoresMaoDeObra()
        {
            //Tratamento caso os campos estiverem vazios
            if (tbHoraNormais.Text == "")
            {
                //MessageBox.Show("Preencha todos os campos!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //tbHoraNormais.Focus();
                //return;
            }
            else
            {
                try
                {
                    cmd.Connection = con.Conectar();

                    double valorHoraNormal = Double.Parse(tbHoraNormais.Text);
                    double totalNormal;
                    double valorEx50, totalEx50;
                    double valorEx100, totalEx100;
                    double valorRefeicao = Double.Parse(tbRefeicao.Text);
                    double totalRefeicao;
                    double valorTotalHoras;

                    //cmd.CommandText = "SELECT * FROM TABELA_MAODEOBRA WHERE N_ITEM_MAODEOBRA = @M_ITEM";
                    cmd.CommandText = "SELECT * FROM TABELA_MAODEOBRA WHERE N_NOTA_SERV = @NUMERO_NOTA AND N_ITEM_MAODEOBRA = @M_ITEM";
                    cmd.Parameters.AddWithValue("@NUMERO_NOTA", numeroNota);
                    cmd.Parameters.AddWithValue("@M_ITEM", cbItemMaoObra.Text);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        totalHoraNormal = Convert.ToDouble(dr["horas_normais"]);
                        totalHora50 = Convert.ToDouble(dr["hora_ex50"]);
                        totalHora100 = Convert.ToDouble(dr["hora_ex100"]);
                        //tempoRefeicao = Convert.ToDouble(dr["tempo_refeicao"]);
                        totaldeDias = Convert.ToDouble(dr["quantidade_dias"]);


                    }
                    dr.Close();


                    //CALCULOS MÃO DE OBRA-----------------/

                    valorEx50 = valorHoraNormal * 1.5;
                    valorEx100 = valorHoraNormal * 2.0;

                    totalNormal = valorHoraNormal * totalHoraNormal;
                    totalEx50 = valorEx50 * totalHora50;
                    totalEx100 = valorEx100 * totalHora100;
                    totalRefeicao = totaldeDias * valorRefeicao;
                    valorTotalHoras = totalNormal + totalEx50 + totalEx100;

                    //Esses valores serão exibidos no Valor Total das suas respectivas colunas no DataGridView
                    //-----------------------------------/


                    cmd.CommandText = "UPDATE TABELA_MAODEOBRA SET " +
                        "VALOR_HORAS_NORMAIS = @VALOR_HORA_NORMAL, " +
                        "VALOR_HR_EX50 = @VALOR_HORA_EX50, " +
                        "VALOR_HR_EX100 = @VALOR_HORA_EX100," +
                        "VALOR_TOTAL_HR_NORMAIS = @TOTAL_HR_NORMAIS, " +
                        "VALOR_TOTAL_HR_EX50 = @TOTAL_HR_EX50," +
                        "VALOR_TOTAL_HR_EX100 = @TOTAL_HR_EX100, " +
                        "VALOR_REFEICAO = @VALOR_REFEICAO, " +
                        "TOTAL_REFEICAO = @TOTAL_REFEICAO," +
                        "TOTAL_GERAL = @TOTAL_GERAL," +
                        "VALOR_TOTAL_HORAS = @VALOR_TOTAL_HORAS WHERE N_ITEM_MAODEOBRA = @N_ITEM AND N_NOTA_SERV = @N_NOTA";

                    //Valores das TextBox do grupo mao de obra
                    cmd.Parameters.AddWithValue("@N_ITEM", cbItemMaoObra.Text);
                    cmd.Parameters.AddWithValue("@N _NOTA", tbNotaServicoComercial.Text);
                    cmd.Parameters.AddWithValue("@VALOR_HORA_NORMAL", valorHoraNormal.ToString("F2"));
                    cmd.Parameters.AddWithValue("@VALOR_HORA_EX50", valorEx50.ToString("F2"));
                    cmd.Parameters.AddWithValue("@VALOR_HORA_EX100", valorEx100.ToString("F2"));
                    cmd.Parameters.AddWithValue("@VALOR_REFEICAO", valorRefeicao.ToString("F2"));

                    cmd.Parameters.AddWithValue("@TOTAL_HR_NORMAIS", totalNormal.ToString("F2"));
                    cmd.Parameters.AddWithValue("@TOTAL_HR_EX50", totalEx50.ToString("F2"));
                    cmd.Parameters.AddWithValue("@TOTAL_HR_EX100", totalEx100.ToString("F2"));
                    cmd.Parameters.AddWithValue("@TOTAL_REFEICAO", totalRefeicao.ToString("F2"));
                    cmd.Parameters.AddWithValue("@TOTAL_GERAL", (totalNormal + totalEx50 + totalEx100 + totalRefeicao).ToString("F2"));
                    cmd.Parameters.AddWithValue("@VALOR_TOTAL_HORAS", valorTotalHoras.ToString("F2"));
                    cmd.ExecuteNonQuery();

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

        private void SomarMaoDeObra()
        {
            //Soma a coluna total geral
            double somaTotal = 0;
            foreach (DataGridViewRow col in dgvMaoObraComercial.Rows)
            {
                somaTotal = somaTotal + Convert.ToDouble(col.Cells[24].Value);

            }
            tbSubTotalMaoObra.Text = somaTotal.ToString("F2");
        }

        private void btnAdicionarMaterial_Click(object sender, EventArgs e)
        {
            AdicionarItemMaterial addItem = new AdicionarItemMaterial();

            if (tbValorUnitario.Text == "" || tbValorFrete.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbValorUnitario.Focus();
                return;
            }
            else
            {
                string numeroItem = cbItemMaterial.Text; //ID do Item Material
                double valorUnitario = Double.Parse(tbValorUnitario.Text);
                double valorFrete = Double.Parse(tbValorFrete.Text);

                addItem.AdicionarValoresMaterial(numeroNota, numeroItem, valorUnitario, valorFrete);
            }

            DadosMaterial(); //Atualiza o DataGridView (Material)

            SomarMaterial();
            
        }

        private void SomarMaterial()
        {
            //Soma a coluna Valor Total
            double somaTotal = 0;
            foreach (DataGridViewRow col in dgvMaterialComercial.Rows)
            {

                somaTotal += Convert.ToDouble(col.Cells[16].Value);

            }
            tbValorTotalMaterial.Text = somaTotal.ToString("F2");
        }

        //--------Codiogo da Tela de Custos Finais--------//
        CalculosCustosFinais crf = new CalculosCustosFinais();    

        public string subTotalMaoDeObra, subTotalMaterial, subTotalContigencia;

        public string codCliente, dataNota, cotacao, nota;
     
        public string sigla;
        public string[] spl;

        private void GraficoFinanceiro()
        {
            gfDetalhamentoFinanceiro.Series.Clear();
            gfDetalhamentoFinanceiro.Titles.Clear();
            gfDetalhamentoFinanceiro.Legends.Clear();

            Title title = new Title();
            title.Font = new Font("Yu Gothic UI", 10, FontStyle.Bold);
            title.ForeColor = Color.Black;
            title.Text = "Detalhamento Financeiro";
            gfDetalhamentoFinanceiro.Titles.Add(title);

            Legend legend = new Legend();
            gfDetalhamentoFinanceiro.Legends.Add(legend);

            gfDetalhamentoFinanceiro.ChartAreas["ChartArea1"].AxisY.Title = "Valores R$";
            gfDetalhamentoFinanceiro.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Yu Gothic UI", 9, FontStyle.Bold);

            gfDetalhamentoFinanceiro.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            gfDetalhamentoFinanceiro.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            gfDetalhamentoFinanceiro.ChartAreas[0].AxisY.Maximum = 5000;
            gfDetalhamentoFinanceiro.ChartAreas[0].AxisY.Minimum = 0;

            gfDetalhamentoFinanceiro.Series.Add("Despesas");
            gfDetalhamentoFinanceiro.Series["Despesas"].LegendText = "Despesas";
            gfDetalhamentoFinanceiro.Series["Despesas"].ChartType = SeriesChartType.Column;
            gfDetalhamentoFinanceiro.Series["Despesas"].BorderWidth = 4;

            //Dados
            //gfDetalhamentoFinanceiro.Series["Despesas"].Points.AddXY("Lucro", QuebraTexto(tbLucroPorcentagem.Text));
            //gfDetalhamentoFinanceiro.Series["Despesas"].Points.AddXY("Prolab", QuebraTexto(tbProlaborePorcentagem.Text));
            //gfDetalhamentoFinanceiro.Series["Despesas"].Points.AddXY("RC", QuebraTexto(tbRiscoSacadoPorcentagem.Text));
            //gfDetalhamentoFinanceiro.Series["Despesas"].Points.AddXY("Infra", QuebraTexto(tbIfraestruturaPorcentagem.Text));
            //gfDetalhamentoFinanceiro.Series["Despesas"].Points.AddXY("Imp", QuebraTexto(tbImpostoTotalPorcentagem.Text));
            //gfDetalhamentoFinanceiro.Series["Despesas"].Points.AddXY("Adm", QuebraTexto(tbDespesasAdmPorcentagem.Text));
            //gfDetalhamentoFinanceiro.Series["Despesas"].Points.AddXY("Bônus", QuebraTexto(tbBonusPorcentagem.Text));

            gfDetalhamentoFinanceiro.Series["Despesas"].Points.AddXY("Lucro", QuebraTexto(tbLucroTotal.Text));
            gfDetalhamentoFinanceiro.Series["Despesas"].Points.AddXY("Prolab", QuebraTexto(tbProlaboreTotal.Text));
            gfDetalhamentoFinanceiro.Series["Despesas"].Points.AddXY("RC", QuebraTexto(tbRiscoSacadoTotal.Text));
            gfDetalhamentoFinanceiro.Series["Despesas"].Points.AddXY("Infra", QuebraTexto(tbInfraestruturaTotal.Text));
            gfDetalhamentoFinanceiro.Series["Despesas"].Points.AddXY("Imp", QuebraTexto(tbImpostoTotal.Text));
            gfDetalhamentoFinanceiro.Series["Despesas"].Points.AddXY("Adm", QuebraTexto(tbDespesasTotal.Text));
            gfDetalhamentoFinanceiro.Series["Despesas"].Points.AddXY("Bônus", QuebraTexto(tbBonusTotal.Text));

            gfDetalhamentoFinanceiro.Series["Despesas"].IsValueShownAsLabel = true;
        }

        private double QuebraTexto(string texto)
        {
            string[] txt;
            double valor;

            txt = texto.Split('%');
            valor = double.Parse(txt[0]);
            return valor;
        }

        private void btnCalcularDespesasFinais_Click(object sender, EventArgs e)
        {
            crf.TotalTransporte = Double.Parse(tbTotalTranporte.Text);
            crf.TotalPassagens = Double.Parse(tbTotalPassagens.Text);
            crf.TotalDiaria = Double.Parse(tbTotalDiaria.Text);
            crf.TotalHospedagem = Double.Parse(tbTotalHospedagem.Text);
            crf.TotalTranslado = Double.Parse(tbTotalTranslado.Text);
            crf.TotalMaoDeObra = Double.Parse(tbTotalMaoObra.Text);
            crf.TotalMaterial = Double.Parse(tbTotalMaterial.Text);
            crf.TotalContigencia = Double.Parse(tbTotalContigencia.Text);

            tbTotalCustos.Text = crf.TotalCustosDespesas().ToString("F2");

            tbTotalServico.Text = crf.Resumo_TotalServico().ToString("F2");

            RotinaDeCalculo();
            GraficoFinanceiro();
        }

        private void button8_Click(object sender, EventArgs e)
        {


            //DadosPdf dados = new DadosPdf();
            RegistrarCustosFinais custos = new RegistrarCustosFinais();

            //Custos e Despesas Finais
            custos.CustosAndDespesas(tbNotaServicoComercial.Text, tbQuantidadeTransporte.Text, tbValorTransporte.Text, tbTotalTranporte.Text, tbQuantidadePassagens.Text, tbValorPassgens.Text, tbTotalPassagens.Text,
                tbQuantidadeDiaria.Text, tbValorDiaria.Text, tbTotalDiaria.Text, tbQuantidadeHospedagem.Text, tbValorHospedagem.Text, tbTotalHospedagem.Text, tbQuantidadeTranslado.Text, tbValorTranslado.Text, tbTotalTranslado.Text, tbTotalCustos.Text);

            //Valores de Entrada
            custos.DetalhamentoFinanceiro(tbNotaServicoComercial.Text, tbLucroReferencia.Text, tbLucroTotal.Text, tbProlaboreReferencia.Text, tbProlaboreTotal.Text, tbRiscoSacadoReferencia.Text, tbRiscoSacadoTotal.Text,
                tbInfraestruturaReferencia.Text, tbInfraestruturaTotal.Text, tbImpostoReferencia.Text, tbImpostoTotal.Text, tbDespesasAdmReferencia.Text, tbDespesasTotal.Text, tbBonusReferencia.Text, tbBonusTotal.Text, tbTotalReferencia.Text, tbTotalValorReferencia.Text);

            //Resumo Valores
            custos.ResumoValores(tbNotaServicoComercial.Text, tbTotalCustos.Text, tbTotalReferencia.Text, tbTotalValorReferencia.Text, tbTotalServico.Text, tbTotalEntrada.Text, tbCustoAndImpostos.Text);

            frmDadosProposta frmDados = new frmDadosProposta();

            frmDados.numeroNota = tbNotaServicoComercial.Text;
            frmDados.totalServico = tbTotalServico.Text;
            frmDados.cotacao = Cotacao();
            frmDados.ShowDialog();

            //try
            //{
                
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            notaServ = tbNotaServicoComercial.Text;
            tbTotalMaoObra.Text = tbSubTotalMaoObra.Text;
            tbTotalMaterial.Text = tbValorTotalMaterial.Text;
            tbTotalContigencia.Text = tbSubTotalContigencia.Text;

            SomaReferencias();
        }

        private void btnEditarNota_Click(object sender, EventArgs e)
        {
            frmEditarMaoDeObra editarNota = new frmEditarMaoDeObra();

            editarNota.numeroNota = tbNotaServicoComercial.Text;
            editarNota.Text = "Editar Nota - " + tbNotaServicoComercial.Text;
            editarNota.ShowDialog();

            AtualizarValoresMaoDeObra();
            GridMaoDeObra();
            SomarMaoDeObra();
        }

        private void btnEditarMaterial_Click(object sender, EventArgs e)
        {
            EditarMaterial();   
        }

        private void EditarMaterial()
        {
            string idNota, idItem;

            idItem = dgvMaterialComercial[2, linhaAtual].Value.ToString();

            idNota = tbNotaServicoComercial.Text;

            frmEditarMaterial frmM = new frmEditarMaterial();
            frmM.IDnota = idNota;
            frmM.IDitem = idItem;
            frmM.ShowDialog();
            AdicionarItemMaterial addItem = new AdicionarItemMaterial();
            addItem.AtualizarValorItem(idNota, idItem);
            DadosMaterial();
            SomarMaterial();
        }

        private void AdicionarMaterial()
        {
            string idNota;
            string key = "Add";

            idNota = tbNotaServicoComercial.Text;

            frmEditarMaterial frmM = new frmEditarMaterial();
            frmM.IDnota = idNota;
            frmM.chave = key;
            frmM.ShowDialog();
            AdicionarItemMaterial addItem = new AdicionarItemMaterial();
            DadosMaterial();
            SomarMaterial();
            PopularListaMaterial();
        }

        private void dgvMaterialComercial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            linhaAtual = int.Parse(e.RowIndex.ToString());

            btnEditarMaterial.Text = "Add";
        }

        private void dgvMaterialComercial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditarMaterial();
        }

        private void btnNovoMaterial_Click(object sender, EventArgs e)
        {
            AdicionarMaterial();
        }

        public static void DigitosNumericos(object senderm, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 44)
                e.Handled = true;
        }

        public string Cotacao()
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_NOTA_SERVICO WHERE NUMERO_NOTA = '" + tbNotaServicoComercial.Text + "' ";
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    codCliente = (string)dr["n_empresa"];
                    dataNota = (string)dr["n_data_soli"];
                    spl = dataNota.Split('/');
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

            cotacao =  string.Format("{0}", spl[2]) + notaServ;

            return cotacao;
        }

        private void SomaReferencias()
        {

            crf.Ref1 = Double.Parse(tbLucroReferencia.Text);
            crf.Ref2 = Double.Parse(tbProlaboreReferencia.Text);
            crf.Ref3 = Double.Parse(tbRiscoSacadoReferencia.Text);
            crf.Ref4 = Double.Parse(tbInfraestruturaReferencia.Text);
            crf.Ref5 = Double.Parse(tbImpostoReferencia.Text);
            crf.Ref6 = Double.Parse(tbDespesasAdmReferencia.Text);
            crf.Ref7 = Double.Parse(tbBonusReferencia.Text);

            tbTotalReferencia.Text = (crf.SomaDeReferencias() * 100).ToString("f2"); //passa apenas duas casas decimais
        }

        public void RotinaDeCalculo()
        {

            //PERCENTUAL - CUSTO E DESPESAS FINAIS
            //
            //Calculo Percentual - Transporte
            //---------------------------------//
            crf.Total = Double.Parse(tbTotalTranporte.Text);
            tbPorcentagemTransporte.Text = crf.CalculoPercentual().ToString("F0") + "%";

            //Calculo Percentual - Passagens
            //---------------------------------//
            crf.Total = Double.Parse(tbTotalPassagens.Text);
            tbPorcentagemPassagens.Text = crf.CalculoPercentual().ToString("F0") + "%";

            //Calculo Percentual - Diária de Viagem
            //---------------------------------//
            crf.Total = Double.Parse(tbTotalDiaria.Text);
            tbPorcentagemDiaria.Text = crf.CalculoPercentual().ToString("F0") + "%";

            //Calculo Percentual - Hospedagem
            //---------------------------------//
            crf.Total = Double.Parse(tbTotalHospedagem.Text);
            tbPorcentagemHospedagem.Text = crf.CalculoPercentual().ToString("F0") + "%";

            //Calculo Percentual - Translado
            //---------------------------------//
            crf.Total = Double.Parse(tbTotalTranslado.Text);
            tbPorcentagemTranslado.Text = crf.CalculoPercentual().ToString("F0") + "%";

            //Calculo Percentual - Mão de Obra
            //---------------------------------//
            crf.Total = Double.Parse(tbTotalMaoObra.Text);
            tbPercentualMaoDeObra.Text = crf.CalculoPercentual().ToString("F0") + "%";

            //Calculo Percentual - Material
            //---------------------------------//
            crf.Total = Double.Parse(tbTotalMaterial.Text);
            tbPercentualMaterial.Text = crf.CalculoPercentual().ToString("F0") + "%";

            //Calculo Percentual - Contigência
            //---------------------------------//
            crf.Total = Double.Parse(tbTotalContigencia.Text);
            tbPercentualContigencia.Text = crf.CalculoPercentual().ToString("F0") + "%";

            //Calculo Percentual - Total Despesas Finais
            //---------------------------------//
            crf.Total = Double.Parse(tbTotalCustos.Text);
            tbPercentualCustos.Text = crf.CalculoPercentual().ToString("F0") + "%";


            //PERCENTUAL - DETALHAMENTO FINANCEIRO
            //
            //Calculo Percentual - Lucro
            //---------------------------------//
            crf.Referencia = Double.Parse(tbLucroReferencia.Text);
            tbLucroTotal.Text = crf.CalculoValorReferencia().ToString("N2");

            crf.Total = Double.Parse(tbLucroTotal.Text);
            tbLucroPorcentagem.Text = crf.CalculoPercentual().ToString("F2") + "%";

            //Calculo Percentual - Prolabore
            //---------------------------------//
            crf.Referencia = Double.Parse(tbProlaboreReferencia.Text);
            tbProlaboreTotal.Text = crf.CalculoValorReferencia().ToString("N2");

            crf.Total = Double.Parse(tbProlaboreTotal.Text);
            tbProlaborePorcentagem.Text = crf.CalculoPercentual().ToString("F2") + "%";

            //Calculo Percentual - Risco Sacado
            //---------------------------------//
            crf.Referencia = Double.Parse(tbRiscoSacadoReferencia.Text);
            tbRiscoSacadoTotal.Text = crf.CalculoValorReferencia().ToString("N2");

            crf.Total = Double.Parse(tbRiscoSacadoTotal.Text);
            tbRiscoSacadoPorcentagem.Text = crf.CalculoPercentual().ToString("F2") + "%";

            //Calculo Percentual - Infraestrutura
            //---------------------------------//
            crf.Referencia = Double.Parse(tbInfraestruturaReferencia.Text);
            tbInfraestruturaTotal.Text = crf.CalculoValorReferencia().ToString("N2");

            crf.Total = Double.Parse(tbInfraestruturaTotal.Text);
            tbIfraestruturaPorcentagem.Text = crf.CalculoPercentual().ToString("F2") + "%";

            //Calculo Percentual - Imposto
            //---------------------------------//
            crf.Referencia = Double.Parse(tbImpostoReferencia.Text);
            tbImpostoTotal.Text = crf.CalculoValorReferencia().ToString("N2");

            crf.Total = Double.Parse(tbImpostoTotal.Text);
            tbImpostoTotalPorcentagem.Text = crf.CalculoPercentual().ToString("F2") + "%";

            //Calculo Percentual - Despesas Administrativas
            //---------------------------------//
            crf.Referencia = Double.Parse(tbDespesasAdmReferencia.Text);
            tbDespesasTotal.Text = crf.CalculoValorReferencia().ToString("N2");

            crf.Total = Double.Parse(tbDespesasTotal.Text);
            tbDespesasAdmPorcentagem.Text = crf.CalculoPercentual().ToString("F2") + "%";

            //Calculo Percentual - Bonus
            //----------------------------------//
            crf.Referencia = Double.Parse(tbBonusReferencia.Text);
            tbBonusTotal.Text = crf.CalculoValorReferencia().ToString("N2");

            crf.Total = Double.Parse(tbBonusTotal.Text);
            tbBonusPorcentagem.Text = crf.CalculoPercentual().ToString("F2") + "%";

            //Somatoria das Referências
            //---------------------------------//
            SomaReferencias();

            //Somatoria Detalhamento Financeiro
            //---------------------------------//
            crf.TotalLucro = Double.Parse(tbLucroTotal.Text);
            crf.TotalProlabore = Double.Parse(tbProlaboreTotal.Text);
            crf.TotalRiscoSacado = Double.Parse(tbRiscoSacadoTotal.Text);
            crf.TotalInfraestrutura = Double.Parse(tbInfraestruturaTotal.Text);
            crf.TotalImposto = Double.Parse(tbImpostoTotal.Text);
            crf.TotalDespesasAdm = Double.Parse(tbDespesasTotal.Text);
            crf.TotalBonus = Double.Parse(tbBonusTotal.Text);

            tbTotalValorReferencia.Text = crf.SomaDetalhamentoFinanceiro().ToString();


            //RESUMO
            //
            //Entrada
            //---------------------------------//
            crf.TotalLucro = Double.Parse(tbLucroTotal.Text);
            crf.TotalProlabore = Double.Parse(tbProlaboreTotal.Text);
            crf.TotalRiscoSacado = Double.Parse(tbRiscoSacadoTotal.Text);
            crf.TotalInfraestrutura = Double.Parse(tbInfraestruturaTotal.Text);
            crf.TotalDespesasAdm = Double.Parse(tbDespesasTotal.Text);

            tbTotalEntrada.Text = crf.TotalEntrada().ToString("F2");

            //Custo + Impostos
            //---------------------------------//
            tbCustoAndImpostos.Text = crf.Custo_Imposto().ToString("F2");

            //Calculo Percentual - Entrada e Custo+Impostos
            //---------------------------------//
            crf.Total = Double.Parse(tbTotalEntrada.Text);
            tbPercentualEntrada.Text = crf.CalculoPercentual().ToString("F1") + "%";

            crf.Total = Double.Parse(tbCustoAndImpostos.Text);
            tbPercentualCustoImposto.Text = crf.CalculoPercentual().ToString("F1") + "%";

            tbTotalServico.Text = crf.Resumo_TotalServico().ToString("F2");

            lbPercentualTatalServico.Text = "100%";
        }

        private void tbValorTransporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            DigitosNumericos(sender, e);
        }

        private void tbValorPassgens_KeyPress(object sender, KeyPressEventArgs e)
        {
            DigitosNumericos(sender, e);
        }

        private void tbValorDiaria_KeyPress(object sender, KeyPressEventArgs e)
        {
            DigitosNumericos(sender, e);
        }

        private void tbValorTranslado_KeyPress(object sender, KeyPressEventArgs e)
        {
            DigitosNumericos(sender, e);
        }

        private void tbValorTransporte_TextChanged(object sender, EventArgs e)
        {
            if (tbQuantidadeTransporte.Text == "")
            {
                return;
            }
            else if (tbValorTransporte.Text != "")
            {
                crf.Quantidade = Double.Parse(tbQuantidadeTransporte.Text);
                crf.Valor = Double.Parse(tbValorTransporte.Text);

                tbTotalTranporte.Text = crf.CalculoDespesas().ToString("F2");
            }
            else if (tbValorTransporte.Text == "")
            {
                tbTotalTranporte.Text = "0";
                return;
            }
        }

        private void tbValorPassgens_TextChanged(object sender, EventArgs e)
        {
            if (tbQuantidadePassagens.Text == "")
            {
                return;
            }
            else if (tbValorPassgens.Text != "")
            {
                crf.Quantidade = Double.Parse(tbQuantidadePassagens.Text);
                crf.Valor = Double.Parse(tbValorPassgens.Text);

                tbTotalPassagens.Text = crf.CalculoDespesas().ToString("F2");
            }
            else if (tbValorPassgens.Text == "")
            {
                tbTotalPassagens.Text = "0";
                return;
            }
        }

        private void tbValorDiaria_TextChanged(object sender, EventArgs e)
        {
            if (tbQuantidadeDiaria.Text == "")
            {
                return;
            }
            else if (tbValorDiaria.Text != "")
            {

                crf.Quantidade = Double.Parse(tbQuantidadeDiaria.Text);
                crf.Valor = Double.Parse(tbValorDiaria.Text);

                tbTotalDiaria.Text = crf.CalculoDespesas().ToString("F2");

            }
            else if (tbValorDiaria.Text == "")
            {
                tbTotalDiaria.Text = "0";
                return;
            }
        }

        private void tbValorHospedagem_TextChanged(object sender, EventArgs e)
        {
            if (tbValorHospedagem.Text == "")
            {
                return;
            }
            else if (tbValorHospedagem.Text != "")
            {
                crf.Quantidade = double.Parse(tbQuantidadeHospedagem.Text);
                crf.Valor = double.Parse(tbValorHospedagem.Text);

                tbTotalHospedagem.Text = crf.CalculoDespesas().ToString("F2");
            }
        }

        private void tbValorTranslado_TextChanged(object sender, EventArgs e)
        {
            if (tbQuantidadeTranslado.Text == "")
            {
                return;
            }
            else if (tbValorTranslado.Text != "")
            {

                crf.Quantidade = Double.Parse(tbQuantidadeTranslado.Text);
                crf.Valor = Double.Parse(tbValorTranslado.Text);

                tbTotalTranslado.Text = crf.CalculoDespesas().ToString("F2");

            }
            else if (tbValorTranslado.Text == "")
            {
                tbTotalTranslado.Text = "0";
                return;
            }
        }

        private void tbInfraestruturaReferencia_TextChanged(object sender, EventArgs e)
        {
            if (tbInfraestruturaReferencia.Text != "")
            {
                SomaReferencias();

                tbTotalServico.Text = crf.Resumo_TotalServico().ToString("F2");

                crf.Referencia = Double.Parse(tbInfraestruturaReferencia.Text);

                tbInfraestruturaTotal.Text = crf.CalculoValorReferencia().ToString("F2");

                RotinaDeCalculo();
                GraficoFinanceiro();
            }
            else if (tbInfraestruturaReferencia.Text == "")
            {
                tbInfraestruturaReferencia.Text = "0";
                tbInfraestruturaTotal.Text = "0,00";
                return;
            }
        }

        private void tbImpostoReferencia_TextChanged(object sender, EventArgs e)
        {
            if (tbImpostoReferencia.Text != "")
            {
                SomaReferencias();

                tbTotalServico.Text = crf.Resumo_TotalServico().ToString("F2");

                crf.Referencia = Double.Parse(tbImpostoReferencia.Text);

                tbImpostoTotal.Text = crf.CalculoValorReferencia().ToString("F2");

                RotinaDeCalculo();
                GraficoFinanceiro();
            }
            else if (tbImpostoReferencia.Text == "")
            {
                tbImpostoReferencia.Text = "0";
                tbImpostoTotal.Text = "0,00";
                return;
            }
        }

        private void tbDespesasAdmReferencia_TextChanged(object sender, EventArgs e)
        {
            if (tbDespesasAdmReferencia.Text != "")
            {
                SomaReferencias();

                tbTotalServico.Text = crf.Resumo_TotalServico().ToString("F2");

                crf.Referencia = Double.Parse(tbDespesasAdmReferencia.Text);

                tbDespesasTotal.Text = crf.CalculoValorReferencia().ToString("F2");

                RotinaDeCalculo();
                GraficoFinanceiro();
            }
            else if (tbDespesasAdmReferencia.Text == "")
            {
                tbDespesasAdmReferencia.Text = "0";
                tbDespesasTotal.Text = "0,00";
                return;
            }
        }

        private void tbBonusReferencia_TextChanged(object sender, EventArgs e)
        {
            if (tbBonusReferencia.Text != "")
            {
                SomaReferencias();

                tbTotalServico.Text = crf.Resumo_TotalServico().ToString("F2");

                crf.Referencia = Double.Parse(tbBonusReferencia.Text);

                tbBonusTotal.Text = crf.CalculoValorReferencia().ToString("F2");

                RotinaDeCalculo();
                GraficoFinanceiro();

            }
            else if (tbBonusReferencia.Text == "")
            {
                tbBonusReferencia.Text = "0";
                tbBonusTotal.Text = "0,00";
                return;
            }
        }

        private void tbRiscoSacadoReferencia_TextChanged(object sender, EventArgs e)
        {
            if (tbRiscoSacadoReferencia.Text != "")
            {
                SomaReferencias();

                tbTotalServico.Text = crf.Resumo_TotalServico().ToString("F2");

                crf.Referencia = Double.Parse(tbRiscoSacadoReferencia.Text);

                tbRiscoSacadoTotal.Text = crf.CalculoValorReferencia().ToString("F2");

                RotinaDeCalculo();
                GraficoFinanceiro();
            }
            else if (tbRiscoSacadoReferencia.Text == "")
            {
                tbRiscoSacadoReferencia.Text = "0";
                tbRiscoSacadoTotal.Text = "0,00";
                return;
            }
        }

        private void tbProlaboreReferencia_TextChanged(object sender, EventArgs e)
        {
            if (tbProlaboreReferencia.Text != "")
            {
                SomaReferencias();

                tbTotalServico.Text = crf.Resumo_TotalServico().ToString("F2");

                crf.Referencia = Double.Parse(tbProlaboreReferencia.Text);

                tbProlaboreTotal.Text = crf.CalculoValorReferencia().ToString("F2");

                RotinaDeCalculo();
                GraficoFinanceiro();

            }
            else if (tbProlaboreReferencia.Text == "")
            {
                tbProlaboreReferencia.Text = "0";
                tbProlaboreTotal.Text = "0,00";
                return;
            }
        }

        private void tbLucroReferencia_TextChanged(object sender, EventArgs e)
        {
            if (tbLucroReferencia.Text != "")
            {
                SomaReferencias();

                tbTotalServico.Text = crf.Resumo_TotalServico().ToString("F2");

                crf.Referencia = Double.Parse(tbLucroReferencia.Text);

                tbLucroTotal.Text = crf.CalculoValorReferencia().ToString("F2");

                RotinaDeCalculo();
                GraficoFinanceiro();
            }
            else if (tbLucroReferencia.Text == "")
            {
                tbLucroReferencia.Text = "0";
                tbLucroTotal.Text = "0,00";
                return;
            }
        }
        //---------------------//

    }
}
