using System;
using System.Data.SQLite;

namespace Projeto_M.Class01
{
	class PastaDestino
	{

		public static string codCliente;
		public static string dataNota;


		//Variaveis para criação da pasta
		public static string path; //Variavel referente ao local da pasta
		public static string sigla;
		public static string[] spl = new string[2];

		public static String mensagem = "";


		public static string CriarPasta(string numeroPasta, string data, string codCliente)
		{
			Conexao con = new Conexao();
			SQLiteCommand cmd = new SQLiteCommand();
			SQLiteDataReader dr;

			spl = data.Split('/');

			try
			{
				
				cmd.Connection = con.conectar();

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

				mensagem = ex.Message;
			}
			finally
			{
				con.desconectar();
			}

			return path = @"C:\Arquivos Menplan\" + string.Format($"{spl[2]}") + numeroPasta + "_" + "Nota_Servico_" + sigla;

		}

		public static string  Pasta()
		{
			return path;
		}

		public static string PastaNota(string numeroNota)
		{
			Conexao con = new Conexao();
			SQLiteCommand cmd = new SQLiteCommand();
			SQLiteDataReader dr;

			try
			{
				cmd.Connection = con.conectar();

				cmd.CommandText = "SELECT * FROM TABELA_NOTA_SERVICO WHERE NUMERO_NOTA = '" + numeroNota + "'";
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

				mensagem = ex.Message;
			}
			finally
			{
				con.desconectar();
			}

			try
			{

				cmd.Connection = con.conectar();

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

				mensagem = ex.Message;
			}
			finally
			{
				con.desconectar();
			}

			return path = @"C:\Arquivos Menplan\" + string.Format($"{spl[2]}") + numeroNota + "_" + "Nota_Servico_" + sigla;
		}
	}
}
