using System;
using System.Data;
using System.Data.SQLite;

namespace Projeto_M
{
    class NotaServico
    {
        Conexao con = new Conexao();
        SQLiteCommand cmd = new SQLiteCommand();

        public String mensagem = "";

        public NotaServico()
        {
        }

        public NotaServico(String numeroNota, String empresa, String cod, String solicitante, String email, String contato, String dataSolicitacao,
            String matricula, String nome, String funcao, String contato2, String dataAtend, String area, String local, String equipamento,
            String codEquipamento, String fabricante, String modelo, String descricao, String detalhamento, String rvr, String nomeAnexo, String descricaoAnexo, Byte[] arquivo, string idSolicitacao)
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "INSERT INTO TABELA_NOTA_SERVICO (numero_nota, n_cliente, n_empresa, n_solicitante, n_email, n_contato, n_data_soli, n_matricula, n_nome, n_funcao, n_contato2, n_data_atend, n_area, n_local, n_equipamento, n_cod_equipamento, n_fabricante, n_modelo, n_descricao, n_detalhamento, rvr, nome_anexo, descricao_anexo, anexo, id_solicitacao) " +
                    "VALUES (@numero_nota, @n_cliente, @n_empresa, @n_solicitante, @n_email, @n_contato, @n_data_soli, @n_matricula, @n_nome, @n_funcao, @n_contato2, @n_data_atend, @n_area, @n_local, @n_equipamento, @n_cod_equipamento, @n_fabricante, @n_modelo, @n_descricao, @n_detalhamento, @rvr, @nome_anexo, @descricao_anexo, @anexo, @idSolicitacao)";

                cmd.Parameters.AddWithValue("@numero_nota", numeroNota);
                cmd.Parameters.AddWithValue("@n_cliente", empresa);
                cmd.Parameters.AddWithValue("@n_empresa", cod);
                cmd.Parameters.AddWithValue("@n_solicitante", solicitante);
                cmd.Parameters.AddWithValue("@n_email", email);
                cmd.Parameters.AddWithValue("@n_contato", contato);
                cmd.Parameters.AddWithValue("@n_data_soli", dataSolicitacao);
                cmd.Parameters.AddWithValue("@n_matricula", matricula);
                cmd.Parameters.AddWithValue("@n_nome", nome);
                cmd.Parameters.AddWithValue("@n_funcao", funcao);
                cmd.Parameters.AddWithValue("@n_contato2", contato2);
                cmd.Parameters.AddWithValue("@n_data_atend", dataAtend);
                cmd.Parameters.AddWithValue("@n_area", area);
                cmd.Parameters.AddWithValue("@n_local", local);
                cmd.Parameters.AddWithValue("@n_equipamento", equipamento);
                cmd.Parameters.AddWithValue("@n_cod_equipamento", codEquipamento);
                cmd.Parameters.AddWithValue("@n_fabricante", fabricante);
                cmd.Parameters.AddWithValue("@n_modelo", modelo);
                cmd.Parameters.AddWithValue("@n_descricao", descricao);
                cmd.Parameters.AddWithValue("@n_detalhamento", detalhamento);
                cmd.Parameters.AddWithValue("@rvr", rvr);
                cmd.Parameters.AddWithValue("@nome_anexo", nomeAnexo);
                cmd.Parameters.AddWithValue("@descricao_anexo", descricaoAnexo);
                cmd.Parameters.AddWithValue("@idSolicitacao", idSolicitacao);
                SQLiteParameter imagem = new SQLiteParameter("@anexo", DbType.Binary);
                imagem.Value = arquivo;
                cmd.Parameters.Add(imagem);
                cmd.ExecuteNonQuery();

