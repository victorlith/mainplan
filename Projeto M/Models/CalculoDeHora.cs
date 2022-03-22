using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_M.Class01
{
	class CalculoDeHora
	{
		BancoDatas bancoData;

		//Atributos
		private string[] HoraInicial, HoraFinal;

		private double hora1, minuto1, hora2, minuto2;

		private int totalDias;

		private double TotalHr;
		private double TotalNormal;
		private double Total50;
		private double Total100;

		private string ResultadoNormal = "0";
		private string ResultadoHora50 = "0";
		private string ResultadoHora100 = "0";

		private List<string> listaDatas = new List<string>();

		public string[] ResultadoHora(string dtInicial, string dtFinal, string horaInicial, string horaFinal, double tempoRefeicao)
		{
			bancoData = new BancoDatas();
			
			List<string> listaSabados = new List<string>();
			List<string> listaDomingos = new List<string>();
			List<string> listaDiasUteis = new List<string>();
			List<string> listaDiasTotais = new List<string>();

			string dataInicial, dataFinal, dataCompleta, diasUteis, sabado, domingo;

			int id_DataInicial, id_DataFinal, novo_ID;

			dataInicial = dtInicial;
			dataFinal = dtFinal;

			string[] dataIni = bancoData.ConsultaData(dataInicial);
			string[] dataFin = bancoData.ConsultaData(dataFinal);

			id_DataInicial = int.Parse(dataIni[0]);
			id_DataFinal = int.Parse(dataFin[0]);

			listaDatas.Add(dataIni[0]);

			for (int i = id_DataInicial; i < id_DataFinal; i++)
			{
				novo_ID = i + 1;
				listaDatas.Add(novo_ID.ToString());
			}

			TotalHoras(horaInicial, horaFinal);

			foreach (string id_data in listaDatas)
			{
				dataCompleta = id_data + " " + bancoData.ConsultaDiaSemana(id_data);

				string[] spl;

				spl = dataCompleta.Split(' ');

				if (spl[1] == "sábado")
				{
					int totalSabados;

					dataCompleta = id_data + " " + bancoData.ConsultaDiaSemana(id_data) + " Hora Extra 50%";

					sabado = dataCompleta;

					listaSabados.Add(sabado);

					totalSabados = listaSabados.Count();

					ResultadoHora50 = Hora50(totalSabados, tempoRefeicao);

				}
				else if (spl[1] == "domingo")
				{
					int totalDomingos;

					dataCompleta = id_data + " " + bancoData.ConsultaDiaSemana(id_data) + " Hora Extra 100%";

					domingo = dataCompleta;

					listaDomingos.Add(domingo);

					totalDomingos = listaDomingos.Count();

					ResultadoHora100 = Hora100(totalDomingos, tempoRefeicao);

				}
				else
				{
					int totalNormais;

					dataCompleta = id_data + " " + bancoData.ConsultaDiaSemana(id_data) + " Hora Normal";

					diasUteis = dataCompleta;

					listaDiasUteis.Add(diasUteis);

					totalNormais = listaDiasUteis.Count();

					ResultadoNormal = HorasNormais(totalNormais, tempoRefeicao);

				}
			}

			return new[] { ResultadoNormal, ResultadoHora50, ResultadoHora100, listaDatas.Count().ToString() };
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

		private string HorasNormais(int quantiNormais, double tempoRefeica)
		{

			totalDias = quantiNormais;

			TotalNormal = (totalDias * TotalHr) - (totalDias * tempoRefeica);

			return TotalNormal.ToString();
		}

		private string Hora50(int quanti50, double tempoRefeicao)
		{

			totalDias = quanti50;

			Total50 = (TotalHr * totalDias) - (totalDias * tempoRefeicao);

			return Total50.ToString();
		}

		private string Hora100(int quanti100, double tempoRefeicao)
		{
			totalDias = quanti100;

			Total100 = (TotalHr * totalDias) - (totalDias * tempoRefeicao);

			return Total100.ToString();
		}



		public int QuantidaDeDeDias()
		{
			int quantidade = listaDatas.Count();

			return quantidade; // Buscar Solução para o problema
		}


		public double SomaTempoRefeicao(double refeicao1, double refeicao2, double refeicao3, double refeicao4, double refeicao5)
		{
			return refeicao1 + refeicao2 + refeicao3 + refeicao4 + refeicao5;
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
