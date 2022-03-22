using System;
using System.Data;
using System.Data.SQLite;

namespace Projeto_M.Class
{
    public class ListasDeServico
    {
        Conexao con = new Conexao();
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataReader dr;


        public object DadosNumeroSolicitacao()
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT NUMERO_SERVICO FROM TABELA_SOLICITACAO_SERVICO";
                dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);

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

        public object DadosNotaServico()
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT NUMERO_NOTA FROM TABELA_NOTA_SERVICO";
                dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);

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

        public object DadosNomeCliente()
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT NOME_FANTASIA FROM TABELA_CLIENTE";
                dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);

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

        public object DadosResponsavelMenplan()
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT NOME FROM TABELA_USUARIO";
                dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);

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
