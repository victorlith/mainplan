using Projeto_M.Class01;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;


namespace Projeto_M
{
    public partial class frmNotaServico : Form
    {
        Conexao con = new Conexao();
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataReader dr;

        Bitmap bmp;

        CalculoDeHora calculoHora;

        NotaServico rotinaNotaServico;

        // Variaveis do grupobox Dados Cliente
        public string nomeEmpresa, codCliente, solicitante, dataSli;

        // Variaveis do grupobox Dados Responsavel MENPLAN
        public string matricula, nomeUsuario, funcao, contatoUsuario, dataAtend;

        //Variaveis do grupobox Dados Serviço
        public string area, local, equipamento, codEquipamento, fabricante, modelo;

        //Variavel do campo Descrição Serviço
        public string descricao;

        //public string nota;
        public string numeroN;

        public string idSolicitacao;

        //Variaveis para criação da pasta
        private string path; //Variavel referente ao local da pasta
        public string numeroCliente, dataNota;
        public string sigla;
        public string[] spl = new string[2];

        private int totalDeDias = 0;

        private bool chaveNumeroItemMaoDeObra = false;
        private bool chaveNumeroItemMaterial = false;
        private bool chaveNumeroItemVerificacoRisco = false;

        public frmNotaServico()
        {
            InitializeComponent();
        }

        public string CriarPasta(string numeroPasta, string data)
        {
            spl = data.Split('/');

            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_CLIENTE WHERE COD_CLIENTE = '" + codCliente + "'";
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    sigla = (string)dr["sigla_empresa"];
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

            return path = @"C:\Arquivos Menplan\" + string.Format($"{spl[2]}") + numeroPasta + "_" + "Nota_Servico_" + sigla;

        }

        private void ContagemItensMaoDeObra()
        {
            lbItemObra.Text = listaMaoObra.Items.Count.ToString().PadLeft(2, '0');
        }

        private void ContagemItensMaterial()
        {
            lbItemMaterial.Text = listaMaterial.Items.Count.ToString().PadLeft(2, '0');
        }

        private void LimparCamposPeriodos()
        {
            tbHoraInicial1.Clear();
            tbHoraFinal1.Clear();
            tbHoraInicial2.Clear();
            tbHoraFinal2.Clear();
            tbHoraInicial3.Clear();
            tbHoraFinal3.Clear();
            tbHoraInicial4.Clear();
            tbHoraFinal4.Clear();
            tbHoraInicial5.Clear();
            tbHoraFinal5.Clear();

            tbTempoRefeicao1.Text = "0";

            if (checkBox2.Checked)
            {
                tbTempoRefeicao2.Text = "0";
            }

            if (checkBox3.Checked)
            {
                tbTempoRefeicao3.Text = "0";
            }

            if (checkBox4.Checked)
            {
                tbTempoRefeicao4.Text = "0";
            }

            if (checkBox5.Checked)
            {
                tbTempoRefeicao5.Text = "0";
            }

            tbTempoRefeicao3.Text = "0";
            tbTempoRefeicao4.Text = "0";
            tbTempoRefeicao5.Text = "0";

            tbTotalHs1.Text = "0";
            tbTotalHs2.Text = "0";
            tbTotalHs3.Text = "0";
            tbTotalHs4.Text = "0";
            tbTotalHs5.Text = "0";

            tbHsNormais1.Text = "0";
            tbHsNormais2.Text = "0";
            tbHsNormais3.Text = "0";
            tbHsNormais4.Text = "0";
            tbHsNormais5.Text = "0";

            tbHsExtra501.Text = "0";
            tbHsExtra502.Text = "0";
            tbHsExtra503.Text = "0";
            tbHsExtra504.Text = "0";
            tbHsExtra505.Text = "0";

            tbHsExtra1001.Text = "0";
            tbHsExtra1002.Text = "0";
            tbHsExtra1003.Text = "0";
            tbHsExtra1004.Text = "0";
            tbHsExtra1005.Text = "0";

            tbTotalRefeicao.Text = "0";
            tbTotalHs.Text = "0";
            tbTotalNormais.Text = "0";
            tbTotalExtra50.Text = "0";
            tbTotalExtra100.Text = "0";
        }

