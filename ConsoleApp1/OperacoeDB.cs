using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace ConsoleApp1
{
    internal static class OperacoeDB
    {
        static SQLiteCommand cmd = new SQLiteCommand();
        static SQLiteDataAdapter da;


        public static void LimparDatabase()
        {

            cmd.Connection = Conexao.Conectar();
           
            cmd.CommandText = "delete from tabela_cliente";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "delete from tabela_custos_despesas";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "delete from tabela_data";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "delete from tabela_horas_maodeobra";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "delete from tabela_maodeobra";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "delete from tabela_material";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "delete from tabela_nota_servico";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "delete from tabela_resumo_valores";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "delete from tabela_riscos";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "delete from tabela_solicitacao_servico";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "delete from tabela_solicitantes";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "delete from tabela_usuario";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "delete from tabela_valores_entrada";
            cmd.ExecuteNonQuery();

            Conexao.Desconectar();

        }

        public static DataTable ExibirDadosTabela(string nomeTabela)
        {
            cmd.Connection = Conexao.Conectar();

            cmd.CommandText = "select * from '" + nomeTabela + "'";
            cmd.ExecuteNonQuery();

            da = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

    }
}
