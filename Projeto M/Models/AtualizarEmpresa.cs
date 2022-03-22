using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Projeto_M.Class01
{
	class AtualizarEmpresa
	{
		Conexao con = new Conexao();
		SQLiteCommand cmd = new SQLiteCommand();

		public String mensagem = "";

		public void AtualizarCliente(string codCliente, string pessoa, string contatoResponsavel, string setorContato, string telefoneCliente, string ramal)
		{
			try
			{
				cmd.Connection = con.conectar();

				cmd.CommandText = "UPDATE TABELA_CLIENTE SET PESSOA_RESPONSAVEL = @PESSOA_RESPONSAVEL, CONTATO_RESPONSAVEL = @CONTATO_RESPONSAVEL, SETOR_CONTATO = @SETOR_CONTATO, TELEFONE_CLIENTE = @TELEFONE_CLIENTE, RAMAL = @RAMAL WHERE COD_CLIENTE = @COD_CLIENTE";

				cmd.Parameters.AddWithValue("@COD_CLIENTE", codCliente);
				cmd.Parameters.AddWithValue("@PESSOA_RESPONSAVEL", pessoa);
				cmd.Parameters.AddWithValue("@CONTATO_RESPONSAVEL", contatoResponsavel);
				cmd.Parameters.AddWithValue("@SETOR_CONTATO", setorContato);
				cmd.Parameters.AddWithValue("@TELEFONE_CLIENTE", telefoneCliente);
				cmd.Parameters.AddWithValue("@RAMAL", ramal);
				cmd.ExecuteNonQuery();

				this.mensagem = "Dados atualizado com sucesso!";
			}
			catch (Exception ex)
			{

				this.mensagem = ex.Message;
			}
			finally
			{
				con.desconectar();
			}
		}
	}
}