        private void btnLimparCamposPeriodos_Click(object sender, EventArgs e)
        {
            LimparCamposPeriodos();
        }

        private void btnRemoverItemRisco_Click_1(object sender, EventArgs e)
        {
            lvRiscos.Items.RemoveAt(lvRiscos.SelectedIndices[0]);

            int index = 1;

            foreach (ListViewItem item in lvRiscos.Items)
            {
                item.Text = index.ToString().PadLeft(2, '0');
                index++;
            }
        }

        private void btnAdicionaRisco_Click_1(object sender, EventArgs e)
        {
            if (tbDescricaoRisco.Text == "" || tbBloqueioRisco.Text == "")
            {
                MessageBox.Show("É necessário preencher os dois campos!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (chaveNumeroItemVerificacoRisco == false)
            {

                string[] itemRisco = new string[3];

                itemRisco[0] = "01";
                itemRisco[1] = tbDescricaoRisco.Text;
                itemRisco[2] = tbBloqueioRisco.Text;

                ListViewItem listaRisco = new ListViewItem(itemRisco);
                lvRiscos.Items.Add(listaRisco);

                chaveNumeroItemVerificacoRisco = true;

                tbDescricaoRisco.Clear();
                tbBloqueioRisco.Clear();
            }
            else if (chaveNumeroItemVerificacoRisco == true)
            {
                string[] itemRisco = new string[3];
                int index = 1;

                foreach (ListViewItem item in lvRiscos.Items)
                {
                    item.Text = index.ToString().PadLeft(2, '0');
                    index++;
                }

                itemRisco[0] = index.ToString().PadLeft(2, '0');
                itemRisco[1] = tbDescricaoRisco.Text;
                itemRisco[2] = tbBloqueioRisco.Text;

                ListViewItem listaRisco = new ListViewItem(itemRisco);
                lvRiscos.Items.Add(listaRisco);

                tbDescricaoRisco.Clear();
                tbBloqueioRisco.Clear();
            }

        }

        private void btn_adicionar_Click(object sender, EventArgs e)
        {


            if (chaveNumeroItemMaoDeObra == false)
            {
                string[] itemObra = new string[11];

                itemObra[0] = "01";
                itemObra[1] = cb_especialidade.Text;
                itemObra[2] = cb_funcaoObra.Text;
                itemObra[3] = tbNomeEspecialista.Text;
                itemObra[4] = tbAtividadesMDO.Text;
                itemObra[5] = totalDeDias.ToString();
                itemObra[6] = tbTotalRefeicao.Text;
                itemObra[7] = tbTotalHs.Text;
                itemObra[8] = tbTotalNormais.Text;
                itemObra[9] = tbTotalExtra50.Text;
                itemObra[10] = tbTotalExtra100.Text;
                

                ListViewItem listaObra = new ListViewItem(itemObra);
                listaMaoObra.Items.Add(listaObra);

                chaveNumeroItemMaoDeObra = true;
            }
            else if (chaveNumeroItemMaoDeObra == true)
            {
                string[] itemObra = new string[11];
                int index = 1;

                foreach (ListViewItem numeroItem in listaMaoObra.Items)
                {
                    numeroItem.Text = index.ToString().PadLeft(2, '0');
                    index++;
                }

                itemObra[0] = index.ToString().PadLeft(2, '0');
                itemObra[1] = cb_especialidade.Text;
                itemObra[2] = cb_funcaoObra.Text;
                itemObra[3] = tbNomeEspecialista.Text;
                itemObra[4] = tbAtividadesMDO.Text;
                itemObra[5] = totalDeDias.ToString();
                itemObra[6] = tbTotalRefeicao.Text;
                itemObra[7] = tbTotalHs.Text;
                itemObra[8] = tbTotalNormais.Text;
                itemObra[9] = tbTotalExtra50.Text;
                itemObra[10] = tbTotalExtra100.Text;
                

                ListViewItem listaObra = new ListViewItem(itemObra);
                listaMaoObra.Items.Add(listaObra);


            }

            ContagemItensMaoDeObra();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cb_especialidadeMaterial.Text == "" || tb_descricaoMaterial.Text == "" || cbUnidadeMedida.Text == "" || tbTotalMaterial.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (chaveNumeroItemMaterial == false)
            {
                string[] itemMaterial = new string[5];

                itemMaterial[0] = "01";
                itemMaterial[1] = cb_especialidadeMaterial.Text;
                itemMaterial[2] = tb_descricaoMaterial.Text;
                itemMaterial[3] = cbUnidadeMedida.Text;
                itemMaterial[4] = tbTotalMaterial.Text;

                ListViewItem Material = new ListViewItem(itemMaterial);
                listaMaterial.Items.Add(Material);

                chaveNumeroItemMaterial = true;
            }
            else if (chaveNumeroItemMaterial == true)
            {
                string[] itemMaterial = new string[5];
                int index = 1;

                foreach (ListViewItem item in listaMaterial.Items)
                {
                    item.Text = index.ToString().PadLeft(2, '0');
                    index++;
                }

                itemMaterial[0] = index.ToString().PadLeft(2, '0');
                itemMaterial[1] = cb_especialidadeMaterial.Text;
                itemMaterial[2] = tb_descricaoMaterial.Text;
                itemMaterial[3] = cbUnidadeMedida.Text;
                itemMaterial[4] = tbTotalMaterial.Text;

                ListViewItem Material = new ListViewItem(itemMaterial);
                listaMaterial.Items.Add(Material);
            }

            ContagemItensMaterial();

            cb_especialidadeMaterial.Text = "";
            tb_descricaoMaterial.Clear();
            cbUnidadeMedida.Text = "";
            tbTotalMaterial.Clear();
        }

        private void frmNotaServico_Load(object sender, EventArgs e)
        {
            //toolTip1.ToolTipTitle = "Dica:"; //Titulo do ToolTip
            //toolTip1.SetToolTip(mkbHorasNormais, "Digite o quantidade de Horas Normais sem o Tempo de Refeição");

            //Gera sequencia de numeros de nota
            if (tbNotaDeServico.Text == "")
            {
                int numero = 1;
                tbNotaDeServico.Text = numero.ToString().PadLeft(4, '0');
                numeroN = Convert.ToString(numero);
            }

            try
            {
                int numeroNota;

                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_NOTA_SERVICO WHERE NUMERO_NOTA = (SELECT MAX(NUMERO_NOTA) FROM TABELA_NOTA_SERVICO)";
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    numeroNota = Convert.ToInt32(dr["numero_nota"]);
                    numeroNota++;

                    numeroN = Convert.ToString(numeroNota);
                    tbNotaDeServico.Text = numeroNota.ToString().PadLeft(4, '0');
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


            //Rotina para criar a pasta referente ao numero da nota
            try
            {
                DirectoryInfo di = Directory.CreateDirectory(PastaDestino.CriarPasta(tbNotaDeServico.Text, dataSli, codCliente));
                Directory.GetCreationTime(PastaDestino.CriarPasta(tbNotaDeServico.Text, dataSli, codCliente));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            // Solução temporaria ate encontrar a maneira correta de buscar os dados
            // Dados Cliente
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_CLIENTE WHERE COD_CLIENTE = @ID";

                cmd.Parameters.AddWithValue("@ID", codCliente);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    nomeEmpresa = (string)dr["nome_empresa"];
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


            //Dados Usuario
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_USUARIO WHERE MATRICULA = @MATRICULA";

                cmd.Parameters.AddWithValue("@MATRICULA", matricula);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    nomeUsuario = (string)dr["nome"];
                    funcao = (string)dr["funcao"];
                    contatoUsuario = Convert.ToString(dr["celular"]);
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

            try
            
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "select * from tabela_solicitacao_servico where numero_servico = '" + idSolicitacao + "'";
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    tbEmail_nota.Text = (string)dr["email_solicitante"];
                    mkbContatoSolicitante_nota.Text = (string)dr["contato_solicitante"];
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

            //TextBox do grupobox Dados Cliente
            tbNomeEmpresa_nota.Text = nomeEmpresa;
            tbCodigoCliente_nota.Text = codCliente;
            tbSolicitante_nota.Text = solicitante;
            //tbEmail_nota.Text = emailCliente;
            //mkbContatoSolicitante_nota.Text = contatoCliente;
            mkbDataSolicitacao_nota.Text = dataSli;

            //TextBox do grupobox Dados Responsavel MENPLAN
            tbMatricula_nota.Text = matricula;
            tbNome_nota.Text = nomeUsuario;
            tbFuncao_nota.Text = funcao;
            mkbContatoUsuario_nota.Text = contatoUsuario;
            mkbDataAtend.Text = dataAtend;

            //TextBox do grupobox Dados do Serviço
            tbArea_nota.Text = area;
            tbLocal_nota.Text = local;
            tbEquipamento_nota.Text = equipamento;
            tbCodigoEquipamento_nota.Text = codEquipamento;
            tbFabricante_nota.Text = fabricante;
            tbModelo_nota.Text = modelo;

            //RitchTextBox Descrição do Serviço
            rtDescricao_nota.Text = descricao;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listaMaterial.Items.RemoveAt(listaMaterial.SelectedIndices[0]);

            int index = 1;

            foreach (ListViewItem item in listaMaterial.Items)
            {
                item.Text = index.ToString().PadLeft(2, '0');
                index++;
            }

            ContagemItensMaterial();
        }

        private void btn_removeritem_Click(object sender, EventArgs e)
        {
            listaMaoObra.Items.RemoveAt(listaMaoObra.SelectedIndices[0]);

            int index = 1;

            foreach (ListViewItem list in listaMaoObra.Items)
            {
                list.Text = index.ToString().PadLeft(2, '0');
                index++;
            }

            ContagemItensMaoDeObra();

        }

        private void SalvarDadosMaoDeObra()
        {
            try
            {
                //Valor adicionado no total geral de todos os itens de mão de obra e material
                int valorTotal = 0;

                cmd.Connection = con.Conectar();


                for (int i = 0; i < listaMaoObra.Items.Count; i++)
                {

                    double horaNormal, horaEx50, horaEx100;
                    double totalNormal, totalEx50, totalEx100;

                    
                    horaNormal = double.Parse(listaMaoObra.Items[i].SubItems[8].Text);
                    horaEx50 = double.Parse(listaMaoObra.Items[i].SubItems[9].Text);
                    horaEx100 = double.Parse(listaMaoObra.Items[i].SubItems[10].Text);

                    totalNormal = 1 * horaNormal;
                    totalEx50 = 1 * horaEx50;
                    totalEx100 = 1 * horaEx100;

                    cmd.CommandText = "INSERT INTO TABELA_MAODEOBRA (n_nota_serv, " +
                        "n_item_maodeobra, " +
                        "especialidade_maodeobra, " +
                        "funcao, " +
                        "nome_especialista, " +
                        "quantidade_dias, " +
                        "tempo_refeicao, " +
                        "total_de_horas, " +
                        "horas_normais, " +
                        "hora_ex50, " +
                        "hora_ex100, " +
                        "total_hr_normais, " +
                        "total_hr_ex50, " +
                        "total_hr_ex100, " +
                        "total_geral, " +
                        "atividade) " +
                        "VALUES (@n_nota_serv, " +
                        "@n_item_maodeobra, " +
                        "@especialidade_maodeobra, " +
                        "@funcao, " +
                        "@nome_especialista, " +
                        "@quantidade_dias, " +
                        "@tempo_refeicao, " +
                        "@total_de_horas, " +
                        "@horas_normais, " +
                        "@hora_ex50, " +
                        "@hora_ex100, " +
                        "@total_hr_normais, " +
                        "@total_hr_ex50, " +
                        "@total_hr_ex100, " +
                        "@total_geral, " +
                        "@atividade)";

                    cmd.Parameters.AddWithValue("@n_nota_serv", tbNotaDeServico.Text);
                    cmd.Parameters.AddWithValue("@n_item_maodeobra", listaMaoObra.Items[i].SubItems[0].Text);
                    cmd.Parameters.AddWithValue("@especialidade_maodeobra", listaMaoObra.Items[i].SubItems[1].Text);
                    cmd.Parameters.AddWithValue("@funcao", listaMaoObra.Items[i].SubItems[2].Text);
                    cmd.Parameters.AddWithValue("@nome_especialista", listaMaoObra.Items[i].SubItems[3].Text);
                    cmd.Parameters.AddWithValue("@quantidade_dias", listaMaoObra.Items[i].SubItems[5].Text);
                    cmd.Parameters.AddWithValue("@tempo_refeicao", listaMaoObra.Items[i].SubItems[6].Text);
                    cmd.Parameters.AddWithValue("@total_de_horas", listaMaoObra.Items[i].SubItems[7].Text);
                    cmd.Parameters.AddWithValue("@horas_normais", listaMaoObra.Items[i].SubItems[8].Text);
                    cmd.Parameters.AddWithValue("@hora_ex50", listaMaoObra.Items[i].SubItems[9].Text);
                    cmd.Parameters.AddWithValue("@hora_ex100", listaMaoObra.Items[i].SubItems[10].Text);             
                    cmd.Parameters.AddWithValue("@total_hr_normais", totalNormal.ToString()); //Multiplica a Quantidade de Pessoas com o Total de Horas Normais
                    cmd.Parameters.AddWithValue("@total_hr_ex50", totalEx50.ToString()); //Multiplica a Quantidade de Pessoas com o Total de Horas Extra 50
                    cmd.Parameters.AddWithValue("@total_hr_ex100",totalEx100.ToString()); //Multiplica a Quantidade de Pessoas com o Total de Horas Extra 100
                    cmd.Parameters.AddWithValue("@total_geral", valorTotal);
                    cmd.Parameters.AddWithValue("@atividade", listaMaoObra.Items[i].SubItems[4].Text);
                    cmd.ExecuteNonQuery();

                    //cmd.Parameters.AddWithValue("@total_hr_normais", double.Parse(listaMaoObra.Items[i].SubItems[3].Text) * double.Parse(listaMaoObra.Items[i].SubItems[7].Text)); //Multiplica a Quantidade de Pessoas com o Total de Horas Normais
                    //cmd.Parameters.AddWithValue("@total_hr_ex50", double.Parse(listaMaoObra.Items[i].SubItems[3].Text) * double.Parse(listaMaoObra.Items[i].SubItems[8].Text)); //Multiplica a Quantidade de Pessoas com o Total de Horas Extra 50
                    //cmd.Parameters.AddWithValue("@total_hr_ex100", double.Parse(listaMaoObra.Items[i].SubItems[3].Text) * double.Parse(listaMaoObra.Items[i].SubItems[9].Text)); //Multiplica a Quantidade de Pessoas com o Total de Horas Extra 100

                }

            }
            catch (Exception erro)
            {

                MessageBox.Show(erro.Message, "Erro: Orçamento Técnico Mão de Obra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Desconectar();
            }
        }

        private void SalvarDadosMaterial()
        {
            //Valor adicionado no total geral de todos os itens de mão de obra e material
            int valorTotal = 0;

            try
            {
                cmd.Connection = con.Conectar();

                for (int i = 0; i <= listaMaterial.Items.Count - 1; i++)
                {
                    cmd.CommandText = "INSERT INTO TABELA_MATERIAL (n_nota_serv, n_item_material, especialidade_material, descricao_material, unidade_medida, total_material, valor_total) " +
                        "VALUES (@n_nota_serv, @n_item_material, @especialidade_material, @descricao_material, @unidade_medida, @total_material, @valor_total)";

                    cmd.Parameters.AddWithValue("@n_nota_serv", tbNotaDeServico.Text);
                    cmd.Parameters.AddWithValue("@n_item_material", listaMaterial.Items[i].SubItems[0].Text);
                    cmd.Parameters.AddWithValue("@especialidade_material", listaMaterial.Items[i].SubItems[1].Text);
                    cmd.Parameters.AddWithValue("@descricao_material", listaMaterial.Items[i].SubItems[2].Text);
                    cmd.Parameters.AddWithValue("@unidade_medida", listaMaterial.Items[i].SubItems[3].Text);
                    cmd.Parameters.AddWithValue("@total_material", listaMaterial.Items[i].SubItems[4].Text);
                    cmd.Parameters.AddWithValue("@valor_total", valorTotal);
                    cmd.ExecuteNonQuery();
                }



            }
            catch (Exception erro)
            {

                MessageBox.Show(erro.Message, "Erro: Orçamento Técnico Material", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Desconectar();
            }

        }

        private void SalvarDadosDaListaDeRisco()
        {
            rotinaNotaServico = new NotaServico();

            //Valor adicionado no total geral de todos os itens de mão de obra e material
            int valorTotal = 0;

            for (int i = 0; i <= lvRiscos.Items.Count - 1; i++)
            {
                rotinaNotaServico.RiscosNecessidades(tbNotaDeServico.Text, lvRiscos.Items[i].SubItems[0].Text, lvRiscos.Items[i].SubItems[1].Text, lvRiscos.Items[i].SubItems[2].Text, valorTotal);
            }

            //MessageBox.Show(rotinaNotaServico.mensagem, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tbHsNormais1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbHsNormais1.Text))
            {
                return;
            }
            else
            {
                SomatoriaDasHoras();
            }
        }

        private void tbHsExtra501_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbHsExtra501.Text))
            {
                return;
            }
            else
            {
                SomatoriaDasHoras();
            }
        }

        private void tbHsExtra1001_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbHsExtra1001.Text))
            {
                return;
            }
            else
            {
                SomatoriaDasHoras();
            }
        }

