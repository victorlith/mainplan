using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


namespace Projeto_M.Class01
{
	class DadosPdf
	{
		Conexao con = new Conexao();
		SQLiteCommand cmd = new SQLiteCommand();
		SQLiteDataReader dr;

		public string nota, codCliente;
		//public string Sigla;

		//Dados Cliente
		string cep, lorgradouro, numeroEndereco, complemento, bairro, cidade, uf;
		string razaoSocial, nomeEmpresa, telefoneCliente, email, cnpj, solicitante;

		//Solicitação Servicço
		string solicitacao;

		//Dados Nota Serviço
		string dataSolicitacao, descricao, codEquipamento, responsavel, area, equipamento;


		public String mensagem = "";

		public string[] DadosCliente()
		{
			try
			{
				cmd.Connection = con.conectar();

				cmd.CommandText = "SELECT * FROM TABELA_NOTA_SERVICO WHERE NUMERO_NOTA = '" + nota + "' ";
				dr = cmd.ExecuteReader();

				while (dr.Read())
				{
					codCliente = (string)dr["n_empresa"];
				}
				dr.Close();

			}
			catch (Exception ex)
			{

				this.mensagem = ex.Message;
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
					//Sigla = (string)dr["sigla_empresa"];
					cep = (string)dr["cep"]; // Indice 0
					lorgradouro = (string)dr["LORGRADOURO"]; // Indice 1
					numeroEndereco = (string)dr["numero_endereco"]; // Indice 2
					complemento = (string)dr["complemento"]; // Indice 3
					bairro = (string)dr["bairro"]; // Indice 4
					cidade = (string)dr["cidade"]; // Indice 5
					uf = (string)dr["uf"]; // Indice 6

					razaoSocial = (string)dr["razao_social"]; // Indice 7
					nomeEmpresa = (string)dr["nome_empresa"]; // Indice 8
					telefoneCliente = (string)dr["telefone_cliente"]; // Indice 9
					email = (string)dr["email"]; // Indice 10
					cnpj = (string)dr["cnpj"];


				}
				dr.Close();
			}
			catch (Exception ex)
			{

				this.mensagem = ex.Message;
			}
			finally
			{
				con.desconectar();
			}

			return new[] { cep, lorgradouro, numeroEndereco, complemento, bairro, cidade, uf, razaoSocial, nomeEmpresa, telefoneCliente, email, cnpj };
		}

		public string[] DadosServico()
		{
			try
			{
				cmd.Connection = con.conectar();

				cmd.CommandText = "SELECT * FROM TABELA_NOTA_SERVICO WHERE NUMERO_NOTA = '" + nota + "' ";
				dr = cmd.ExecuteReader();

				while (dr.Read())
				{
					dataSolicitacao = (string)dr["n_data_soli"]; //ID 0
					descricao = (string)dr["n_descricao"]; //ID 1
					codEquipamento = (string)dr["n_cod_equipamento"]; //ID 2
					responsavel = (string)dr["n_nome"]; //ID 3
					area = (string)dr["n_area"]; //ID 4
					equipamento = (string)dr["n_equipamento"]; //ID5
					solicitante = (string)dr["n_solicitante"]; //ID7
				}
				dr.Close();

			}
			catch (Exception ex)
			{

				this.mensagem = ex.Message;
			}
			finally
			{
				con.desconectar();
			}

			try
			{
				cmd.Connection = con.conectar();

				cmd.CommandText = "SELECT * FROM TABELA_SOLICITACAO_SERVICO WHERE NUMERO_SERVICO = '" + nota + "' ";
				dr = cmd.ExecuteReader();

				while (dr.Read())
				{
					solicitacao = (string)dr["descricao"]; //ID 6
				}
				dr.Close();

			}
			catch (Exception ex)
			{

				this.mensagem = ex.Message;
			}
			finally
			{
				con.desconectar();
			}

			return new[] { dataSolicitacao, descricao, codEquipamento, responsavel, area, equipamento, solicitacao, solicitante };
		}
	}
}
