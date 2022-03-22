using System;
using System.Data.SQLite;

namespace Projeto_M.Class01
{
    class RegistrarCustosFinais
    {
        Conexao con = new Conexao();
        SQLiteCommand cmd = new SQLiteCommand();

        public String mensagem = "";

        public void CustosAndDespesas(string numeroNota, string quantidadeTransporte, string valorTransporte, string totalTransporte, string quantidadePassagens, string valorPassagens, string totalPassagens,
            string quantiadeDiaria, string valorDiaria, string totalDiaria, string quantidadeHospedagem, string valorHospedagem, string totalHospedagem, string quantidadeTranslado, string valorTranslado, string totalTranslado, string subTotal)
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "INSERT INTO TABELA_CUSTOS_DESPESAS " +
                    "(numero_nota, " +
                    "q_transporte, " +
                    "v_transporte, " +
                    "t_transporte, " +
                    "q_passagens, " +
                    "v_passagens, " +
                    "t_passagens, " +
                    "q_diaria, " +
                    "v_diaria, " +
                    "t_diaria, " +
                    "q_hospedagem, " +
                    "v_hospedagem, " +
                    "t_hospedagem, " +
                    "q_translado, " +
                    "v_translado, " +
                    "t_translado, " +
                    "total) " +
                    "VALUES (@numero_nota," +
                    "@q_transporte, " +
                    "@v_transporte, " +
                    "@t_transporte, " +
                    "@q_passagens, " +
                    "@v_passagens, " +
                    "@t_passagens, " +
                    "@q_diaria, " +
                    "@v_diaria, " +
                    "@t_diaria, " +
                    "@q_hospedagem, " +
                    "@v_hospedagem, " +
                    "@t_hospedagem, " +
                    "@q_translado, " +
                    "@v_translado, " +
                    "@t_translado, " +
                    "@sub_total)";

                cmd.Parameters.AddWithValue("@numero_nota", numeroNota);
                cmd.Parameters.AddWithValue("@q_transporte", quantidadeTransporte);
                cmd.Parameters.AddWithValue("@v_transporte", valorTransporte);
                cmd.Parameters.AddWithValue("@t_transporte", totalTransporte);
                cmd.Parameters.AddWithValue("@q_passagens", quantidadePassagens);
                cmd.Parameters.AddWithValue("@v_passagens", valorPassagens);
                cmd.Parameters.AddWithValue("@t_passagens", totalPassagens);
                cmd.Parameters.AddWithValue("@q_diaria", quantiadeDiaria);
                cmd.Parameters.AddWithValue("@v_diaria", valorDiaria);
                cmd.Parameters.AddWithValue("@t_diaria", totalDiaria);
                cmd.Parameters.AddWithValue("@q_hospedagem", quantidadeHospedagem);
                cmd.Parameters.AddWithValue("@v_hospedagem", valorHospedagem);
                cmd.Parameters.AddWithValue("@t_hospedagem", totalHospedagem);
                cmd.Parameters.AddWithValue("@q_translado", quantidadeTranslado);
                cmd.Parameters.AddWithValue("@v_translado", valorTranslado);
                cmd.Parameters.AddWithValue("@t_translado", totalTranslado);
                cmd.Parameters.AddWithValue("@sub_total", subTotal);
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

        public void DetalhamentoFinanceiro(string numeroNota, string ref_lucro, string total_lucro, string ref_prolab, string total_prolab,
            string ref_rs, string total_rs, string ref_infra, string total_infra, string ref_imp, string total_imp, string ref_adm, string total_adm,
            string ref_bonus, string total_bonus, string ref_total, string total)
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "INSERT INTO TABELA_VALORES_ENTRADA" +
                    " (numero_nota, " +
                    "referencia_lucro, " +
                    "total_lucro, " +
                    "referencia_prolabore," +
                    "total_prolabore, " +
                    "referencia_risco_sacado, " +
                    "total_risco_sacado, " +
                    "referencia_infraestrutura, " +
                    "total_infraestrutura, " +
                    "referencia_imposto, " +
                    "total_imposto, " +
                    "referencia_despesas_adm, " +
                    "total_despesas_adm, " +
                    "referencia_bonus," +
                    "total_bonus, " +
                    "referencia_total," +
                    "total) " +
                    "VALUES (@numero_nota, " +
                    "@ref_lucro, " +
                    "@total_lucro, " +
                    "@ref_prolab, " +
                    "@total_prolab, " +
                    "@ref_risco_sacado, " +
                    "@total_risco_sacado, " +
                    "@ref_infra, " +
                    "@total_infra, " +
                    "@ref_imp, " +
                    "@total_imp, " +
                    "@ref_adm, " +
                    "@total_adm, " +
                    "@ref_bonus, " +
                    "@total_bonus, " +
                    "@ref_total, " +
                    "@total)";

                cmd.Parameters.AddWithValue("@numro_nota", numeroNota);
                cmd.Parameters.AddWithValue("@ref_lucro", ref_lucro);
                cmd.Parameters.AddWithValue("@total_lucro", total_lucro);
                cmd.Parameters.AddWithValue("@ref_prolab", ref_prolab);
                cmd.Parameters.AddWithValue("@total_prolab", total_prolab);
                cmd.Parameters.AddWithValue("@ref_risco_sacado", ref_rs);
                cmd.Parameters.AddWithValue("@total_risco_sacado", total_rs);
                cmd.Parameters.AddWithValue("@ref_infra", ref_infra);
                cmd.Parameters.AddWithValue("@total_infra", total_infra);
                cmd.Parameters.AddWithValue("@ref_imp", ref_imp);
                cmd.Parameters.AddWithValue("@total_imp", total_imp);
                cmd.Parameters.AddWithValue("@ref_adm", ref_adm);
                cmd.Parameters.AddWithValue("@total_adm", total_adm);
                cmd.Parameters.AddWithValue("@ref_bonus", ref_bonus);
                cmd.Parameters.AddWithValue("@total_bonus", total_bonus);
                cmd.Parameters.AddWithValue("@ref_total", ref_total);
                cmd.Parameters.AddWithValue("@total", total);
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

        public void ResumoValores(string numeroNota, string subTotalDespesas, string total_referencia, string totalValoresEntrada, string TotalServico, string totalEntrada, string totalCustosImposto)
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "INSERT INTO TABELA_RESUMO_VALORES (numero_nota, " +
                    "total_despesas, " +
                    "total_referencia, " +
                    "total_valores_entrada, " +
                    "total_servico, " +
                    "total_entrada, " +
                    "total_custos_imposto) " +
                    "VALUES (@numero_nota, " +
                    "@total_despesas, " +
                    "@total_referencia, " +
                    "@total_valores_entrada, " +
                    "@total_servico, " +
                    "@total_entrada, " +
                    "@total_custos_imposto)";

                cmd.Parameters.AddWithValue("@numero_nota", numeroNota);
                cmd.Parameters.AddWithValue("@total_despesas", subTotalDespesas);
                cmd.Parameters.AddWithValue("@total_referencia", total_referencia);
                cmd.Parameters.AddWithValue("@total_valores_entrada", totalValoresEntrada);
                cmd.Parameters.AddWithValue("@total_servico", TotalServico);
                cmd.Parameters.AddWithValue("@total_entrada", totalEntrada);
                cmd.Parameters.AddWithValue("@total_custos_imposto", totalCustosImposto);
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