        private void tbHsNormais2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbHsNormais2.Text))
            {
                return;
            }
            else
            {
                SomatoriaDasHoras();
            }
        }

        private void tbHsNormais3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbHsNormais3.Text))
            {
                return;
            }
            else
            {
                SomatoriaDasHoras();
            }
        }

        private void tbHsNormais4_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbHsNormais4.Text))
            {
                return;
            }
            else
            {
                SomatoriaDasHoras();
            }
        }

        private void tbHsNormais5_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbHsNormais5.Text))
            {
                return;
            }
            else
            {
                SomatoriaDasHoras();
            }
        }

        private void tbHsExtra502_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbHsExtra502.Text))
            {
                return;
            }
            else
            {
                SomatoriaDasHoras();
            }
        }

        private void tbHsExtra503_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbHsExtra503.Text))
            {
                return;
            }
            else
            {
                SomatoriaDasHoras();
            }
        }

        private void tbHsExtra504_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbHsExtra504.Text))
            {
                return;
            }
            else
            {
                SomatoriaDasHoras();
            }
        }

        private void tbHsExtra505_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbHsExtra505.Text))
            {
                return;
            }
            else
            {
                SomatoriaDasHoras();
            }
        }

        private void tbHsExtra1002_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbHsExtra1002.Text))
            {
                return;
            }
            else
            {
                SomatoriaDasHoras();
            }
        }

        private void tbHsExtra1003_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbHsExtra1003.Text))
            {
                return;
            }
            else
            {
                SomatoriaDasHoras();
            }
        }

        private void tbHsExtra1004_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbHsExtra1004.Text))
            {
                return;
            }
            else
            {
                SomatoriaDasHoras();
            }        
        }

        private void tbHsExtra1005_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbHsExtra1005.Text))
            {
                return;
            }
            else
            {
                SomatoriaDasHoras();
            }
        }

        private void SalvarDadosDaNotaComAnexo()
        {
            //CheckedListBox
            string txt1 = " ", txt2 = " ", txt3 = " ";
            string todos;
            foreach (string t1 in clbMaoDeObra.CheckedItems)
            {
                txt1 += t1 + ", ";
            }
            foreach (string t2 in clbMateriais.CheckedItems)
            {
                txt2 += t2 + ", ";
            }
            foreach (string t3 in clbVerificacaoRiscos.CheckedItems)
            {
                txt3 += t3 + ", ";
            }

            //Items das CheckedListBox
            todos = txt1 + txt2 + txt3;

            MemoryStream memoria = new MemoryStream();
            bmp.Save(memoria, ImageFormat.Jpeg);
            byte[] arquivo = memoria.ToArray();

            //Armazena os dados da Nota de serviço
            rotinaNotaServico = new NotaServico(tbNotaDeServico.Text, tbNomeEmpresa_nota.Text, tbCodigoCliente_nota.Text, tbSolicitante_nota.Text, tbEmail_nota.Text, mkbContatoSolicitante_nota.Text, mkbDataSolicitacao_nota.Text, tbMatricula_nota.Text, tbNome_nota.Text, tbFuncao_nota.Text, mkbContatoUsuario_nota.Text, mkbDataAtend.Text, tbArea_nota.Text, tbLocal_nota.Text, tbEquipamento_nota.Text,
            tbCodigoEquipamento_nota.Text, tbFabricante_nota.Text, tbModelo_nota.Text, rtDescricao_nota.Text, rtDetalhamento_nota.Text, todos, tbNomeAnexo.Text, tbDescricaoAnexo.Text, arquivo, idSolicitacao);

            //MessageBox.Show(rotinaNotaServico.mensagem, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SalvarDadosDaNotaSemAnexo()
        {
            //CheckedListBox
            string txt1 = " ", txt2 = " ", txt3 = " ";
            string todos;
            foreach (string t1 in clbMaoDeObra.CheckedItems)
            {
                txt1 += t1 + ", ";

            }
            foreach (string t2 in clbMateriais.CheckedItems)
            {
                txt2 += t2 + ", ";
            }
            foreach (string t3 in clbVerificacaoRiscos.CheckedItems)
            {
                txt3 += t3 + ", ";
            }

            //Items das CheckedListBox
            //todos = txt1 + txt2 + txt3;
            todos = "null";

            //Armazena os dados da Nota de serviço
            NotaServico ns = new NotaServico();

            ns.CriarNota(tbNotaDeServico.Text, tbNomeEmpresa_nota.Text, tbCodigoCliente_nota.Text, tbSolicitante_nota.Text, tbEmail_nota.Text, mkbContatoSolicitante_nota.Text, mkbDataSolicitacao_nota.Text, tbMatricula_nota.Text, tbNome_nota.Text, tbFuncao_nota.Text, mkbContatoUsuario_nota.Text, mkbDataAtend.Text, tbArea_nota.Text, tbLocal_nota.Text, tbEquipamento_nota.Text,
            tbCodigoEquipamento_nota.Text, tbFabricante_nota.Text, tbModelo_nota.Text, rtDescricao_nota.Text, rtDetalhamento_nota.Text, todos, idSolicitacao);
            
            MessageBox.Show(ns.mensagem, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SalvarHoras()
        {
            try
            {

                cmd.Connection = con.Conectar();

                cmd.CommandText = "insert into tabela_horas_maodeobra";
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

        private void btnCriarNota_Click(object sender, EventArgs e)
        {

            if (rtDetalhamento_nota.Text == "")
            {
                MessageBox.Show("Preencha o campo (Detalhamento da Solicitação e Riscos Identificados no Levantamento) ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabControl1.SelectedTab = tabPage1;
                rtDetalhamento_nota.Focus();
                return;
            }

            if (tbNomeAnexo.Text != "" && lbItemObra.Text != "---" && lbItemMaterial.Text == "---") //Condição caso o orçamento Material nao seja preenchido
            {

                //Armazena os dados da Nota de serviço
                SalvarDadosDaNotaComAnexo();

                //Armazena os itens da lista mao de obra
                SalvarDadosMaoDeObra();

                SalvarDadosDaListaDeRisco();

            }
            else if (tbNomeAnexo.Text == "" && lbItemMaterial.Text == "---" && lbItemObra.Text != "---") //Condição caso apenas o campo Mão de Obra seja preenchido
            {

                //Armazena os dados da Nota de serviço
                SalvarDadosDaNotaSemAnexo();

                //Armazena os itens da lista mao de obra
                SalvarDadosMaoDeObra();

                SalvarDadosDaListaDeRisco();

            }
            else if (tbNomeAnexo.Text == "" && lbItemObra.Text != "---" && lbItemMaterial.Text != "---") //Condição caso o Anexo não seja adicionado
            {

                //Armazena os dados da Nota de serviço
                SalvarDadosDaNotaSemAnexo();

                //Armazena os itens da lista mao de obra
                SalvarDadosMaoDeObra();

                //Armazena os itens da lista Material
                SalvarDadosMaterial();

                SalvarDadosDaListaDeRisco();
            }
            else //Codiçao para o preenchimento completo da Nota de Serviço
            {

                //Armazena os dados da Nota de serviço
                SalvarDadosDaNotaComAnexo();

                //Armazena os itens da lista mao de obra
                SalvarDadosMaoDeObra();

                //Armazena os itens da lista Material
                SalvarDadosMaterial();

                SalvarDadosDaListaDeRisco();

            }

            this.Close();
        }

        private void rtDetalhamento_nota_TextChanged(object sender, EventArgs e)
        {
            int totalChar = 0;

            totalChar = rtDetalhamento_nota.TextLength;

            lbTotalDeCaracteres.Text = totalChar.ToString();
        }

        private void groupBox18_Enter(object sender, EventArgs e)
        {

        }

        private void btnAnexa_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string nomeAnexo = openFileDialog1.FileName;
                string nomeAnexo2 = openFileDialog1.SafeFileName;

                bmp = new Bitmap(nomeAnexo);

                tbNomeAnexo.Text = nomeAnexo2;
                pbAnexo.Image = bmp;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCalcularMaoObra_Click(object sender, EventArgs e)
        {
            RotinaDeCalculoDeHaras();
            SomatoriaDasHoras();
        }

        private void MensagemDeErro(string periodo)
        {
            MessageBox.Show("Preencha a Hora Inicial e a Hora Final do (" + periodo + ") ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        public void RotinaDeCalculoDeHaras()
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

        public void SomatoriaDasHoras()
        {
            tbTotalRefeicao.Text = calculoHora.SomaTempoRefeicao(double.Parse(tbTempoRefeicao1.Text), double.Parse(tbTempoRefeicao2.Text), double.Parse(tbTempoRefeicao3.Text), double.Parse(tbTempoRefeicao4.Text), double.Parse(tbTempoRefeicao5.Text)).ToString();
            tbTotalHs.Text = calculoHora.SomaTotalDeHoras(double.Parse(tbTotalHs1.Text), double.Parse(tbTotalHs2.Text), double.Parse(tbTotalHs3.Text), double.Parse(tbTotalHs4.Text), double.Parse(tbTotalHs5.Text)).ToString();
            tbTotalNormais.Text = calculoHora.SomaHoraNormal(double.Parse(tbHsNormais1.Text), double.Parse(tbHsNormais2.Text), double.Parse(tbHsNormais3.Text), double.Parse(tbHsNormais4.Text), double.Parse(tbHsNormais5.Text)).ToString();
            tbTotalExtra50.Text = calculoHora.SomaHoraExtra50(double.Parse(tbHsExtra501.Text), double.Parse(tbHsExtra502.Text), double.Parse(tbHsExtra503.Text), double.Parse(tbHsExtra504.Text), double.Parse(tbHsExtra505.Text)).ToString();
            tbTotalExtra100.Text = calculoHora.SomaHoraExtra100(double.Parse(tbHsExtra1001.Text), double.Parse(tbHsExtra1002.Text), double.Parse(tbHsExtra1003.Text), double.Parse(tbHsExtra1004.Text), double.Parse(tbHsExtra1005.Text)).ToString();
        }

        private void btnLimparAnexo_Click(object sender, EventArgs e)
        {
            pbAnexo.Image = null;
            pbAnexo.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
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

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
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

        private void btnRemoverItemRisco_Click(object sender, EventArgs e)
        {
            lvRiscos.Items.RemoveAt(lvRiscos.SelectedIndices[0]);
        }
    }
}
