using System;
using System.Data.SQLite;
using Projeto_M.Class;

namespace Projeto_M
{
    class SolicitacaoServico
    {
        Conexao con = new Conexao();
        SQLiteCommand cmd = new SQLiteCommand();
        

        public string mensagem = "";

        public void SalvarSolicitacao(string idCliente, string solicitante, string matricula, string numeroServico, string area, string local, String equipamento, String codEquipamento, String fabricante, String modelo, String descricao, String dataSli, String dataAtend, string email, string contato)
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "INSERT INTO TABELA_SOLICITACAO_SERVICO (NUMERO_SERVICO, ID_CLIENTE, SOLICITANTE, MATRICULA_RESPONSAVEL, AREA, LOCAL_INSTALACAO, EQUIPAMENTO, COD_EQUIPAMENTO, FABRICANTE, MODELO, DESCRICAO, DATA_SOLICITACAO, DATA_ATENDIMENTO, EMAIL_SOLICITANTE, CONTATO_SOLICITANTE)" +
                    "VALUES (@NUMERO_SERVICO, @ID_CLIENTE, @SOLICITANTE, @MATRICULA_RESPONSAVEL, @AREA, @LOCAL, @EQUIPAMENTO, @COD_EQUIPAMENTO, @FABRICANTE, @MODELO, @DESCRICAO, @DATA_SOLICITACAO, @DATA_ATENDIMENTO, @EMAIL_SOLICITANTE, @CONTATO_SOLICITANTE)";


                cmd.Parameters.AddWithValue("@ID_CLIENTE", idCliente);
                cmd.Parameters.AddWithValue("@SOLICITANTE", solicitante);
                cmd.Parameters.AddWithValue("@MATRICULA_RESPONSAVEL", matricula);
                cmd.Parameters.AddWithValue("@NUMERO_SERVICO", numeroServico);
                cmd.Parameters.AddWithValue("@AREA", area);
                cmd.Parameters.AddWithValue("@LOCAL", local);
                cmd.Parameters.AddWithValue("@EQUIPAMENTO", equipamento);
                cmd.Parameters.AddWithValue("@COD_EQUIPAMENTO", codEquipamento);
                cmd.Parameters.AddWithValue("@FABRICANTE", fabricante);
                cmd.Parameters.AddWithValue("@MODELO", modelo);
                cmd.Parameters.AddWithValue("@DESCRICAO", descricao);
                cmd.Parameters.AddWithValue("@DATA_SOLICITACAO", dataSli);
                cmd.Parameters.AddWithValue("@DATA_ATENDIMENTO", dataAtend);
                cmd.Parameters.AddWithValue("@EMAIL_SOLICITANTE", email);
                cmd.Parameters.AddWithValue("@CONTATO_SOLICITANTE", contato);

                cmd.ExecuteNonQuery();

                this.mensagem = "Solicitação salva com Sucesso!";
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

        public string SalvarNovoCliente(string nomeCliente, string IDcliente, string solicitante, string email, string telefone)
        {
            try
            {
                GeraNovoID novoID = new GeraNovoID();

                IDcliente = novoID.GerarCodigoCliente();

                cmd.Connection = con.Conectar();

                cmd.CommandText = "insert into tabela_cliente (cod_cliente, nome_empresa) values (@cod_cliente, @nomeEmpresa)";
                cmd.Parameters.AddWithValue("@cod_cliente", IDcliente);
                cmd.Parameters.AddWithValue("@nomeEmpresa", nomeCliente.ToUpper());
                cmd.ExecuteNonQuery();


                cmd.CommandText = "insert into tabela_solicitantes (nome, email, telefone, fk_cliente) values (@nome, @email, @telefone, @fk_cliente)";
                cmd.Parameters.AddWithValue("@nome", solicitante.ToUpper());
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@telefone", telefone);
                cmd.Parameters.AddWithValue("@fk_cliente", IDcliente);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Desconectar();
            }

            return IDcliente;
        }

        public void SalvarNovoSolicitante(string IDcliente, string solicitante, string email, string telefone)
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "insert into tabela_solicitantes (nome, email, telefone, fk_cliente) values (@nome, @email, @telefone, @fk_cliente)";
                cmd.Parameters.AddWithValue("@nome", solicitante.ToUpper());
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@telefone", telefone);
                cmd.Parameters.AddWithValue("@fk_cliente", IDcliente);
                cmd.ExecuteNonQuery();
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
