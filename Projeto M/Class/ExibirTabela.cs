using System;
using System.Data;
using System.Data.SQLite;

namespace Projeto_M
{
    class ExibirTabela
    {
        Conexao con = new Conexao();
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataAdapter da;
        DataTable dt;

        public object ExibirTabelaSolicitacao()
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "Select * From Tabela_Solicitacao_Servico";
                cmd.ExecuteNonQuery();
                da = new SQLiteDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                dt.Columns[1].ColumnName = "Numero Solicitação";
                dt.Columns[2].ColumnName = "Código Cliente";
                dt.Columns[3].ColumnName = "Solicitante";
                dt.Columns[4].ColumnName = "Matrícula (Funcionário)";
                dt.Columns[5].ColumnName = "Área";
                dt.Columns[6].ColumnName = "Local";
                dt.Columns[7].ColumnName = "Equipmaneto";
                dt.Columns[8].ColumnName = "Código Equipamento";
                dt.Columns[9].ColumnName = "Fabricante";
                dt.Columns[10].ColumnName = "Modelo";
                dt.Columns[11].ColumnName = "Descrição";
                dt.Columns[12].ColumnName = "Data Solicitação";
                dt.Columns[13].ColumnName = "Data Atendimento";
                return dt;
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

        public object Teste()
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "Select * From Tabela_Solicitacao_Servico";
                cmd.ExecuteNonQuery();
                da = new SQLiteDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                dt.Columns[1].ColumnName = "Numero Solicitação";
                dt.Columns[2].ColumnName = "Código Cliente";
                dt.Columns[3].ColumnName = "Solicitante";
                dt.Columns[4].ColumnName = "Matrícula (Funcionário)";
                dt.Columns[5].ColumnName = "Área";
                dt.Columns[6].ColumnName = "Local";
                dt.Columns[7].ColumnName = "Equipmaneto";
                dt.Columns[8].ColumnName = "Código Equipamento";
                dt.Columns[9].ColumnName = "Fabricante";
                dt.Columns[10].ColumnName = "Modelo";
                dt.Columns[11].ColumnName = "Descrição";
                dt.Columns[12].ColumnName = "Data Solicitação";
                dt.Columns[13].ColumnName = "Data Atendimento";
                return dt;
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

        public object ExibirTabelaNotaServico()
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "Select * From Tabela_Nota_Servico";
                cmd.ExecuteNonQuery();
                da = new SQLiteDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                dt.Columns[1].ColumnName = "Nº Nota";
                dt.Columns[2].ColumnName = "Nome Cliente";
                dt.Columns[13].ColumnName = "Area/Setor";
                dt.Columns[14].ColumnName = "Local";
                dt.Columns[15].ColumnName = "Equipamento";
                dt.Columns[19].ColumnName = "Descrição";
                dt.Columns[20].ColumnName = "Detalhamento";
                return dt;
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

        public object FiltrarNotaServico(string numerNota)
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_NOTA_SERVICO WHERE NUMERO_NOTA = '" + numerNota + "'";
                //cmd.Parameters.AddWithValue("@NOME_CLIENTE", nomeCliente);
                cmd.ExecuteNonQuery();

                da = new SQLiteDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                dt.Columns[1].ColumnName = "Nº Nota";
                dt.Columns[2].ColumnName = "Nome Cliente";
                dt.Columns[13].ColumnName = "Area/Setor";
                dt.Columns[14].ColumnName = "Local";
                dt.Columns[15].ColumnName = "Equipamento";
                dt.Columns[19].ColumnName = "Descrição";
                dt.Columns[20].ColumnName = "Detalhamento";
                return dt;
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

        public object ExibirClientes()
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_CLIENTE";
                cmd.ExecuteNonQuery();

                da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dt.Columns[1].ColumnName = "Cód. Cliente";
                dt.Columns[4].ColumnName = "Nome Empresa";
                dt.Columns[5].ColumnName = "CNPJ";
                dt.Columns[6].ColumnName = "Sigla Empresa";
                dt.Columns[12].ColumnName = "Cidade";
                dt.Columns[13].ColumnName = "UF";
                dt.Columns[15].ColumnName = "Telefone Cliente";
                dt.Columns[16].ColumnName = "Ramal";
                dt.Columns[17].ColumnName = "E-mail";
                dt.Columns[18].ColumnName = "Responsável";
                dt.Columns[19].ColumnName = "Contato Responsável";
                dt.Columns[20].ColumnName = "Setor Contato";


