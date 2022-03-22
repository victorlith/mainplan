using System;

namespace Projeto_M
{
    class CalculosCustosFinais
    {
        //Variaveis para calculo
        public double Referencia;
        public double TotalMaoDeObra;
        public double TotalMaterial;
        public double TotalContigencia;

        //Variaveis para calculo de despesas
        public double Quantidade;
        public double Valor;
        public double TotalTransporte;
        public double TotalPassagens;
        public double TotalDiaria;
        public double TotalHospedagem;
        public double TotalTranslado;

        //Variaveis para calcular valores de entrada
        public double TotalLucro;
        public double TotalProlabore;
        public double TotalRiscoSacado;
        public double TotalInfraestrutura;
        public double TotalImposto;
        public double TotalDespesasAdm;
        public double TotalBonus;

        //Calculo total serviço
        public double Ref1;
        public double Ref2;
        public double Ref3;
        public double Ref4;
        public double Ref5;
        public double Ref6;
        public double Ref7;
        public double TotalReferencia;
        public double TotalServico;
        public double Total;
        public double Porcentagem;

        public double CalculoValorReferencia()
        {
            return TotalServico * (Referencia / 100);
        }

        public double CalculoDespesas()
        {
            return Quantidade * Valor;
        }

        public double TotalCustosDespesas()
        {
            return TotalTransporte + TotalPassagens + TotalDiaria + TotalHospedagem + TotalTranslado + TotalMaoDeObra + TotalMaterial + TotalContigencia;
        }

        public double SomaDeReferencias()
        {
            TotalReferencia = (Ref1 + Ref2 + Ref3 + Ref4 + Ref5 + Ref6 + Ref7) / 100;
            return Math.Round(TotalReferencia, 4);
        }

        public double Resumo_TotalServico()
        {
            return TotalServico = TotalCustosDespesas() / (1 - SomaDeReferencias());
        }

        public double CalculoPercentual()
        {
            return Porcentagem = (Total / TotalServico) * 100;
        }

        public double Custo_Imposto()
        {
            return TotalCustosDespesas() + TotalImposto + TotalBonus;
        }

        public double TotalEntrada()
        {
            return TotalLucro + TotalProlabore + TotalRiscoSacado + TotalInfraestrutura + TotalDespesasAdm;
        }

        public double SomaDetalhamentoFinanceiro()
        {
            return TotalLucro + TotalProlabore + TotalRiscoSacado + TotalInfraestrutura + TotalImposto + TotalDespesasAdm + TotalBonus;
        }

    }
}
