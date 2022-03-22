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
        double calculo1;

        public String mensagem = "";

        public void AdicionarValoresMaterial(string numeroNota, string numeroItem, double valorUnitario, double valorFrete)
        {
            try
            {
                cmd.Connection = con.Conectar();

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

                calculo1 = (totalMaterial * valorUnitario) + valorFrete;

                //--------------------------------------------------//

                //UPDATE DA TABELA MATERIAL COM OS NOVOS DADOS------//
                cmd.CommandText = "UPDATE TABELA_MATERIAL SET " +
                    "VALOR_UNITARIO = @VALOR_UNITARIO, SUBTOTAL_MATERIAL = @SUBTOTAL_MATERIAL, " +
                    "VALOR_FRETE = @VALOR_FRETE, VALOR_TOTAL = @VALOR_TOTAL WHERE N_NOTA_SERV = @NOTA AND N_ITEM_MATERIAL = @N_MATERIAL";

                cmd.Parameters.AddWithValue("@NOTA", numeroNota);
                cmd.Parameters.AddWithValue("@N_MATERIAL", numeroItem);
                cmd.Parameters.AddWithValue("@VALOR_UNITARIO", valorUnitario.ToString("F2"));
                cmd.Parameters.AddWithValue("@SUBTOTAL_MATERIAL", calculo1.ToString("F2"));
                cmd.Parameters.AddWithValue("@VALOR_FRETE", valorFrete.ToString("F2"));
                cmd.Parameters.AddWithValue("@VALOR_TOTAL", calculo1.ToString("F2"));
                cmd.ExecuteNonQuery();
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

        public void AtualizarValorItem(string IDnota, string IDitem)
        {
            try
            {
                double valorUnitario = 0;
                double valorFrete = 0;

                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_MATERIAL WHERE N_NOTA_SERV = @N_NOTA AND N_ITEM_MATERIAL = @MATERIAL";
                cmd.Parameters.AddWithValue("@N_NOTA", IDnota);
                cmd.Parameters.AddWithValue("@MATERIAL", IDitem);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {     
                    totalMaterial = Convert.ToDouble(dr["total_material"]);
                    valorUnitario = Convert.ToDouble(dr["valor_unitario"]);
                    valorFrete = Convert.ToDouble(dr["valor_frete"]);
                }
                dr.Close();

                //CALCULOS MATERIAL---------------------------------//

                calculo1 = (totalMaterial * valorUnitario) + valorFrete;

                //--------------------------------------------------//

                //UPDATE DA TABELA MATERIAL COM OS NOVOS DADOS------//
                cmd.CommandText = "UPDATE TABELA_MATERIAL SET " +
                    "VALOR_UNITARIO = @VALOR_UNITARIO, SUBTOTAL_MATERIAL = @SUBTOTAL_MATERIAL, " +
                    "VALOR_FRETE = @VALOR_FRETE, VALOR_TOTAL = @VALOR_TOTAL WHERE N_NOTA_SERV = @NOTA AND N_ITEM_MATERIAL = @N_MATERIAL";

                cmd.Parameters.AddWithValue("@NOTA", IDnota);
                cmd.Parameters.AddWithValue("@N_MATERIAL", IDitem);
                cmd.Parameters.AddWithValue("@VALOR_UNITARIO", valorUnitario.ToString("F2"));
                cmd.Parameters.AddWithValue("@SUBTOTAL_MATERIAL", calculo1.ToString("F2"));
                cmd.Parameters.AddWithValue("@VALOR_FRETE", valorFrete.ToString("F2"));
                cmd.Parameters.AddWithValue("@VALOR_TOTAL", calculo1.ToString("F2"));
                cmd.ExecuteNonQuery();
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