                return dt;
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

        public object BuscarClienteCodigo(string codClinte)
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_CLIENTE WHERE COD_CLIENTE = '" + codClinte + "'";
                cmd.ExecuteNonQuery();

                da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dt.Columns[1].ColumnName = "Cód. Cliente";
                dt.Columns[4].ColumnName = "Nome Empresa";
                dt.Columns[5].ColumnName = "CNPJ";
                dt.Columns[6].ColumnName = "Sigla Empresa";
                dt.Columns[12].ColumnName = "Cidade";
                dt.Columns[13].ColumnName = "UF";
                dt.Columns[15].ColumnName = "Telefone Cliente";
                dt.Columns[16].ColumnName = "Ramal";
                dt.Columns[17].ColumnName = "E-mail";
                dt.Columns[18].ColumnName = "Responsável";
                dt.Columns[19].ColumnName = "Contato Responsável";
                dt.Columns[20].ColumnName = "Setor Contato";

                return dt;
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

        public object BuscarClienteNomeEmpresa(string nomeEmpresa)
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_CLIENTE WHERE NOME_EMPRESA = '" + nomeEmpresa + "'";
                cmd.ExecuteNonQuery();

                da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dt.Columns[1].ColumnName = "Cód. Cliente";
                dt.Columns[4].ColumnName = "Nome Empresa";
                dt.Columns[5].ColumnName = "CNPJ";
                dt.Columns[6].ColumnName = "Sigla Empresa";
                dt.Columns[12].ColumnName = "Cidade";
                dt.Columns[13].ColumnName = "UF";
                dt.Columns[15].ColumnName = "Telefone Cliente";
                dt.Columns[16].ColumnName = "Ramal";
                dt.Columns[17].ColumnName = "E-mail";
                dt.Columns[18].ColumnName = "Responsável";
                dt.Columns[19].ColumnName = "Contato Responsável";
                dt.Columns[20].ColumnName = "Setor Contato";

                return dt;
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

        public object ConsultaOrcamento()
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT [tabela_nota_servico].[numero_nota], n_cliente, n_solicitante, n_data_atend, total_entrada, total_custos_imposto, total_servico FROM tabela_nota_servico" +
                    " INNER JOIN tabela_resumo_valores ON tabela_nota_servico.NUMERO_NOTA = tabela_resumo_valores.NUMERO_NOTA";
                cmd.ExecuteNonQuery();

                da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dt.Columns[0].ColumnName = "Nº Nota";
                dt.Columns[1].ColumnName = "Cliente";
                dt.Columns[2].ColumnName = "Solicitante";
                dt.Columns[3].ColumnName = "Data Atendimento";
                dt.Columns[4].ColumnName = "Total Entrada (R$)";
                dt.Columns[5].ColumnName = "Total Impostos (R$)";
                dt.Columns[6].ColumnName = "Total Serviço (R$)";

                return dt;
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

        public object FiltraOrcamento(string numeroNota)
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT [tabela_nota_servico].[numero_nota], n_cliente, n_solicitante, n_data_atend, total_entrada, total_custos_imposto, total_servico FROM tabela_nota_servico" +
                    " INNER JOIN tabela_resumo_valores ON tabela_nota_servico.NUMERO_NOTA = tabela_resumo_valores.NUMERO_NOTA WHERE [tabela_nota_servico].[numero_nota] = '" + numeroNota + "'";
                cmd.ExecuteNonQuery();

                da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dt.Columns[0].ColumnName = "Nº Nota";
                dt.Columns[1].ColumnName = "Cliente";
                dt.Columns[2].ColumnName = "Solicitante";
                dt.Columns[3].ColumnName = "Data Atendimento";
                dt.Columns[4].ColumnName = "Total Entrada (R$)";
                dt.Columns[5].ColumnName = "Total Impostos (R$)";
                dt.Columns[6].ColumnName = "Total Serviço (R$)";

                return dt;

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

