using iTextSharp.text;
using iTextSharp.text.pdf;
using Projeto_M.Class01;
using System;
using System.Data.SQLite;
using System.IO;

namespace Projeto_M
{
    class GerarPDF
    {
        Conexao con = new Conexao();
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataReader dr;

        public String mensagem = "";

        public string Cotacao;
        public string NumeroNota;

        //Endereço
        public string Cep = "";
        public string Lorgradouro = "";
        public string NumeroEndereco = "";
        public string Complemento = "";
        public string Bairro = "";
        public string Cidade = "";
        public string Uf = "";


        //Informações Cliente
        public string RazaoSocial;
        public string Cnpj;
        public string NomeEmpresa;
        public string Telefone;
        public string Email;
        public string Solicitante_Area;

        //Dados Nota Servico
        public string Referencia;
        public string DataSolicitacao;
        public string Solicitacao;
        public string Descricao;
        public string CodEquipamento;
        public string Responsavel;
        public string Area;
        public string Equipamento;

        //Outras Informações
        public string CondicoesPagamento;
        public string ValidadeProposta;
        public string QuantidadeDias;
        public string ResumoProposta;

        //Valores
        public string ValorUnit;
        public string ValorTotal;

        //Detalhes da Propostas
        public string DescricaoDaCapa;
        public string ReferenciaPropostaTecninca;
        public string TextoPropostaTecninca;
        public string EspecializacaoDoSesvico;
        public string EscopoResponsabilidade;

        private string codCliente, dataNota;
        public string SiglaCliente;
        private string[] spl;

