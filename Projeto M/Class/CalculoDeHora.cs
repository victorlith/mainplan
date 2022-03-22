using System.Collections.Generic;
using System.Linq;

namespace Projeto_M
{
    public class CalculoDeHora
    {
        BancoDatas bancoData;

        //Atributos
        private string[] HoraInicial, HoraFinal;

        private double hora1, minuto1, hora2, minuto2;

        private double TotalHr;
        private double TotalDeHoras;
        private double horaRefeicao;

        private string ResultadoNormal = "0";
        private string ResultadoHora50 = "0";
        private string ResultadoHora100 = "0";

        private int totalDeDiasUteis;

        public string teste;

        private List<string> listaDatas = new List<string>();

        public string[] ResultadoHora(string dtInicial, string dtFinal, string horaInicial, string horaFinal, double tempoRefeicao)
        {
            bancoData = new BancoDatas();

            horaRefeicao = 1; //Variavel para a rotina de calculo da classe

            List<string> listaSabados = new List<string>();
            List<string> listaDomingos = new List<string>();
            List<string> listaDiasUteis = new List<string>();
            List<string> listaDiasTotais = new List<string>();

            string dataInicial, dataFinal, dataCompleta, diasUteis, sabado, domingo;

            //int id_DataInicial, id_DataFinal, novo_ID;

            //dataInicial = dtInicial;
            //dataFinal = dtFinal;

            //string[] dataIni = bancoData.ConsultaData(dataInicial);
            //string[] dataFin = bancoData.ConsultaData(dataFinal);

            //id_DataInicial = int.Parse(dataIni[0]);
            //id_DataFinal = int.Parse(dataFin[0]);

            //listaDatas.Add(dataIni[0]);

            //for (int i = id_DataInicial; i < id_DataFinal; i++)
            //{
            //    novo_ID = i + 1;
            //    listaDatas.Add(novo_ID.ToString());
            //}

            CalculoDosDias(dtInicial, dtFinal);

            TotalHoras(horaInicial, horaFinal);

            foreach (string id_data in listaDatas)
            {
                dataCompleta = id_data + " " + bancoData.ConsultaDiaSemana(id_data);

                string[] spl;

                spl = dataCompleta.Split(' ');

                if (spl[1] == "sábado")
                {
                    int totalSabados;
                    double totalhora50;

                    dataCompleta = id_data + " " + bancoData.ConsultaDiaSemana(id_data) + " Hora Extra 50%";

                    sabado = dataCompleta;

                    listaSabados.Add(sabado);

                    totalSabados = listaSabados.Count();

                    totalhora50 = (TotalHr - horaRefeicao) * totalSabados;

                    ResultadoHora50 = totalhora50.ToString("F2");

                }
                else if (spl[1] == "domingo")
                {
                    int totalDomingos;
                    double totalhora100;

                    dataCompleta = id_data + " " + bancoData.ConsultaDiaSemana(id_data) + " Hora Extra 100%";

                    domingo = dataCompleta;

                    listaDomingos.Add(domingo);

                    totalDomingos = listaDomingos.Count();

                    totalhora100 = (TotalHr - horaRefeicao) * totalDomingos;

                    ResultadoHora100 = totalhora100.ToString("F2");

                }
                else
                {
                    int totalNormais;

                    dataCompleta = id_data + " " + bancoData.ConsultaDiaSemana(id_data) + " Hora Normal";

                    diasUteis = dataCompleta;

                    listaDiasUteis.Add(diasUteis);

                    totalNormais = listaDiasUteis.Count();

                    totalDeDiasUteis = listaDiasUteis.Count();

                    ResultadoNormal = CalculoDeHorasNormais().ToString();

                }
            }

            return new[] { TotalHH(), ResultadoNormal, SomaHr50(), ResultadoHora100, listaDatas.Count().ToString(), Refeicao_x_TotalDeDias() };
        }

        private double TotalHoras(string horaInicio, string horaFinal)
        {
            HoraInicial = horaInicio.Split(':');
            HoraFinal = horaFinal.Split(':');

            hora1 = double.Parse(HoraInicial[0]);
            minuto1 = double.Parse(HoraInicial[1]);
            hora2 = double.Parse(HoraFinal[0]);
            minuto2 = double.Parse(HoraFinal[1]);

            TotalHr = (minuto2 / 60 + hora2) - (minuto1 / 60 + hora1);

            return TotalHr;
        }

