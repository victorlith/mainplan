using System;
using System.Data.SQLite;

namespace Projeto_M.Class01
{
	class AdicionarItemMaterial
	{
		Conexao con = new Conexao();
		SQLiteCommand cmd = new SQLiteCommand();
		SQLiteDataReader dr;

		double totalMaterial;
		double calculo1, calculo2, calculo3, calculo4, calculo5;

		double mod1, mod2, mod3, mod4, mod5;

		public String mensagem = "";

		public void AdicionarValoresMaterial(string numeroNota, string numeroItem, double valorUnitario, double valorFrete, double icms, double ipi, double variacaoPreco)
		{
			try
			{
				cmd.Connection = con.conectar();

				cmd.CommandText = "SELECT * FROM TABELA_MATERIAL WHERE N_NOTA_SERV = @N_NOTA AND N_ITEM_MATERIAL = @MATERIAL";
				cmd.Parameters.AddWithValue("@N_NOTA", numeroNota);
				cmd.Parameters.AddWithValue("@MATERIAL", numeroItem);
				dr = cmd.ExecuteReader();

				while (dr.Read())
				{
					totalMaterial = Convert.ToDouble(dr["total_material"]);
				}
				dr.Close();

				//CALCULOS MATERIAL---------------------------------//

				calculo1 = totalMaterial * valorUnitario;
				calculo2 = calculo1 * icms / 100;
				calculo3 = calculo1 * ipi / 100;
				calculo4 = calculo1 * variacaoPreco / 100;
				calculo5 = calculo1 + calculo2 + calculo3 + calculo4 + valorFrete;

				//--------------------------------------------------//

				//UPDATE DA TABELA MATERIAL COM OS NOVOS DADOS------//
				cmd.CommandText = "UPDATE TABELA_MATERIAL SET " +
					"VALOR_UNITARIO = @VALOR_UNITARIO, SUBTOTAL_MATERIAL = @SUBTOTAL_MATERIAL, " +
					"VALOR_FRETE = @VALOR_FRETE, ICMS = @ICMS, TOTAL_ICMS = @TOTAL_ICMS, IPI = @IPI, TOTAL_IPI = @TOTAL_IPI, VARIACAO_PRECO = @VARIACAO_PRECO, " +
					"TOTAL_VARIACAO = @TOTAL_VARIACAO, VALOR_TOTAL = @VALOR_TOTAL WHERE N_NOTA_SERV = @NOTA AND N_ITEM_MATERIAL = @N_MATERIAL";

				cmd.Parameters.AddWithValue("@NOTA", numeroNota);
				cmd.Parameters.AddWithValue("@N_MATERIAL", numeroItem);
				cmd.Parameters.AddWithValue("@VALOR_UNITARIO", valorUnitario.ToString("F2"));
				cmd.Parameters.AddWithValue("@SUBTOTAL_MATERIAL", calculo1.ToString("F2"));
				cmd.Parameters.AddWithValue("@VALOR_FRETE", valorFrete.ToString("F2"));
				cmd.Parameters.AddWithValue("@ICMS", icms.ToString("F2"));
				cmd.Parameters.AddWithValue("@TOTAL_ICMS", calculo2.ToString("F2"));
				cmd.Parameters.AddWithValue("@IPI", ipi.ToString("F2"));
				cmd.Parameters.AddWithValue("@TOTAL_IPI", calculo3.ToString("F2"));
				cmd.Parameters.AddWithValue("@VARIACAO_PRECO", variacaoPreco.ToString("F2"));
				cmd.Parameters.AddWithValue("@TOTAL_VARIACAO", calculo4.ToString("F2"));
				cmd.Parameters.AddWithValue("@VALOR_TOTAL", calculo5.ToString("F2"));
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

		public void AdicionarValorUnitario(int numeroItem, double valorUnitario)
		{
			try
			{
				cmd.Connection = con.conectar();

				cmd.CommandText = "SELECT * FROM TABELA_MATERIAL WHERE N_ITEM_MATERIAL = @MATERIAL";
				cmd.Parameters.AddWithValue("@MATERIAL", numeroItem);
				dr = cmd.ExecuteReader();

				while (dr.Read())
				{
					totalMaterial = Convert.ToDouble(dr["total_material"]);

					//mod1 = Convert.ToDouble(dr["valor_unitario"]);
					mod1 = Convert.ToDouble(dr["valor_frete"]);
					mod2 = Convert.ToDouble(dr["icms"]);
					mod3 = Convert.ToDouble(dr["ipi"]);
					mod4 = Convert.ToDouble(dr["variacao_preco"]);
				}
				dr.Close();

				//CALCULOS MATERIAL---------------------------------//

				calculo1 = totalMaterial * valorUnitario;
				calculo2 = calculo1 * mod2 / 100;
				calculo3 = calculo1 * mod3 / 100;
				calculo4 = calculo1 * mod4 / 100;
				calculo5 = calculo1 + calculo2 + calculo3 + calculo4;

				//--------------------------------------------------//

				//UPDATE DA TABELA MATERIAL COM OS NOVOS DADOS------//
				cmd.CommandText = "UPDATE TABELA_MATERIAL SET " +
					"VALOR_UNITARIO = @VALOR_UNITARIO, SUBTOTAL_MATERIAL = @SUBTOTAL_MATERIAL, " +
					"VALOR_FRETE = @VALOR_FRETE, ICMS = @ICMS, TOTAL_ICMS = @TOTAL_ICMS, IPI = @IPI, TOTAL_IPI = @TOTAL_IPI, VARIACAO_PRECO = @VARIACAO_PRECO, " +
					"TOTAL_VARIACAO = @TOTAL_VARIACAO, VALOR_TOTAL = @VALOR_TOTAL WHERE N_ITEM_MATERIAL = @N_MATERIAL";

				cmd.Parameters.AddWithValue("@N_MATERIAL", numeroItem);
				cmd.Parameters.AddWithValue("@VALOR_UNITARIO", valorUnitario.ToString("F2"));
				cmd.Parameters.AddWithValue("@SUBTOTAL_MATERIAL", calculo1.ToString("F2"));
				cmd.Parameters.AddWithValue("@VALOR_FRETE", mod1.ToString("F2"));
				cmd.Parameters.AddWithValue("@ICMS", mod2.ToString("F2"));
				cmd.Parameters.AddWithValue("@TOTAL_ICMS", calculo2.ToString("F2"));
				cmd.Parameters.AddWithValue("@IPI", mod3.ToString("F2"));
				cmd.Parameters.AddWithValue("@TOTAL_IPI", calculo3.ToString("F2"));
				cmd.Parameters.AddWithValue("@VARIACAO_PRECO", mod4.ToString("F2"));
				cmd.Parameters.AddWithValue("@TOTAL_VARIACAO", calculo4.ToString("F2"));
				cmd.Parameters.AddWithValue("@VALOR_TOTAL", calculo5.ToString("F2"));
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

		public void AdicionarValorFrete(int numeroItem, double valorFrete)
		{
			try
			{
				cmd.Connection = con.conectar();

				cmd.CommandText = "SELECT * FROM TABELA_MATERIAL WHERE N_ITEM_MATERIAL = @MATERIAL";
				cmd.Parameters.AddWithValue("@MATERIAL", numeroItem);
				dr = cmd.ExecuteReader();

				while (dr.Read())
				{
					totalMaterial = Convert.ToDouble(dr["total_material"]);

					mod1 = Convert.ToDouble(dr["valor_unitario"]);
					mod2 = Convert.ToDouble(dr["icms"]);
					mod3 = Convert.ToDouble(dr["ipi"]);
					mod4 = Convert.ToDouble(dr["variacao_preco"]);
				}
				dr.Close();

				//CALCULOS MATERIAL---------------------------------//

				calculo1 = totalMaterial * mod1;
				calculo2 = calculo1 * mod2 / 100;
				calculo3 = calculo1 * mod3 / 100;
				calculo4 = calculo1 * mod4 / 100;
				calculo5 = calculo1 + calculo2 + calculo3 + calculo4;

				//--------------------------------------------------//

				//UPDATE DA TABELA MATERIAL COM OS NOVOS DADOS------//
				cmd.CommandText = "UPDATE TABELA_MATERIAL SET " +
					"VALOR_UNITARIO = @VALOR_UNITARIO, SUBTOTAL_MATERIAL = @SUBTOTAL_MATERIAL, " +
					"VALOR_FRETE = @VALOR_FRETE, ICMS = @ICMS, TOTAL_ICMS = @TOTAL_ICMS, IPI = @IPI, TOTAL_IPI = @TOTAL_IPI, VARIACAO_PRECO = @VARIACAO_PRECO, " +
					"TOTAL_VARIACAO = @TOTAL_VARIACAO, VALOR_TOTAL = @VALOR_TOTAL WHERE N_ITEM_MATERIAL = @N_MATERIAL";

				cmd.Parameters.AddWithValue("@N_MATERIAL", numeroItem);
				cmd.Parameters.AddWithValue("@VALOR_UNITARIO", mod1.ToString("F2"));
				cmd.Parameters.AddWithValue("@SUBTOTAL_MATERIAL", calculo1.ToString("F2"));
				cmd.Parameters.AddWithValue("@VALOR_FRETE", valorFrete.ToString("F2"));
				cmd.Parameters.AddWithValue("@ICMS", mod2.ToString("F2"));
				cmd.Parameters.AddWithValue("@TOTAL_ICMS", calculo2.ToString("F2"));
				cmd.Parameters.AddWithValue("@IPI", mod3.ToString("F2"));
				cmd.Parameters.AddWithValue("@TOTAL_IPI", calculo3.ToString("F2"));
				cmd.Parameters.AddWithValue("@VARIACAO_PRECO", mod4.ToString("F2"));
				cmd.Parameters.AddWithValue("@TOTAL_VARIACAO", calculo4.ToString("F2"));
				cmd.Parameters.AddWithValue("@VALOR_TOTAL", calculo5.ToString("F2"));
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

		public void AdicionarICMS(int numeroItem, double icms)
		{
			try
			{
				cmd.Connection = con.conectar();

				cmd.CommandText = "SELECT * FROM TABELA_MATERIAL WHERE N_ITEM_MATERIAL = @MATERIAL";
				cmd.Parameters.AddWithValue("@MATERIAL", numeroItem);
				dr = cmd.ExecuteReader();

				while (dr.Read())
				{
					totalMaterial = Convert.ToDouble(dr["total_material"]);

					mod1 = Convert.ToDouble(dr["valor_unitario"]);
					mod2 = Convert.ToDouble(dr["valor_frete"]);
					//mod3 = Convert.ToDouble(dr["icms"]);
					mod4 = Convert.ToDouble(dr["ipi"]);
					mod5 = Convert.ToDouble(dr["variacao_preco"]);
				}
				dr.Close();

				//CALCULOS MATERIAL---------------------------------//

				calculo1 = totalMaterial * mod1; //Valor Unitario
				calculo2 = calculo1 * icms / 100; //ICMS
				calculo3 = calculo1 * mod4 / 100; //IPI
				calculo4 = calculo1 * mod5 / 100; //Variação Preço
				calculo5 = calculo1 + calculo2 + calculo3 + calculo4; //Valor Total

				//--------------------------------------------------//

				//UPDATE DA TABELA MATERIAL COM OS NOVOS DADOS------//
				cmd.CommandText = "UPDATE TABELA_MATERIAL SET " +
					"VALOR_UNITARIO = @VALOR_UNITARIO, SUBTOTAL_MATERIAL = @SUBTOTAL_MATERIAL, " +
					"VALOR_FRETE = @VALOR_FRETE, ICMS = @ICMS, TOTAL_ICMS = @TOTAL_ICMS, IPI = @IPI, TOTAL_IPI = @TOTAL_IPI, VARIACAO_PRECO = @VARIACAO_PRECO, " +
					"TOTAL_VARIACAO = @TOTAL_VARIACAO, VALOR_TOTAL = @VALOR_TOTAL WHERE N_ITEM_MATERIAL = @N_MATERIAL";

				cmd.Parameters.AddWithValue("@N_MATERIAL", numeroItem);
				cmd.Parameters.AddWithValue("@VALOR_UNITARIO", mod1.ToString("F2"));
				cmd.Parameters.AddWithValue("@SUBTOTAL_MATERIAL", calculo1.ToString("F2"));
				cmd.Parameters.AddWithValue("@VALOR_FRETE", mod2.ToString("F2"));
				cmd.Parameters.AddWithValue("@ICMS", icms.ToString("F2"));
				cmd.Parameters.AddWithValue("@TOTAL_ICMS", calculo2.ToString("F2"));
				cmd.Parameters.AddWithValue("@IPI", mod4.ToString("F2"));
				cmd.Parameters.AddWithValue("@TOTAL_IPI", calculo3.ToString("F2"));
				cmd.Parameters.AddWithValue("@VARIACAO_PRECO", mod5.ToString("F2"));
				cmd.Parameters.AddWithValue("@TOTAL_VARIACAO", calculo4.ToString("F2"));
				cmd.Parameters.AddWithValue("@VALOR_TOTAL", calculo5.ToString("F2"));
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

		public void AdicionarIPI(int numeroItem, double ipi)
		{
			try
			{
				cmd.Connection = con.conectar();

				cmd.CommandText = "SELECT * FROM TABELA_MATERIAL WHERE N_ITEM_MATERIAL = @MATERIAL";
				cmd.Parameters.AddWithValue("@MATERIAL", numeroItem);
				dr = cmd.ExecuteReader();

				while (dr.Read())
				{
					totalMaterial = Convert.ToDouble(dr["total_material"]);

					mod1 = Convert.ToDouble(dr["valor_unitario"]);
					mod2 = Convert.ToDouble(dr["valor_frete"]);
					mod3 = Convert.ToDouble(dr["icms"]);
					//mod4 = Convert.ToDouble(dr["ipi"]);
					mod5 = Convert.ToDouble(dr["variacao_preco"]);
				}
				dr.Close();

				//CALCULOS MATERIAL---------------------------------//

				calculo1 = totalMaterial * mod1; //Valor Unitario
				calculo2 = calculo1 * mod3 / 100; //ICMS
				calculo3 = calculo1 * ipi / 100; //IPI
				calculo4 = calculo1 * mod5 / 100; //Variação Preço
				calculo5 = calculo1 + calculo2 + calculo3 + calculo4; //Valor Total

				//--------------------------------------------------//

				//UPDATE DA TABELA MATERIAL COM OS NOVOS DADOS------//
				cmd.CommandText = "UPDATE TABELA_MATERIAL SET " +
					"VALOR_UNITARIO = @VALOR_UNITARIO, SUBTOTAL_MATERIAL = @SUBTOTAL_MATERIAL, " +
					"VALOR_FRETE = @VALOR_FRETE, ICMS = @ICMS, TOTAL_ICMS = @TOTAL_ICMS, IPI = @IPI, TOTAL_IPI = @TOTAL_IPI, VARIACAO_PRECO = @VARIACAO_PRECO, " +
					"TOTAL_VARIACAO = @TOTAL_VARIACAO, VALOR_TOTAL = @VALOR_TOTAL WHERE N_ITEM_MATERIAL = @N_MATERIAL";

				cmd.Parameters.AddWithValue("@N_MATERIAL", numeroItem);
				cmd.Parameters.AddWithValue("@VALOR_UNITARIO", mod1.ToString("F2"));
				cmd.Parameters.AddWithValue("@SUBTOTAL_MATERIAL", calculo1.ToString("F2"));
				cmd.Parameters.AddWithValue("@VALOR_FRETE", mod2.ToString("F2"));
				cmd.Parameters.AddWithValue("@ICMS", mod3.ToString("F2"));
				cmd.Parameters.AddWithValue("@TOTAL_ICMS", calculo2.ToString("F2"));
				cmd.Parameters.AddWithValue("@IPI", ipi.ToString("F2"));
				cmd.Parameters.AddWithValue("@TOTAL_IPI", calculo3.ToString("F2"));
				cmd.Parameters.AddWithValue("@VARIACAO_PRECO", mod5.ToString("F2"));
				cmd.Parameters.AddWithValue("@TOTAL_VARIACAO", calculo4.ToString("F2"));
				cmd.Parameters.AddWithValue("@VALOR_TOTAL", calculo5.ToString("F2"));
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

		public void AdicionarVariacaoPreco(int numeroItem, double variacaoPreco)
		{
			try
			{
				cmd.Connection = con.conectar();

				cmd.CommandText = "SELECT * FROM TABELA_MATERIAL WHERE N_ITEM_MATERIAL = @MATERIAL";
				cmd.Parameters.AddWithValue("@MATERIAL", numeroItem);
				dr = cmd.ExecuteReader();

				while (dr.Read())
				{
					totalMaterial = Convert.ToDouble(dr["total_material"]);

					mod1 = Convert.ToDouble(dr["valor_unitario"]);
					mod2 = Convert.ToDouble(dr["valor_frete"]);
					mod3 = Convert.ToDouble(dr["icms"]);
					mod4 = Convert.ToDouble(dr["ipi"]);
					//mod5 = Convert.ToDouble(dr["variacao_preco"]);
				}
				dr.Close();

				//CALCULOS MATERIAL---------------------------------//

				calculo1 = totalMaterial * mod1; //Valor Unitario
				calculo2 = calculo1 * mod3 / 100; //ICMS
				calculo3 = calculo1 * mod4 / 100; //IPI
				calculo4 = calculo1 * variacaoPreco / 100; //Variação Preço
				calculo5 = calculo1 + calculo2 + calculo3 + calculo4; //Valor Total

				//--------------------------------------------------//

				//UPDATE DA TABELA MATERIAL COM OS NOVOS DADOS------//
				cmd.CommandText = "UPDATE TABELA_MATERIAL SET " +
					"VALOR_UNITARIO = @VALOR_UNITARIO, SUBTOTAL_MATERIAL = @SUBTOTAL_MATERIAL, " +
					"VALOR_FRETE = @VALOR_FRETE, ICMS = @ICMS, TOTAL_ICMS = @TOTAL_ICMS, IPI = @IPI, TOTAL_IPI = @TOTAL_IPI, VARIACAO_PRECO = @VARIACAO_PRECO, " +
					"TOTAL_VARIACAO = @TOTAL_VARIACAO, VALOR_TOTAL = @VALOR_TOTAL WHERE N_ITEM_MATERIAL = @N_MATERIAL";

				cmd.Parameters.AddWithValue("@N_MATERIAL", numeroItem);
				cmd.Parameters.AddWithValue("@VALOR_UNITARIO", mod1.ToString("F2"));
				cmd.Parameters.AddWithValue("@SUBTOTAL_MATERIAL", calculo1.ToString("F2"));
				cmd.Parameters.AddWithValue("@VALOR_FRETE", mod2.ToString("F2"));
				cmd.Parameters.AddWithValue("@ICMS", mod3.ToString("F2"));
				cmd.Parameters.AddWithValue("@TOTAL_ICMS", calculo2.ToString("F2"));
				cmd.Parameters.AddWithValue("@IPI", mod4.ToString("F2"));
				cmd.Parameters.AddWithValue("@TOTAL_IPI", calculo3.ToString("F2"));
				cmd.Parameters.AddWithValue("@VARIACAO_PRECO", variacaoPreco.ToString("F2"));
				cmd.Parameters.AddWithValue("@TOTAL_VARIACAO", calculo4.ToString("F2"));
				cmd.Parameters.AddWithValue("@VALOR_TOTAL", calculo5.ToString("F2"));
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