        public string NomeArquivo()
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_NOTA_SERVICO WHERE NUMERO_NOTA = '" + NumeroNota + "'";
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    codCliente = (string)dr["n_empresa"];
                    dataNota = (string)dr["n_data_soli"];
                    spl = dataNota.Split('/');
                }
                dr.Close();

            }
            catch (Exception ex)
            {

                this.mensagem = ex.Message;
            }
            finally
            {
                con.Desconectar();
            }

            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_CLIENTE WHERE COD_CLIENTE = '" + codCliente + "'";
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    SiglaCliente = (string)dr["sigla_empresa"];
                }
                dr.Close();

            }
            catch (Exception ex)
            {

                this.mensagem = ex.Message;
            }
            finally
            {
                con.Desconectar();
            }

            return string.Format("{0}", spl[2]) + NumeroNota + "_" + SiglaCliente;
        }

        public void CriarPDF()
        {
            try
            {
                string caminho = PastaDestino.PastaDaCotacao(NumeroNota);
                string documento = string.Format(ReferenciaPropostaTecninca);

                Document doc = new Document(PageSize.A4);
                doc.SetMargins(60, 60, 20, 20); // (ESQUERDA, DIREITA, CIMA, BAIXO)
                string destino = string.Format("{0}\\Cotação_{1}.pdf", caminho, NomeArquivo());
                //string destino = string.Format("{0}/{1}.pdf", caminho, documento);   

                PdfWriter.GetInstance(doc, new FileStream(destino, FileMode.Create));

                doc.Open();

                //Fontes de Texto
                BaseColor branco = new BaseColor(255, 255, 255);
                var calibre_12_Bold = FontFactory.GetFont(@"C:\Windows\Fonts\calibrib.ttf", 12);
                var calibre_12_Normal = FontFactory.GetFont(@"C:\Windows\Fonts\calibri.ttf", 12);
                var calibre_8_Bold = FontFactory.GetFont(@"C:\Windows\Fonts\calibrib.ttf", 8);
                var calibre_11_Bold = FontFactory.GetFont(@"C:\Windows\Fonts\calibrib.ttf", 11);
                var calibre_16_Bold = FontFactory.GetFont(@"C:\Windows\Fonts\calibrib.ttf", 16);
                var calibre_16_Bold_branca = FontFactory.GetFont(@"C:\Windows\Fonts\calibrib.ttf", 16, branco);
                var calibre_11_Normal = FontFactory.GetFont(@"C:\Windows\Fonts\calibri.ttf", 11);
                var calibre_24_bold = FontFactory.GetFont(@"C:\Windows\Fonts\calibrib.ttf", 24);

                //Configurações do Rodape
                var rodape = iTextSharp.text.Image.GetInstance("rodape-menplan.png");
                rodape.ScaleToFit(1000, 71);
                rodape.SetAbsolutePosition(0, 0);

                //imagens do cabecalho
                var logo = iTextSharp.text.Image.GetInstance("logo-mp.png");
                var imgSafeLife = iTextSharp.text.Image.GetInstance("img2_menplan.png");
                logo.ScaleToFit(190, 80);
                logo.SetAbsolutePosition(25, 765); //X, Y
                imgSafeLife.ScaleToFit(50, 50);
                imgSafeLife.SetAbsolutePosition(510, 750);

                //-----Capa - Pag.1 -----//
                doc.Add(logo);
                doc.Add(imgSafeLife);

                //Quebras de Linha
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));

                //Quebras de Linha
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));

                //Quebras de Linha
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));

                Paragraph propostaTecninca = new Paragraph("PROPOSTA TÉCNICA/COMERCIAL", calibre_24_bold);
                propostaTecninca.Alignment = Element.ALIGN_CENTER;
                doc.Add(propostaTecninca);

                //**
                Paragraph textoCapa = new Paragraph(DescricaoDaCapa, calibre_24_bold);
                textoCapa.Alignment = Element.ALIGN_CENTER;
                doc.Add(textoCapa);

                var logoEmpresa = iTextSharp.text.Image.GetInstance("heineken_logo.png");
                logoEmpresa.ScaleToFit(190, 71);
                logoEmpresa.SetAbsolutePosition(200, 310);
                //doc.Add(logoEmpresa);

                doc.Add(rodape);
                //------------------------------------------//

                //-----Pag.2-----//
                doc.NewPage();
                doc.Add(logo);
                doc.Add(imgSafeLife);

                doc.Add(new Paragraph(" ")); //Quebra de Linha
                doc.Add(new Paragraph(" ")); //Quebra de Linha
                doc.Add(new Paragraph(" ")); //Quebra de Linha
                doc.Add(new Paragraph(" ")); //Quebra de Linha
                doc.Add(new Paragraph(" ")); //Quebra de Linha

                DateTime dataAtual = DateTime.Now;
                string dateNow = dataAtual.ToString("dd" + " \"d\"e " + "MMMM" + " \"d\"e " + "yyyy");
                string ano = dataAtual.ToString("yyyy");

                PdfPTable pag2_table1 = new PdfPTable(2);
                pag2_table1.DefaultCell.BorderWidth = 0;
                pag2_table1.WidthPercentage = 100;

                //---> Tabela 1
                //Coluna 1
                Chunk pag2_ch1 = new Chunk("Alagoinhas, ", calibre_12_Bold);
                Chunk pag2_ch2 = new Chunk($"{dateNow}", calibre_12_Normal);
                Phrase pag2_ph1 = new Phrase();
                pag2_ph1.Add(pag2_ch1);
                pag2_ph1.Add(pag2_ch2);
                Paragraph pag2_pt1 = new Paragraph(pag2_ph1);

                PdfPCell pag2_cell1 = new PdfPCell(pag2_pt1);

                pag2_cell1.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                pag2_cell1.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                pag2_cell1.Border = 0;
                pag2_cell1.FixedHeight = 30;
                pag2_table1.AddCell(pag2_cell1);

                //Coluna 2
                Chunk pag2_ch3 = new Chunk("Orçamento Nº: ", calibre_12_Bold);
                Chunk pag2_ch4 = new Chunk($"{ano}{NumeroNota}", calibre_12_Normal);
                Phrase pag2_ph2 = new Phrase();
                pag2_ph2.Add(pag2_ch3);
                pag2_ph2.Add(pag2_ch4);
                Paragraph pag2_pt2 = new Paragraph(pag2_ph2);

                PdfPCell pag2_cell2 = new PdfPCell(pag2_pt2);
                pag2_cell2.HorizontalAlignment = PdfPCell.ALIGN_MIDDLE;
                pag2_cell2.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                pag2_cell2.Border = 0;
                pag2_table1.AddCell(pag2_cell2);

                doc.Add(pag2_table1);
                //--->

                //---> Tabela 2
                //Coluna 1
                PdfPTable pag2_table2 = new PdfPTable(2);
                pag2_table2.DefaultCell.BorderWidth = 0;
                pag2_table2.WidthPercentage = 100;

                Chunk pag2_ch5 = new Chunk("Cliente: ", calibre_12_Bold);
                Chunk pag2_ch6 = new Chunk($"{Solicitante_Area}", calibre_12_Normal);
                Phrase pag2_ph3 = new Phrase();
                pag2_ph3.Add(pag2_ch5);
                pag2_ph3.Add(pag2_ch6);
                Paragraph pag2_pt3 = new Paragraph(pag2_ph3);

                PdfPCell pag2_cell3 = new PdfPCell(new Phrase(pag2_pt3));

                pag2_cell3.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                pag2_cell3.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                pag2_cell3.Border = 0;
                pag2_table2.AddCell(pag2_cell3);

                //Coluna 2 
                Chunk pag2_ch7 = new Chunk("E-mail: ", calibre_12_Bold);
                Chunk pag2_ch8 = new Chunk($"{Email}", calibre_12_Normal);
                Phrase pag2_ph4 = new Phrase();
                pag2_ph4.Add(pag2_ch7);
                pag2_ph4.Add(pag2_ch8);
                Paragraph pag2_pt4 = new Paragraph(pag2_ph4);

                PdfPCell pag2_cell4 = new PdfPCell(new Phrase(pag2_pt4));

                pag2_cell4.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                pag2_cell4.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                pag2_cell4.Border = 0;
                pag2_table2.AddCell(pag2_cell4);

                doc.Add(pag2_table2);
                //--->

                Chunk pag2_ch9 = new Chunk("At.: ", calibre_12_Bold);
                Chunk pag2_ch10 = new Chunk($"{Solicitante_Area}", calibre_12_Normal);
                Phrase pag2_ph5 = new Phrase();
                pag2_ph5.Add(pag2_ch9);
                pag2_ph5.Add(pag2_ch10);

                Paragraph pag2_p1 = new Paragraph(pag2_ph5);
                pag2_p1.IndentationLeft = 2f;
                pag2_p1.SetLeading(0.3f, 2);
                doc.Add(pag2_p1);

                doc.Add(new Paragraph(" ")); //Quebra de Linha

                doc.Add(new Paragraph($"Ref.: {ReferenciaPropostaTecninca}", calibre_12_Bold));

                doc.Add(new Paragraph(" ")); //Quebra de Linha

                Paragraph tituloPag2 = new Paragraph("PROPOSTA TÉCNICA/COMERCIAL", calibre_12_Bold);
                tituloPag2.Alignment = Element.ALIGN_CENTER;
                doc.Add(tituloPag2);

                doc.Add(new Paragraph(" ")); //Quebra de Linha

                doc.Add(new Paragraph("Prezado(a) Senhor(a),", calibre_12_Normal));

                doc.Add(new Paragraph(" ")); //Quebra de Linha

                Chunk textBreak1 = new Chunk("Atendendo à solicitação, apresentamos a seguir a nossa proposta Técnica e comercial para o fornecimento de ", calibre_12_Normal);

                //**
                Chunk textBreak2 = new Chunk($"{TextoPropostaTecninca}.", calibre_12_Bold);
                //Chunk textBreak3 = new Chunk(" de acordo com cronograma do cliente na Cervejaria Heineken Alagoinhas - BA.", calibre_12_Normal);

                Phrase textUnion = new Phrase();
                textUnion.Add(textBreak1);
                textUnion.Add(textBreak2);
                //textUnion.Add(textBreak3);

                Paragraph textFormat = new Paragraph(textUnion);
                textFormat.Alignment = Element.ALIGN_JUSTIFIED;
                doc.Add(textFormat);

                doc.Add(new Paragraph(" ")); //Quebra de Linha
                doc.Add(new Paragraph(" ")); //Quebra de Linha
                doc.Add(new Paragraph(" ")); //Quebra de Linha

                doc.Add(new Paragraph("Para esclarecimento de eventuais dúvidas ou informações adicionais, estamos à disposição.", calibre_12_Normal));

                doc.Add(new Paragraph(" ")); // Quebra de Linha

                doc.Add(new Paragraph("Atenciosamene, ", calibre_12_Normal));

                doc.Add(new Paragraph(" ")); // Quebra de Linha
                doc.Add(new Paragraph(" ")); // Quebra de Linha

                var dados_Gerente = iTextSharp.text.Image.GetInstance("dados_gerente.png");
                dados_Gerente.ScaleToFit(800, 80);
                dados_Gerente.SetAbsolutePosition(95, 250); //<---------Continuar...
                doc.Add(dados_Gerente);

                doc.Add(rodape);
                //------------------------------------------//

                //-----Pag.3-----//
                doc.NewPage();
                doc.Add(logo);
                doc.Add(imgSafeLife);

                doc.Add(new Paragraph(" ")); //Quebra de Linha
                doc.Add(new Paragraph(" ")); //Quebra de Linha
                doc.Add(new Paragraph(" ")); //Quebra de Linha
                doc.Add(new Paragraph(" ")); //Quebra de Linha
                doc.Add(new Paragraph(" ")); //Quebra de Linha

                doc.Add(new Paragraph("ÍNDICE", calibre_12_Bold));
                doc.Add(new Paragraph("1 - APRESENTAÇÃO", calibre_12_Bold));
                doc.Add(new Paragraph("2 - PROPOSTA COMERCIAL", calibre_12_Bold));
                doc.Add(new Paragraph("3 - ESCOPO DOS SERVIÇOS E RESPONSABILIDADES", calibre_12_Bold));
                doc.Add(new Paragraph("4 - CONDIÇÕES GERAIS DA PRESTAÇÃO DE SERVIÇOS", calibre_12_Bold));
                doc.Add(new Paragraph("5 - PRAZO DE ENTREGA", calibre_12_Bold));
                doc.Add(new Paragraph("6 - CONDIÇÕES DE PAGAMENTO E ENCARGOS/FATURAMENTO", calibre_12_Bold));
                doc.Add(new Paragraph("7 - CONFIABILIDADE E PROPRIEDADE INTELECTUAL", calibre_12_Bold));
                doc.Add(new Paragraph("8 - VALIDADE DA PROPOSTA", calibre_12_Bold));

                doc.Add(rodape);
                //------------------------------------------//

                //-----Pag.4-----//
                doc.NewPage();
                doc.Add(logo);
                doc.Add(imgSafeLife);

                doc.Add(new Paragraph(" ")); //Quebra Linha
                doc.Add(new Paragraph(" ")); //Quebra Linha
                doc.Add(new Paragraph(" ")); //Quebra Linha
                doc.Add(new Paragraph(" ")); //Quebra Linha
                doc.Add(new Paragraph(" ")); //Quebra Linha

                doc.Add(new Paragraph("1 - APRESENTAÇÃO", calibre_12_Bold));
                Paragraph pag3_p1 = new Paragraph("Fundada em 2019, a Menplan Industrial Services disponibiliza ao mercado uma " +
                    "experiência de mais de 20 anos no desenvolvimento e implantação de modelos de Gestão de Manutenção, com aplicações e resultados em empresas do segmento de bebidas. " +
                    "Composta por um corpo de gestão, engenharia e técnicos especialistas em manutenção industrial nas tecnologias mecânica, elétrica, automação e instrumentação a empresa " +
                    "se posiciona como uma alternativa viável e confiável no setor.", calibre_11_Normal);
                pag3_p1.Alignment = Element.ALIGN_JUSTIFIED;
                doc.Add(pag3_p1);

                doc.Add(new Paragraph(" ")); //Quebra Linha
                doc.Add(new Paragraph(" ")); //Quebra Linha

                doc.Add(new Paragraph("MISSÃO:", calibre_12_Bold));
                Paragraph pag3_p2 = new Paragraph("Entregar alto nível de serviço de manutenção industrial apoiados numa metodologia de ponta a ponta participando de forma efetiva desde o " +
                    "levantamento de necessidades, execução das atividades, bem como a revisão dos planos preventivos que sustentem a manutenção das condições básicas através de pessoas " +
                    "qualificadas, experientes e especializadas contribuindo na melhoria contínua da " +
                    "eficiência e confiabilidade em processos.", calibre_11_Normal);
                pag3_p2.Alignment = Element.ALIGN_JUSTIFIED;
                doc.Add(pag3_p2);

                doc.Add(new Paragraph(" ")); //Quebra Linha
                doc.Add(new Paragraph(" ")); //Quebra Linha   

                doc.Add(new Paragraph("VISÃO:", calibre_12_Bold));
                Paragraph pag3_p3 = new Paragraph("Ser referência em manutenção industrial E2E (desde o planejamento até o feedback da execução das atividades) na " +
                    "indústria de bebidas, alimentos e embalagens no Brasil.", calibre_11_Normal);
                pag3_p3.Alignment = Element.ALIGN_JUSTIFIED;
                doc.Add(pag3_p3);

                doc.Add(new Paragraph(" ")); //Quebra Linha
                doc.Add(new Paragraph(" ")); //Quebra Linha 

                doc.Add(new Paragraph("VALORES:", calibre_12_Bold));

                Chunk marc1_1 = new Chunk("• Segurança", calibre_11_Bold);
                Chunk marc1_2 = new Chunk(" - Para a Vida.", calibre_11_Normal);
                Phrase marcador1 = new Phrase();
                marcador1.Add(marc1_1);
                marcador1.Add(marc1_2);
                marcador1.SetLeading(0.3f, 2);
                //doc.Add(new Paragraph(marcador1));
                Paragraph p_marcador1 = new Paragraph(marcador1);
                p_marcador1.IndentationLeft = 15f;
                doc.Add(p_marcador1);

                Chunk marc2_1 = new Chunk("• Pessoas", calibre_11_Bold);
                Chunk marc2_2 = new Chunk(" - Certas no lugar certo e apixonadas pelo que fazem.", calibre_11_Normal);
                Phrase marcador2 = new Phrase();
                marcador2.Add(marc2_1);
                marcador2.Add(marc2_2);
                marcador2.SetLeading(0.3f, 2);
                //doc.Add(new Paragraph(marcador2));
                Paragraph p_marcador2 = new Paragraph(marcador2);
                p_marcador2.IndentationLeft = 15f;
                doc.Add(p_marcador2);

                Chunk marc3_1 = new Chunk("• Credibilidade", calibre_11_Bold);
                Chunk marc3_2 = new Chunk(" - Construir relações de confinça, e duradouras.", calibre_11_Normal);
                Phrase marcador3 = new Phrase();
                marcador3.Add(marc3_1);
                marcador3.Add(marc3_2);
                marcador3.SetLeading(0.3f, 2);
                //doc.Add(new Paragraph(marcador3));
                Paragraph p_marcador3 = new Paragraph(marcador3);
                p_marcador3.IndentationLeft = 15f;
                doc.Add(p_marcador3);

                Chunk marc4_1 = new Chunk("• Foco do Cliente", calibre_11_Bold);
                Chunk marc4_2 = new Chunk(" - Alto nível de serviço com qualidade e senso de dono.", calibre_11_Normal);
                Phrase marcador4 = new Phrase();
                marcador4.Add(marc4_1);
                marcador4.Add(marc4_2);
                marcador4.SetLeading(0.4f, 2);
                //doc.Add(new Paragraph(marcador4));
                Paragraph p_marcador4 = new Paragraph(marcador4);
                p_marcador4.IndentationLeft = 15f;
                doc.Add(p_marcador4);


                Chunk marc5_1 = new Chunk("• Método", calibre_11_Bold);
                Chunk marc5_2 = new Chunk(" - Para restabelecimento e manutencção das condições básicas.", calibre_11_Normal);
                Phrase marcador5 = new Phrase();
                marcador5.Add(marc5_1);
                marcador5.Add(marc5_2);
                marcador5.SetLeading(0.3f, 2);
                //doc.Add(new Paragraph(marcador5));
                Paragraph p_marcador5 = new Paragraph(marcador5);
                p_marcador5.IndentationLeft = 15f;
                doc.Add(p_marcador5);

                doc.Add(rodape);
                //------------------------------------------//

                //-----Pag.5-----//
                doc.NewPage();
                doc.Add(logo);
                doc.Add(imgSafeLife);

                doc.Add(new Paragraph(" ")); //Quebra Linha
                doc.Add(new Paragraph(" ")); //Quebra Linha
                doc.Add(new Paragraph(" ")); //Quebra Linha
                doc.Add(new Paragraph(" ")); //Quebra Linha
                doc.Add(new Paragraph(" ")); //Quebra Linha

                doc.Add(new Paragraph("SERVIÇOS:", calibre_12_Bold));
                //doc.Add(new Paragraph("• Levantamento de necessidades, planejamento e execução de overhaul em linhas de envasamento;", calibre_11_Normal));
                //doc.Add(new Paragraph("• Serviço especializado em máquinas de envase (enchedoras, arrolhadores, recravadoras, lavadoras de garrafas, rotuladoras, embaladoras, despaletizadores e paletizadores);", calibre_11_Normal));
                //doc.Add(new Paragraph("• MGS – Machine Godfather Service (Padrinho de máquinas)", calibre_11_Normal));
                //doc.Add(new Paragraph("• Manutenção preventiva, corretiva, retrofits, relocações e reparos em máquinas e subconjuntos;", calibre_11_Normal));
                //doc.Add(new Paragraph("• Diagnóstico e suporte dos processos de PCM/Almoxarifado de peças;", calibre_11_Normal));
                //doc.Add(new Paragraph("• Elaboração e/ou revisão de Planos de inspeção, lubrificação e manutenção preventiva;", calibre_11_Normal));
                //doc.Add(new Paragraph("• Supervisão e fiscalização de montagens mecânicas, elétrica, instrumentação e automação – projetos;", calibre_11_Normal));
                //doc.Add(new Paragraph("• FAT (Factory acceptance Test) Teste de aceitação em fornecedores – projetos.", calibre_11_Normal));

                Paragraph pag5_p1 = new Paragraph("• Levantamento de necessidades, planejamento e execução de overhaul em linhas de envasamento;\n" +
                    "• Serviço especializado em máquinas de envase (enchedoras, arrolhadores, recravadoras, lavadoras de garrafas, rotuladoras, embaladoras, despaletizadores e paletizadores);\n" +
                    "• MGS – Machine Godfather Service (Padrinho de máquinas)\n" +
                    "• Manutenção preventiva, corretiva, retrofits, relocações e reparos em máquinas e subconjuntos;\n" +
                    "• Diagnóstico e suporte dos processos de PCM/Almoxarifado de peças;\n" +
                    "• Elaboração e/ou revisão de Planos de inspeção, lubrificação e manutenção preventiva;\n" +
                    "• Supervisão e fiscalização de montagens mecânicas, elétrica, instrumentação e automação – projetos;\n" +
                    "• FAT (Factory acceptance Test) Teste de aceitação em fornecedores – projetos.", calibre_11_Normal);
                pag5_p1.IndentationLeft = 15f;
                pag5_p1.SetLeading(0.3f, 2);
                doc.Add(pag5_p1);

                doc.Add(rodape);
                //------------------------------------------//

                //-----Pagina do Orçamento - Pag.6-----//
                doc.NewPage();
                doc.Add(logo);
                doc.Add(imgSafeLife);

                string dataProposta = DateTime.Now.ToString("dd/MM/yyyy");
                string[] splData;
                splData = dataProposta.Split(' ');

                //Quebras de Linha
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));

                Paragraph confidencial = new Paragraph("CONFIDENCIAL", calibre_12_Normal);
                confidencial.Alignment = Element.ALIGN_RIGHT;
                doc.Add(confidencial);

                Paragraph propostaComercial = new Paragraph("2 - PROPOSTA COMERCIAL", calibre_12_Bold);
                propostaComercial.Alignment = Element.ALIGN_LEFT;
                doc.Add(propostaComercial);

                doc.Add(new Paragraph(" ")); //Quebra de Linhaa
                //Tabela - 1
                //
                PdfPTable tabela1 = new PdfPTable(2);
                PdfPCell cell1Tab1 = new PdfPCell(new Phrase("MENPLAN SERVIÇOS INDUSTRIAIS LTDA 12.115.710/0001-46 RUA PAULO AFONSO, 1245 KENNEDY CEP: 48020 - 650 ALAGOINHAS - BA", calibre_8_Bold));
                PdfPCell cell2Tab1 = new PdfPCell(new Phrase($"COTAÇÃO {Cotacao}", calibre_16_Bold_branca));

                tabela1.WidthPercentage = 100;
                tabela1.TotalWidth = 412f;
                float[] tab1Largura = new float[] { 150f, 150f };
                tabela1.SetWidths(tab1Largura);

                cell1Tab1.HorizontalAlignment = Element.ALIGN_CENTER;
                cell1Tab1.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2Tab1.HorizontalAlignment = Element.ALIGN_LEFT;
                cell2Tab1.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2Tab1.BackgroundColor = new BaseColor(25, 50, 100);

                tabela1.AddCell(cell1Tab1);
                tabela1.AddCell(cell2Tab1);
                doc.Add(tabela1);

                //Tabela - 2
                //
                Chunk c1Tab2 = new Chunk("CLIENTE: ", calibre_12_Bold);
                Chunk c2Tab2;

                if (string.IsNullOrEmpty(RazaoSocial))
                {
                    c2Tab2 = new Chunk($"{NomeEmpresa}", calibre_12_Normal);
                }
                else
                {
                    c2Tab2 = new Chunk($"{RazaoSocial}\nENDEREÇO: {Lorgradouro}, {Bairro} - {Complemento}\nCEP: {Cep}\nCIDADE: {Cidade}-{Uf.ToUpper()}\nCPF/CNPJ: {Cnpj}", calibre_12_Normal);
                }

                Chunk c3Tab2 = new Chunk("REFERÊNCIA: ", calibre_12_Bold);
                Chunk c4Tab2 = new Chunk($"{Referencia}\n", calibre_12_Normal);

                Chunk c5Tab2 = new Chunk("DATA: ", calibre_12_Bold);
                Chunk c6Tab2 = new Chunk($"{splData[0]}\n", calibre_12_Normal);

                Chunk c7Tab2 = new Chunk("SOLICITAÇÃO: ", calibre_12_Bold);
                Chunk c8Tab2 = new Chunk($"{Solicitacao}\n", calibre_12_Normal);

                Chunk c9Tab2 = new Chunk("CÓDIGO FORNECEDOR: ", calibre_12_Bold);
                Chunk c10Tab2 = new Chunk($"{CodEquipamento}\n", calibre_12_Normal);

                Chunk c11Tab2 = new Chunk("RESPONSÁVEL MENPLAN: ", calibre_12_Bold);
                Chunk c12Tab2 = new Chunk($"{Responsavel}\n", calibre_12_Normal);

                Chunk c13Tab2 = new Chunk("ÁREA: ", calibre_12_Bold);
                Chunk c14Tab2 = new Chunk($"{Area}\n", calibre_12_Normal);

                Chunk c15Tab2 = new Chunk("SOLICITANTE/ÁREA: ", calibre_12_Bold);
                Chunk c16Tab2 = new Chunk($"{Solicitante_Area.ToUpper()}\n", calibre_12_Normal);

                Phrase phc1Tab2 = new Phrase();
                phc1Tab2.Add(c1Tab2);
                phc1Tab2.Add(c2Tab2);

                Phrase phcTab2 = new Phrase();
                phcTab2.Add(c3Tab2);
                phcTab2.Add(c4Tab2);
                phcTab2.Add(c5Tab2);
                phcTab2.Add(c6Tab2);
                phcTab2.Add(c7Tab2);
                phcTab2.Add(c8Tab2);
                phcTab2.Add(c9Tab2);
                phcTab2.Add(c10Tab2);
                phcTab2.Add(c11Tab2);
                phcTab2.Add(c12Tab2);
                phcTab2.Add(c13Tab2);
                phcTab2.Add(c14Tab2);
                phcTab2.Add(c15Tab2);
                phcTab2.Add(c16Tab2);

                PdfPTable tabela2 = new PdfPTable(2);
                PdfPCell cell1Tab2 = new PdfPCell(new Phrase(phc1Tab2));
                PdfPCell cell2Tab2 = new PdfPCell(new Phrase(phcTab2));

                tabela2.WidthPercentage = 100;
                tabela2.TotalWidth = 412f;
                float[] tab2Largura = new float[] { 150f, 150f };
                tabela2.SetWidths(tab2Largura);

                cell1Tab2.HorizontalAlignment = Element.ALIGN_LEFT;
                cell2Tab2.HorizontalAlignment = Element.ALIGN_LEFT;

                tabela2.AddCell(cell1Tab2);
                tabela2.AddCell(cell2Tab2);
                doc.Add(tabela2);

                doc.Add(new Paragraph(" ")); //Quebra de Linha
                doc.Add(new Paragraph(" "));

                //Tabela - 3
                //
                Chunk c1Tab3 = new Chunk("CONTATO DO CLIENTE: \n", calibre_12_Bold);
                Chunk c2Tab3 = new Chunk($"{Solicitante_Area.ToUpper()}\n", calibre_12_Normal);

                Chunk c3Tab3 = new Chunk("\n"); //Quebra de Linha

                Chunk c4Tab3 = new Chunk("TELEFONE: \n", calibre_12_Bold);
                Chunk c5Tab3 = new Chunk($"{Telefone}\n", calibre_12_Normal);

                Phrase prTab3 = new Phrase();
                prTab3.Add(c1Tab3);
                prTab3.Add(c2Tab3);
                prTab3.Add(c3Tab3);
                prTab3.Add(c4Tab3);
                prTab3.Add(c5Tab3);

                PdfPTable tabela3 = new PdfPTable(1);
                PdfPCell cell1Tab3 = new PdfPCell(prTab3);

                tabela3.WidthPercentage = 100;

                tabela3.AddCell(cell1Tab3);
                doc.Add(tabela3);

                doc.Add(new Paragraph(" ")); //Quebra de Linha

                //Tabela - 4
                //
                PdfPTable tabela4 = new PdfPTable(1);
                PdfPCell cell1Tab4 = new PdfPCell(new Phrase("CONDIÇÕES DE PAGAMENTO: ", calibre_12_Bold));

                tabela4.WidthPercentage = 100;
                tabela4.AddCell(cell1Tab4);
                doc.Add(tabela4);

                doc.Add(new Phrase($"{CondicoesPagamento} DIAS APÓS LANÇAMENTO DA NOTA FISCAL", calibre_12_Normal));

                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));

                //Tabela - 5
                //
                PdfPTable tabela5 = new PdfPTable(1);
                PdfPCell cell1Tab5 = new PdfPCell(new Phrase("RESUMO DA PROPOSTA:", calibre_12_Bold));

                tabela5.WidthPercentage = 100;
                cell1Tab5.VerticalAlignment = Element.ALIGN_MIDDLE;
                tabela5.AddCell(cell1Tab5);
                doc.Add(tabela5);

                //

                Paragraph resumoProposta = new Paragraph($"COTAÇÃO {TextoPropostaTecninca}", calibre_12_Normal);
                resumoProposta.Alignment = Element.ALIGN_JUSTIFIED;
                doc.Add(resumoProposta);

                doc.Add(new Phrase(""));

                //Tabela - 6
                //
                PdfPTable tabela6 = new PdfPTable(1);
                PdfPCell cell1Tab6 = new PdfPCell(new Phrase("VALOR DA PROPOSTA", calibre_11_Bold));

                tabela6.WidthPercentage = 100;
                cell1Tab6.HorizontalAlignment = Element.ALIGN_CENTER;
                tabela6.AddCell(cell1Tab6);
                doc.Add(tabela6);

                doc.Add(new Phrase(""));

                //Tabela - 7
                //
                double quantidade, valorUnitario, totalServico;
                quantidade = double.Parse(QuantidadeDias);
                valorUnitario = double.Parse(ValorUnit);
                totalServico = quantidade * valorUnitario;

                PdfPTable tabela7 = new PdfPTable(5);
                PdfPCell cell1Tab7 = new PdfPCell(new Phrase("DESCRIÇÃO DO SERVIÇO", calibre_11_Bold));
                PdfPCell cell2Tab7 = new PdfPCell(new Phrase("QTD", calibre_11_Bold));
                PdfPCell cell3Tab7 = new PdfPCell(new Phrase("PERÍODO", calibre_11_Bold));
                PdfPCell cell4Tab7 = new PdfPCell(new Phrase("VALOR UNIT.", calibre_11_Bold));
                PdfPCell cell5Tab7 = new PdfPCell(new Phrase("VALOR TOTAL", calibre_11_Bold));
                PdfPCell cell6Tab7 = new PdfPCell(new Phrase($"{TextoPropostaTecninca.ToUpper()}", calibre_11_Normal));
                PdfPCell cell7Tab7 = new PdfPCell(new Phrase($"{QuantidadeDias}", calibre_11_Normal)); //Valor deverear ser inserido pelo usuario
                PdfPCell cell8Tab7 = new PdfPCell(new Phrase($"-", calibre_11_Normal)); //Campo Periodo
                PdfPCell cell9Tab7 = new PdfPCell(new Phrase(double.Parse(ValorUnit).ToString("c"), calibre_11_Bold));
                PdfPCell cell10Tab7 = new PdfPCell(new Phrase(totalServico.ToString("c"), calibre_11_Bold));


                tabela7.WidthPercentage = 100;
                tabela7.TotalWidth = 412f;
                float[] tab7Largura = new float[] { 60f, 10f, 15f, 20f, 25f };
                tabela7.SetWidths(tab7Largura);

                cell6Tab7.HorizontalAlignment = Element.ALIGN_MIDDLE;

                cell1Tab7.HorizontalAlignment = 1;
                cell2Tab7.HorizontalAlignment = 1;
                cell3Tab7.HorizontalAlignment = 1;
                cell4Tab7.HorizontalAlignment = 1;
                cell5Tab7.HorizontalAlignment = 1;
                cell6Tab7.HorizontalAlignment = 1;
                cell7Tab7.HorizontalAlignment = 1;
                cell8Tab7.HorizontalAlignment = 1;
                cell9Tab7.HorizontalAlignment = 1;
                cell10Tab7.HorizontalAlignment = 1;

                cell1Tab7.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2Tab7.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell3Tab7.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell4Tab7.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell5Tab7.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell6Tab7.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell7Tab7.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell8Tab7.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell9Tab7.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell10Tab7.VerticalAlignment = Element.ALIGN_MIDDLE;

                tabela7.AddCell(cell1Tab7);
                tabela7.AddCell(cell2Tab7);
                tabela7.AddCell(cell3Tab7);
                tabela7.AddCell(cell4Tab7);
                tabela7.AddCell(cell5Tab7);
                tabela7.AddCell(cell6Tab7);
                tabela7.AddCell(cell7Tab7);
                tabela7.AddCell(cell8Tab7);
                tabela7.AddCell(cell9Tab7);
                tabela7.AddCell(cell10Tab7);
                doc.Add(tabela7);

                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));

                //---

                //Chunk p1 = new Chunk("VALIDADE DA PROPOSTA:\n", calibre_11_Bold);
                //Chunk p2 = new Chunk($"{ValidadeProposta} DIAS A PARTIR DA PRESENTE DATA " + splData[0], calibre_11_Normal);

                //Phrase validadeProposta = new Phrase();
                //validadeProposta.Add(p1);
                //validadeProposta.Add(p2);

                //Paragraph proposta = new Paragraph(validadeProposta);

                //proposta.Alignment = Element.ALIGN_LEFT;

                //doc.Add(proposta);

                doc.Add(rodape);
                //------------------------------------------//

                //-----Pag.7------//
                doc.NewPage();
                doc.Add(logo);
                doc.Add(imgSafeLife);

                doc.Add(new Paragraph(" ")); //Quebra de Linha
                doc.Add(new Paragraph(" ")); //Quebra de Linha
                doc.Add(new Paragraph(" ")); //Quebra de Linha
                doc.Add(new Paragraph(" ")); //Quebra de Linha
                doc.Add(new Paragraph(" ")); //Quebra de Linha

                doc.Add(new Paragraph("3 - ESCOPO DOS SERVIÇOS E RESPONSABILIDADES", calibre_12_Bold));

                Paragraph pag7_p1 = new Paragraph($"Esta proposta apresenta valores e condições comerciais para a prestação de serviço especializado em {EspecializacaoDoSesvico}:", calibre_11_Normal);
                pag7_p1.Alignment = Element.ALIGN_JUSTIFIED;
                doc.Add(pag7_p1);

                doc.Add(new Paragraph(" ")); //Quebra de Linha               

                Paragraph pag7_p2 = new Paragraph($"Escopo: Prestação de serviço especializado em {EspecializacaoDoSesvico} de acordo com a programação e prioridades do cliente.", calibre_11_Bold);
                pag7_p2.Alignment = Element.ALIGN_JUSTIFIED;
                doc.Add(pag7_p2);

                doc.Add(new Paragraph(" ")); //Quebra de Linha 

                Paragraph pag7_p3 = new Paragraph("Escopo e Responsabilidade da MENPLAN INDUSTRIAL SERVICES:", calibre_11_Bold);
                //pag7_p3.Alignment = Element.ALIGN_JUSTIFIED;
                doc.Add(pag7_p3);

                doc.Add(new Paragraph(" "));

                Paragraph pag7_p5 = new Paragraph($"• {EscopoResponsabilidade}", calibre_11_Normal);
                pag7_p5.Alignment = Element.ALIGN_JUSTIFIED;
                pag7_p5.IndentationLeft = 15f;
                pag7_p5.SetLeading(0.3f, 2);
                doc.Add(pag7_p5);

                Paragraph pag7_p6 = new Paragraph($"• Executar todo o serviço descrito dentro dos melhores padrões de qualidade existente e conhecido;\n" +
                    $"• Efetuar o transporte externo de todo o pessoal;\n" +
                    $"• Fornecer todas as ferramentas manuais necessárias para a execução dos serviços.\n" +
                    $"• Efetuar limpeza do local e retirar todos os materiais excedentes e ou desativados em qualquer serviço executado;\n" +
                    $"• Obedecer às normas e procedimentos de segurança interna do Cliente", calibre_11_Normal);
                pag7_p6.IndentationLeft = 15f;
                pag7_p6.SetLeading(0.3f, 2);
                doc.Add(pag7_p6);

                doc.Add(new Paragraph(" ")); //Quebra de Linha              

                doc.Add(new Paragraph($"Escopo e Responsabilidades do Cliente:", calibre_11_Bold));

                Paragraph pag7_p7 = new Paragraph($"Fazem parte do escopo e são obrigações da Cliente os itens abaixo indicados:\n" +
                    $"• Fornecer crachás de identificação Cliente conforme norma interna para acesso a fábrica;\n" +
                    $"• Fornecer normas e padrões Cliente.\n" +
                    $"• Informar previamente à MENPLAN as necessidades de documentações necessárias à integração de segurança\n" +
                    $"• Fornecer peças de reposição para as atividades programadas bem como insumos para limpeza.\n", calibre_11_Normal);
                pag7_p7.IndentationLeft = 15f;
                pag7_p7.SetLeading(0.3f, 2);
                doc.Add(pag7_p7);

                doc.Add(rodape);
                //------------------------------------------//

                //-----Pag.8-----//
                doc.NewPage();
                doc.Add(logo);
                doc.Add(imgSafeLife);

                doc.Add(new Paragraph(" ")); //Quebra de Linha
                doc.Add(new Paragraph(" ")); //Quebra de Linha
                doc.Add(new Paragraph(" ")); //Quebra de Linha
                doc.Add(new Paragraph(" ")); //Quebra de Linha
                doc.Add(new Paragraph(" ")); //Quebra de Linha

                doc.Add(new Paragraph("4 - CONDIÇÕES GERAIS DA PRESTAÇÃO DE SERVIÇOS", calibre_11_Bold));
                Paragraph pag8_p0 = new Paragraph("4.1 Ferramentas de trabalho", calibre_11_Bold);
                pag8_p0.IndentationLeft = 15f;
                doc.Add(pag8_p0);

                Paragraph pag8_p1 = new Paragraph("Os técnicos estarão acompanhados por equipamentos e ferramentas compatíveis com a necessidade das tarefas a serem executadas. " +
                    "Caso haja a necessidade de algum equipamento/ferramenta específico ou de uso comum, o Cliente o providenciará.", calibre_11_Normal);
                pag8_p1.Alignment = Element.ALIGN_JUSTIFIED;
                pag8_p1.IndentationLeft = 15f;
                doc.Add(pag8_p1);

                doc.Add(new Paragraph(" ")); //Quebra Linha

                Paragraph pag8_p2 = new Paragraph("4.2 Equipamentos de Proteção Individual (EPI’s) ", calibre_11_Bold);
                pag8_p2.IndentationLeft = 15f;
                doc.Add(pag8_p2);

                Paragraph pag8_p3 = new Paragraph("Os especialistas estarão acompanhados de todos equipamentos de proteção individual adequados aos riscos, conforme capitulo V do título II da CLT e portaria 3214/78 do Mtb.", calibre_11_Normal);
                pag8_p3.Alignment = Element.ALIGN_JUSTIFIED;
                pag8_p3.IndentationLeft = 15f;
                doc.Add(pag8_p3);

                doc.Add(new Paragraph(" ")); //Quebra de Linha

                doc.Add(new Paragraph("5 - PRAZO DE ENTREGA", calibre_11_Bold));
                doc.Add(new Paragraph("De acordo com o cronograma acima e datas estabelecidas pelo cliente.", calibre_11_Normal));

                doc.Add(new Paragraph(" ")); //Quebra de Linha

                doc.Add(new Paragraph("6 - CONDIÇÕES DE PAGAMENTO E ENCARGOS/FATURAMENTO", calibre_11_Bold));
                Paragraph pag8_p4 = new Paragraph($"• 100% - {CondicoesPagamento} após conclusão do serviço de cada parada conforme cronograma de execução.\n" +
                    "• Conforme legislação vigente, qualquer criação/alteração de tributos que direta ou indiretamente reflita    nos preços será repassada ao cliente em sua respectiva proporção.", calibre_11_Normal);
                pag8_p4.Alignment = Element.ALIGN_JUSTIFIED;
                pag8_p4.IndentationLeft = 15f;
                doc.Add(pag8_p4);

                doc.Add(new Paragraph(" ")); //Quebra de Linha

                doc.Add(new Paragraph("7 - CONFIDENCIALIDADE E PRIORIDADE INTELECTUAL", calibre_11_Bold));
                Paragraph pag8_p5 = new Paragraph("Todas as informações comerciais e técnicas (desenhos, resultados de medições, experimentos, propostas, preços, etc.) trocadas entre as Partes deverão ser utilizadas exclusivamente para os " +
                    "propósitos da presente oferta, não podendo ser divulgada a terceiros, direta ou indiretamente, oralmente ou por escrito ou por qualquer outro meio. A Parte que fornecer tais informações permanecerá titular " +
                    "de todos os seus direitos (incluindo direito de autor e o direito de pleitear proteção a direitos de propriedade industrial, como, por exemplo, " +
                    "depositar patentes de invenção, modelos de utilidade, etc.).", calibre_11_Normal);
                pag8_p5.Alignment = Element.ALIGN_JUSTIFIED;
                doc.Add(pag8_p5);

                doc.Add(new Paragraph(" ")); //Quebra Linha

                doc.Add(new Paragraph("8 - VALIDADE DA PROPOSTA", calibre_11_Bold));
                doc.Add(new Paragraph($"{ValidadeProposta} DIAS A PARTIR DA PRESENTE DATA " + splData[0], calibre_11_Normal));

                doc.Add(rodape);
                //------------------------------------------//

                doc.Close();
                System.Diagnostics.Process.Start(destino);

            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
            }
        }
    }
}