        public int CalculoDosDias(string dtInicial, string dtFinal)
        {
            bancoData = new BancoDatas();

            int id_DataInicial, id_DataFinal, novo_ID, tempoResposta;

            string[] dataIni = bancoData.ConsultaData(dtInicial);
            string[] dataFin = bancoData.ConsultaData(dtFinal);

            id_DataInicial = int.Parse(dataIni[0]);
            id_DataFinal = int.Parse(dataFin[0]);

            listaDatas.Add(dataIni[0]);

            for (int i = id_DataInicial; i < id_DataFinal; i++)
            {
                novo_ID = i + 1;
                listaDatas.Add(novo_ID.ToString());
            }

            tempoResposta = listaDatas.Count();

            return tempoResposta;

        }

        //--------Nova Rotina-------------//

        private string TotalHH()
        {
            double totalDeDias = listaDatas.Count();
            double diasXhoras = totalDeDias * TotalHr;
            double refeicaoXtotaldias = totalDeDias * horaRefeicao;

            TotalDeHoras = diasXhoras - refeicaoXtotaldias;

            return TotalDeHoras.ToString("F2");

        }

        private string Refeicao_x_TotalDeDias()
        {
            return (listaDatas.Count() * horaRefeicao).ToString();
        }

        private string CalculoDeHorasNormais()
        {
            double HRnormais = (TotalHr - horaRefeicao);
            double totalNormais = 0;

            if (HRnormais > 8)
            {
               HRnormais = (TotalHr - horaRefeicao) - 0.5;
               totalNormais = HRnormais * totalDeDiasUteis;
            }
            else
            {
                HRnormais = (TotalHr - horaRefeicao);
                totalNormais = HRnormais * totalDeDiasUteis;
            }
                  
            return totalNormais.ToString("F2");
        }

        private string CalculoExtra50()
        {
            double totalHoraExtra50;
            double horaJornada = TotalHr - horaRefeicao;

            if ( horaJornada > 8.5)
            {
                //totalHoraExtra50 = (horaJornada - 0.5) * totalDeDiasUteis
                totalHoraExtra50 = 0.5 * totalDeDiasUteis;
                return totalHoraExtra50.ToString("F2");
            }
            else
            {
                totalHoraExtra50 = 0;
                return totalHoraExtra50.ToString();
            }
        }

        private string CalculoExtra100()
        {
            double totalHoraExtra100 = (double.Parse(TotalHH()) - double.Parse(CalculoDeHorasNormais())) * 2;
            return totalHoraExtra100.ToString("F2"); ;
        }

        public int QuantidaDeDeDias()
        {
            int quantidade = listaDatas.Count();

            return quantidade; // Buscar Solução para o problema
        }

        private string SomaHr50()
        {
            double somaHr50 = double.Parse(ResultadoHora50) + double.Parse(CalculoExtra50());
            return somaHr50.ToString("F2");
        }


        public double SomaTempoRefeicao(double refeicao1, double refeicao2, double refeicao3, double refeicao4, double refeicao5)
        {
            return refeicao1 + refeicao2 + refeicao3 + refeicao4 + refeicao5;
        }

        public double SomaTotalDeHoras(double totalH1, double totalH2, double totalH3, double totalH4, double totalH5)
        {
            return totalH1 + totalH2 + totalH3 + totalH4 + totalH5;
        }

        public double SomaHoraNormal(double tbHora1, double tbHora2, double tbHora3, double tbHora4, double tbHora5)
        {
            return tbHora1 + tbHora2 + tbHora3 + tbHora4 + tbHora5;
        }

        public double SomaHoraExtra50(double extra501, double extra502, double extra503, double extra504, double extra505)
        {
            return extra501 + extra502 + extra503 + extra504 + extra505;
        }

        public double SomaHoraExtra100(double extra1001, double extra1002, double extra1003, double extra1004, double extra1005)
        {
            return extra1001 + extra1002 + extra1003 + extra1004 + extra1005;
        }




    }
}
