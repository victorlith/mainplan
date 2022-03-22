using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Projeto_M.Class01
{
	class RegistrarCustosFinais
	{
		Conexao con = new Conexao();
		SQLiteCommand cmd = new SQLiteCommand();

		public String mensagem = "";

		public void DespesasFinais(string numeroNota, string quantidadeTransporte, string valorTransporte, string totalTransporte, string quantidadeCesta, string valorCesta, string totalCesta, 
			string quantidadeBonus, string valorBonus, string totalBonus, string quantidadeTreinamento, string valorTreinamento, string totalTreinamento, string subTotal)
		{
			try
			{
				cmd.Connection = con.conectar();

				cmd.CommandText = "INSERT INTO TABELA_CUSTOS_DESPESAS (numero_nota, q_transporte, v_transporte, t_transporte, q_cesta_basica, v_cesta_basica, t_cesta_basica, " +
					"q_bonus, v_bonus, t_bonus, q_treinamento, v_treinamento, t_treinamento, sub_total) VALUES (@numero_nota, @q_transporte, @v_transporte, @t_transporte, @q_cesta_basica, @v_cesta_basica, @t_cesta_basica, " +
					"@q_bonus, @v_bonus, @t_bonus, @q_treinamento, @v_treinamento, @t_treinamento, @sub_total)";

				cmd.Parameters.AddWithValue("@numero_nota", numeroNota);
				cmd.Parameters.AddWithValue("@q_transporte", quantidadeTransporte);
				cmd.Parameters.AddWithValue("@v_transporte", valorTransporte);
				cmd.Parameters.AddWithValue("@t_transporte", totalTransporte);
				cmd.Parameters.AddWithValue("@q_cesta_basica", quantidadeCesta);
				cmd.Parameters.AddWithValue("@v_cesta_basica", valorCesta);
				cmd.Parameters.AddWithValue("@t_cesta_basica", totalCesta);
				cmd.Parameters.AddWithValue("@q_bonus", quantidadeBonus);
				cmd.Parameters.AddWithValue("@v_bonus", valorBonus);
				cmd.Parameters.AddWithValue("@t_bonus", totalBonus);
				cmd.Parameters.AddWithValue("@q_treinamento", quantidadeTreinamento);
				cmd.Parameters.AddWithValue("@v_treinamento", valorTreinamento);
				cmd.Parameters.AddWithValue("@t_treinamento", totalTreinamento);
				cmd.Parameters.AddWithValue("@sub_total", subTotal);
				cmd.ExecuteNonQuery();
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

		public void ValoresEntrada(string numeroNota, string referenciaLucro, string totalLucro, string referenciaDespesas, string totalDespesas, string referenciaSaude, string totalSaude,
			string referenciaInfra, string totalInfra, string referenciaProlabore, string totalProlabore, string referenciaImposto, string totalImposto, string subTotal)
		{
			try
			{
				cmd.Connection = con.conectar();

				cmd.CommandText = "INSERT INTO TABELA_VALORES_ENTRADA (numero_nota, referencia_lucro, total_lucro, referencia_despesas, total_despesas, referencia_plano_saude, total_plano_saude, referencia_infraestrutura, total_infraestrutura, referencia_prolabore, total_prolabore, referencia_imposto, total_imposto, sub_total) " +
					"VALUES (@numero_nota, @referencia_lucro, @total_lucro, @referencia_despesas, @total_despesas, @referencia_plano_saude, @total_plano_saude, @referencia_infraestrutura, @total_infraestrutura, @referencia_prolabore, @total_prolabore, @referencia_imposto, @total_imposto, @sub_total)";

				cmd.Parameters.AddWithValue("@numero_nota", numeroNota);
				cmd.Parameters.AddWithValue("@referencia_lucro", referenciaLucro);
				cmd.Parameters.AddWithValue("@total_lucro", totalLucro);
				cmd.Parameters.AddWithValue("@referencia_despesas", referenciaDespesas);
				cmd.Parameters.AddWithValue("@total_despesas", totalDespesas);
				cmd.Parameters.AddWithValue("@referencia_plano_saude", referenciaSaude);
				cmd.Parameters.AddWithValue("@total_plano_saude", totalSaude);
				cmd.Parameters.AddWithValue("@referencia_infraestrutura", referenciaInfra);
				cmd.Parameters.AddWithValue("@total_infraestrutura", totalInfra);
				cmd.Parameters.AddWithValue("@referencia_prolabore", referenciaProlabore);
				cmd.Parameters.AddWithValue("@total_prolabore", totalProlabore);
				cmd.Parameters.AddWithValue("@referencia_imposto", referenciaImposto);
				cmd.Parameters.AddWithValue("@total_imposto", totalImposto);
				cmd.Parameters.AddWithValue("@sub_total", subTotal);
				cmd.ExecuteNonQuery();
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

		public void ResumoValores(string numeroNota, string subTotalDespesas, string subTotalEntrada, string subTotalMaoObra, string subTotalMaterial, 
			string subTotalContigencia, string totalEntrada, string totalCustosImposto, string TotalServico)
		{
			try
			{
				cmd.Connection = con.conectar();

				cmd.CommandText = "INSERT INTO TABELA_RESUMO_VALORES (numero_nota, sub_total_despesas, sub_total_valores_entrada, sub_total_mao_obra, sub_total_material, sub_total_contigencia, total_entrada, total_custos_imposto, total_servico) " +
					"VALUES (@numero_nota, @sub_total_despesas, @sub_total_valores_entrada, @sub_total_mao_obra, @sub_total_material, @sub_total_contigencia, @total_entrada, @total_custos_imposto, @total_servico)";

				cmd.Parameters.AddWithValue("@numero_nota", numeroNota);
				cmd.Parameters.AddWithValue("@sub_total_despesas", subTotalDespesas);
				cmd.Parameters.AddWithValue("@sub_total_valores_entrada", subTotalEntrada);
				cmd.Parameters.AddWithValue("@sub_total_mao_obra", subTotalMaoObra);
				cmd.Parameters.AddWithValue("@sub_total_material", subTotalMaterial);
				cmd.Parameters.AddWithValue("@sub_total_contigencia", subTotalContigencia);
				cmd.Parameters.AddWithValue("@total_entrada", totalEntrada);
				cmd.Parameters.AddWithValue("@total_custos_imposto", totalCustosImposto);
				cmd.Parameters.AddWithValue("@total_servico", TotalServico);
				cmd.ExecuteNonQuery();
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