                this.mensagem = "Nota criada com sucesso!";


            }
            catch (Exception ex)
            {

                this.mensagem = ex.Message;
            }
            finally
            {
                con.Desconectar();
            }
        }

        public void CriarNota(String numeroNota, String empresa, String cod, String solicitante, String email, String contato, String dataSolicitacao,
            String matricula, String nome, String funcao, String contato2, String dataAtend, String area, String local, String equipamento,
            String codEquipamento, String fabricante, String modelo, String descricao, String detalhamento, String rvr, string idSolicitacao)
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "INSERT INTO TABELA_NOTA_SERVICO (numero_nota, n_cliente, n_empresa, n_solicitante, n_email, n_contato, n_data_soli, n_matricula, n_nome, n_funcao, n_contato2, n_data_atend, n_area, n_local, n_equipamento, n_cod_equipamento, n_fabricante, n_modelo, n_descricao, n_detalhamento, rvr, id_solicitacao) " +
                    "VALUES (@numero_nota, @n_cliente, @n_empresa, @n_solicitante, @n_email, @n_contato, @n_data_soli, @n_matricula, @n_nome, @n_funcao, @n_contato2, @n_data_atend, @n_area, @n_local, @n_equipamento, @n_cod_equipamento, @n_fabricante, @n_modelo, @n_descricao, @n_detalhamento, @rvr, @idSolicitacao)";

                cmd.Parameters.AddWithValue("@numero_nota", numeroNota);
                cmd.Parameters.AddWithValue("@n_cliente", empresa);
                cmd.Parameters.AddWithValue("@n_empresa", cod);
                cmd.Parameters.AddWithValue("@n_solicitante", solicitante);
                cmd.Parameters.AddWithValue("@n_email", email);
                cmd.Parameters.AddWithValue("@n_contato", contato);
                cmd.Parameters.AddWithValue("@n_data_soli", dataSolicitacao);
                cmd.Parameters.AddWithValue("@n_matricula", matricula);
                cmd.Parameters.AddWithValue("@n_nome", nome);
                cmd.Parameters.AddWithValue("@n_funcao", funcao);
                cmd.Parameters.AddWithValue("@n_contato2", contato2);
                cmd.Parameters.AddWithValue("@n_data_atend", dataAtend);
                cmd.Parameters.AddWithValue("@n_area", area);
                cmd.Parameters.AddWithValue("@n_local", local);
                cmd.Parameters.AddWithValue("@n_equipamento", equipamento);
                cmd.Parameters.AddWithValue("@n_cod_equipamento", codEquipamento);
                cmd.Parameters.AddWithValue("@n_fabricante", fabricante);
                cmd.Parameters.AddWithValue("@n_modelo", modelo);
                cmd.Parameters.AddWithValue("@n_descricao", descricao);
                cmd.Parameters.AddWithValue("@n_detalhamento", detalhamento);
                cmd.Parameters.AddWithValue("@rvr", rvr);
                cmd.Parameters.AddWithValue("@idSolicitacao", idSolicitacao);
                cmd.ExecuteNonQuery();

                this.mensagem = "Nota criada com sucesso!";


            }
            catch (Exception ex)
            {

                this.mensagem = ex.Message;
            }
            finally
            {
                con.Desconectar();
            }
        }

        public void RiscosNecessidades(string numeroNota, string numeroItem, string descricaoRisco, string bloqueioRisco, int valorTotal)
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "INSERT INTO TABELA_RISCOS (n_nota, n_item_risco, descricao_risco, bloqueio_risco, custo_risco) VALUES (@n_nota, @n_item_risco, @descricao_risco, @bloqueio_risco, @custo_risco)";

                cmd.Parameters.AddWithValue("@n_nota", numeroNota);
                cmd.Parameters.AddWithValue("@n_item_risco", numeroItem);
                cmd.Parameters.AddWithValue("@descricao_risco", descricaoRisco);
                cmd.Parameters.AddWithValue("@bloqueio_risco", bloqueioRisco);
                cmd.Parameters.AddWithValue("@custo_risco", valorTotal);
                cmd.ExecuteNonQuery();

                this.mensagem = "Nota criada com sucesso!";
            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
            }
            finally
            {
                con.Desconectar();
            }
        }
    }
}
