using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


namespace Projeto_M
{
	class CadastroServico
	{
		Conexao con = new Conexao();
		SQLiteCommand cmd = new SQLiteCommand();

		public String mensagem = "";

		public CadastroServico(String idCliente, String solicitante, String matricula, String numeroServico, String area, String local, String equipamento, String codEquipamento, String fabricante, String modelo, String descricao, String dataSli, String dataAtend)
		{

			try
			{
				cmd.Connection = con.conectar();

				cmd.CommandText = "INSERT INTO TABELA_SOLICITACAO_SERVICO (NUMERO_SERVICO, ID_CLIENTE, SOLICITANTE, MATRICULA_RESPONSAVEL, AREA, LOCAL_INSTALACAO, EQUIPAMENTO, COD_EQUIPAMENTO, FABRICANTE, MODELO, DESCRICAO, DATA_SOLICITACAO, DATA_ATENDIMENTO)" +
					"VALUES (@NUMERO_SERVICO, @ID_CLIENTE, @SOLICITANTE, @MATRICULA_RESPONSAVEL, @AREA, @LOCAL, @EQUIPAMENTO, @COD_EQUIPAMENTO, @FABRICANTE, @MODELO, @DESCRICAO, @DATA_SOLICITACAO, @DATA_ATENDIMENTO)";


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
				cmd.ExecuteNonQuery();

				this.mensagem = "Solicitação salva com Sucesso!";
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