        public object FiltrarOrcamento_Nome(string nomeCliente)
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT [tabela_nota_servico].[numero_nota], n_cliente, n_solicitante, n_data_atend, total_entrada, total_custos_imposto, total_servico FROM tabela_nota_servico" +
                    " INNER JOIN tabela_resumo_valores ON tabela_nota_servico.NUMERO_NOTA = tabela_resumo_valores.NUMERO_NOTA WHERE n_cliente = '" + nomeCliente + "'";
                cmd.ExecuteNonQuery();

                da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dt.Columns[0].ColumnName = "Nº Nota";
                dt.Columns[1].ColumnName = "Cliente";
                dt.Columns[2].ColumnName = "Solicitante";
                dt.Columns[3].ColumnName = "Data Atendimento";
                dt.Columns[4].ColumnName = "Total Entrada (R$)";
                dt.Columns[5].ColumnName = "Total Impostos (R$)";
                dt.Columns[6].ColumnName = "Total Serviço (R$)";

                return dt;

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

        public object DadosUsuario()
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT matricula, nome, especialidade, funcao, nivel_acesso, celular FROM TABELA_USUARIO";
                cmd.ExecuteNonQuery();

                da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dt.Columns[0].ColumnName = "Matricula";
                dt.Columns[1].ColumnName = "Nome";
                dt.Columns[2].ColumnName = "Especialidade";
                dt.Columns[3].ColumnName = "Função";
                dt.Columns[4].ColumnName = "Nível Acesso";
                dt.Columns[5].ColumnName = "Celular";

                return dt;

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

        public object FiltraUsuario_Matricula(string matricula)
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT matricula, nome, especialidade, funcao, nivel_acesso, celular FROM TABELA_USUARIO WHERE MATRICULA = '" + matricula + "'";
                cmd.ExecuteNonQuery();

                da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dt.Columns[0].ColumnName = "Matricula";
                dt.Columns[1].ColumnName = "Nome";
                dt.Columns[2].ColumnName = "Especialidade";
                dt.Columns[3].ColumnName = "Função";
                dt.Columns[4].ColumnName = "Nível Acesso";
                dt.Columns[5].ColumnName = "Celular";

                return dt;
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

        public object DGVListsDeServico()
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "select tabela_solicitacao_servico.NUMERO_SERVICO, tabela_solicitacao_servico.DESCRICAO, tabela_nota_servico.NUMERO_NOTA, tabela_nota_servico.N_CLIENTE, tabela_nota_servico.N_NOME, tabela_solicitacao_servico.DATA_SOLICITACAO " +
                    "from tabela_solicitacao_servico " +
                    "inner join tabela_nota_servico " +
                    "on tabela_nota_servico.NUMERO_NOTA = tabela_solicitacao_servico.NUMERO_SERVICO";
                cmd.ExecuteNonQuery();

                da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dt.Columns[0].ColumnName = "Nº Solicitação";
                dt.Columns[1].ColumnName = "Descrição";
                dt.Columns[2].ColumnName = "Nº Nota";
                dt.Columns[3].ColumnName = "Cliente";
                dt.Columns[4].ColumnName = "Responsavel Menplan";
                dt.Columns[5].ColumnName = "Data Solicitação";


                return dt;

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

        public object FiltroListaServico(string numeroServico)
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "select tabela_solicitacao_servico.NUMERO_SERVICO, tabela_solicitacao_servico.DESCRICAO, tabela_nota_servico.NUMERO_NOTA, tabela_nota_servico.N_CLIENTE, tabela_nota_servico.N_NOME, tabela_solicitacao_servico.DATA_SOLICITACAO " +
                    "from tabela_solicitacao_servico " +
                    "inner join tabela_nota_servico " +
                    "on tabela_nota_servico.id_solicitacao = tabela_solicitacao_servico.NUMERO_SERVICO where id_solicitacao = '" + numeroServico + "'";
                cmd.ExecuteNonQuery();

                da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dt.Columns[0].ColumnName = "Nº Solicitação";
                dt.Columns[1].ColumnName = "Descrição";
                dt.Columns[2].ColumnName = "Nº Nota";
                dt.Columns[3].ColumnName = "Cliente";
                dt.Columns[4].ColumnName = "Responsavel Menplan";
                dt.Columns[5].ColumnName = "Data Solicitação";

                return dt;
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
    }
}
