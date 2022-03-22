using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data.SQLite;
using Projeto_M.Class01;
using System.Collections.Generic;

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
        public string Cep;
        public string Lorgradouro;
        public string NumeroEndereco;
        public string Complemento;
        public string Bairro;
        public string Cidade;
        public string Uf;

        //Informações Cliente
        public string RazaoSocial;
        public string Cnpj;
        public string NomeEmpresa;
        public string Telefone;
        public string Email;
        public string Solicitante_Area;

        //Dados Nota Servico
        public string DataSolicitacao;
        public string Solicitacao;
        public string Descricao;
        public string CodEquipamento;
        public string Responsavel;
        public string Area;
        public string Equipamento;

        //Outras Informações
        public string CodicoesPagamento;
        public string ValidadeProposta;
        public string QuantidadeDias;
        public string Periodo;
        public string ResumoProposta;

        //Valores
        public string ValorUnit;
        public string ValorTotal;

        private string codCliente, dataNota;
        private string sigla;
        private string[] spl;

        public string CriarPasta()
        {
            try
            {
                cmd.Connection = con.conectar();

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
                con.desconectar();
            }

            try
            {
                cmd.Connection = con.conectar();

                cmd.CommandText = "SELECT * FROM TABELA_CLIENTE WHERE COD_CLIENTE = '" + codCliente + "'";
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    sigla = (string)dr["sigla_empresa"];
                }
                dr.Close();
            }
            catch (Exception ex)
            {

                this.mensagem = ex.Message;
            }
            finally
            {
                con.desconectar();
            }
            
            return string.Format("{0}", spl[2]) + NumeroNota + "_" + sigla;
        }

        public void CriarPDF()
        {
            try
            {
                string caminho = PastaDestino.PastaNota(NumeroNota);

                Document doc = new Document(PageSize.A4);
                doc.SetMargins(60, 60, 20, 20); // (ESQUERDA, DIREITA, CIMA, BAIXO)
                string destino = string.Format("{0}/{1} - Relatório.pdf", caminho, CriarPasta());
                //string destino = @"C:\Users\Victor\Desktop\" + "relatorio.pdf";

                PdfWriter.GetInstance(doc, new FileStream(destino, FileMode.Create));

                doc.Open();

                var logo = iTextSharp.text.Image.GetInstance("logo-mp.png");
                var imgSafeLife = iTextSharp.text.Image.GetInstance("img2_menplan.png");

                logo.ScaleToFit(190, 50);
                logo.SetAbsolutePosition(68, 765); //X, Y
                imgSafeLife.ScaleToFit(50, 50);
                imgSafeLife.SetAbsolutePosition(460, 750);
                doc.Add(logo);
                doc.Add(imgSafeLife);

                //Quebras de Linha
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));

                //Fontes de Texto
                BaseColor branco = new BaseColor(255, 255, 255);
                var calibre_12_Bold = FontFactory.GetFont(@"C:\Windows\Fonts\calibrib.ttf", 12);
                var calibre_12_Normal = FontFactory.GetFont(@"C:\Windows\Fonts\calibri.ttf", 12);
                var calibre_8_Bold = FontFactory.GetFont(@"C:\Windows\Fonts\calibrib.ttf", 8);
                var calibre_11_Bold = FontFactory.GetFont(@"C:\Windows\Fonts\calibrib.ttf", 11);
                var calibre_16_Bold = FontFactory.GetFont(@"C:\Windows\Fonts\calibrib.ttf", 16);
                var calibre_16_Bold_branca = FontFactory.GetFont(@"C:\Windows\Fonts\calibrib.ttf", 16, branco);
                var calibre_11_Normal = FontFactory.GetFont(@"C:\Windows\Fonts\calibri.ttf", 11);

                Paragraph confidencial = new Paragraph("CONFIDENCIAL", calibre_12_Normal);
                confidencial.Alignment = Element.ALIGN_RIGHT;
                doc.Add(confidencial);

                Paragraph propostaComercial = new Paragraph("2 - PROPOSTA COMERCIAL", calibre_12_Bold);
                propostaComercial.Alignment = Element.ALIGN_LEFT;
                doc.Add(propostaComercial);

                doc.Add(new Paragraph(" ")); //Quebra de Linha

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
                Chunk c2Tab2 = new Chunk($"{RazaoSocial}\nENDEREÇO: {Lorgradouro}, {Bairro} - {Complemento}\nCEP: {Cep}\nCIDADE: {Cidade}-{Uf.ToUpper()}\nCPF/CNPJ: {Cnpj}", calibre_12_Normal);

                Chunk c3Tab2 = new Chunk("REFERÊNCIA: ", calibre_12_Bold);
                Chunk c4Tab2 = new Chunk("M.O. ESPECIALISTA\n", calibre_12_Normal);

                Chunk c5Tab2 = new Chunk("DATA: ", calibre_12_Bold);
                Chunk c6Tab2 = new Chunk($"{DataSolicitacao}\n", calibre_12_Normal);

                Chunk c7Tab2 = new Chunk("SOLICITAÇÃO: ", calibre_12_Bold);
                Chunk c8Tab2 = new Chunk($"{Solicitacao}\n", calibre_12_Normal);

                Chunk c9Tab2 = new Chunk("CÓDIGO FORNECEDOR: ", calibre_12_Bold);
                Chunk c10Tab2 = new Chunk($"{CodEquipamento}\n", calibre_12_Normal);

                Chunk c11Tab2 = new Chunk("RESPONSÁVEL MENPLAN: ", calibre_12_Bold);
                Chunk c12Tab2 = new Chunk($"{Responsavel}\n", calibre_12_Normal);

                Chunk c13Tab2 = new Chunk("ÁREA: ", calibre_12_Bold);
                Chunk c14Tab2 = new Chunk($"{Area}\n", calibre_12_Normal);

                Chunk c15Tab2 = new Chunk("SOLICITANTE/ÁREA: ", calibre_12_Bold);
                Chunk c16Tab2 = new Chunk($"{Solicitante_Area}\n", calibre_12_Normal);

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
                Chunk c2Tab3 = new Chunk($"{Solicitante_Area}\n", calibre_12_Normal);

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

                doc.Add(new Phrase($"{CodicoesPagamento} DIAS APÓS LANÇAMENTO DA NOTA FISCAL", calibre_12_Normal));

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

                Paragraph resumoProposta = new Paragraph($"{ResumoProposta}", calibre_12_Normal);
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
                PdfPCell cell6Tab7 = new PdfPCell(new Phrase($"{Descricao}", calibre_11_Normal));
                PdfPCell cell7Tab7 = new PdfPCell(new Phrase($"{QuantidadeDias}", calibre_11_Normal)); //Valor deverear ser inserido pelo usuario
                PdfPCell cell8Tab7 = new PdfPCell(new Phrase($"{Periodo}", calibre_11_Normal));
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

                string dataProposta = DateTime.Now.Date.ToString();
                string[] splData;
                splData = dataProposta.Split(' ');

                Chunk p1 = new Chunk("VALIDADE DA PROPOSTA:\n", calibre_11_Bold);
                Chunk p2 = new Chunk($"{ValidadeProposta} DIAS A PARTIR DA PRESENTE DATA " + splData[0], calibre_11_Normal);

                Phrase validadeProposta = new Phrase();
                validadeProposta.Add(p1);
                validadeProposta.Add(p2);

                Paragraph proposta = new Paragraph(validadeProposta);

                proposta.Alignment = Element.ALIGN_LEFT;

                doc.Add(proposta);

                //---

                var rodape = iTextSharp.text.Image.GetInstance("rodape-menplan.png");
                rodape.ScaleToFit(1000, 71);
                rodape.SetAbsolutePosition(0, 0);
                doc.Add(rodape);

                doc.Close();
                System.Diagnostics.Process.Start(destino);

            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
            }
        }

        /*public void CriarPDF()
        {
            try
            {
                string caminho = PastaDestino.PastaNota(NumeroNota);

                Document doc = new Document(PageSize.A4);
                doc.SetMargins(80, 80, 20, 20); // (ESQUERDA, DIREITA, CIMA, BAIXO)+
                string destino = string.Format("{0}/{1} - Relatório.pdf", caminho, CriarPasta());
                
                PdfWriter.GetInstance(doc, new FileStream(destino, FileMode.Create));

                doc.Open();

                //Imagens
                var imagem1 = iTextSharp.text.Image.GetInstance("img2_menplan.png");
                var imagem2 = iTextSharp.text.Image.GetInstance("logo-mp.png");
                imagem1.ScaleToFit(50, 50);
                imagem1.SetAbsolutePosition(460, 750); //X, Y
                imagem2.ScaleToFit(150, 50);
                imagem2.SetAbsolutePosition(87, 765);
                doc.Add(imagem1);
                doc.Add(imagem2);

                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));
                //doc.Add(new Paragraph(" "));

                Paragraph p2 = new Paragraph("CONFIDENCIAL", new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL));
                p2.Alignment = Element.ALIGN_RIGHT;
                doc.Add(p2);

                Paragraph p1 = new Paragraph("2 - PROPOSTA COMERCIAL", new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD));
                p1.Alignment = Element.ALIGN_LEFT;
                doc.Add(p1);

                doc.Add(new Paragraph(" ")); //Quebra de Linha

                //Fontes e Cor
                BaseColor corTexto = new BaseColor(0, 0, 0);
                BaseColor corTexto2 = new BaseColor(255, 255, 255);
                BaseColor cinza = new BaseColor(169, 169, 169);
                var fonte0 = FontFactory.GetFont(@"C:\Windows\Fonts\calibri.ttf", 11, corTexto2);
                var fonte1 = FontFactory.GetFont(@"C:\Windows\Fonts\calibrib.ttf", 11, corTexto);
                var fonte2 = FontFactory.GetFont(@"C:\Windows\Fonts\calibri.ttf", 11);
                var fonte3 = FontFactory.GetFont(@"C:\Windows\Fonts\calibrib.ttf", 11); //Fonte Calibri Bold
                var fonte4 = FontFactory.GetFont(@"C:\Windows\Fonts\calibri.ttf", 3);
                var fonte5 = FontFactory.GetFont(@"C:\Windows\Fonts\calibri.ttf", 10);
                var fonteCinza = FontFactory.GetFont(@"C:\Windows\Fonts\calibri.ttf", 9, cinza);

                Chunk e0 = new Chunk("\n", fonte4); //Quebra de linha para as celulas

                //Primeira Tabela
                //
                PdfPTable tabela1 = new PdfPTable(2);
                PdfPCell cell1 = new PdfPCell(new Phrase("REFERÊNCIA COTAÇÃO", fonte2));
                PdfPCell cell2 = new PdfPCell(new Phrase(Cotacao, fonte2));
                cell1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;

                tabela1.HorizontalAlignment = 1;
                tabela1.WidthPercentage = 100;
                tabela1.AddCell(cell1);
                tabela1.AddCell(cell2);

                doc.Add(tabela1);

                doc.Add(new Paragraph(" ")); //Quebra de Linha

                //Segunda Tabela
                //
                PdfPTable tabela2 = new PdfPTable(2);
                PdfPCell cell3 = new PdfPCell(new Phrase("MENPLAN", fonte1));
                PdfPCell cell4 = new PdfPCell(new Phrase("CLIENTE", fonte1));
                PdfPCell cell5 = new PdfPCell(new Phrase("MENPLAN SERVIÇOS INDUSTRIAIS LTDA\nRUA PAULO AFONSO, 1245 KENNEDY\nCEP: 48020-650\nALAGOINHAS – BAHIA\nCPF/CNPJ: 12.115.710/0001-46\n", fonte2));
                PdfPCell cell6 = new PdfPCell(new Phrase($"{RazaoSocial}\nENDEREÇO: {Lorgradouro}, {Bairro} - {Complemento}\nCEP: {Cep}\nCIDADE: {Cidade}-{Uf.ToUpper()}\nCPF/CNPJ: {Cnpj}\n", fonte2));

                tabela2.WidthPercentage = 100;

                //Formatação
                cell3.HorizontalAlignment = 1;
                cell3.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell3.BackgroundColor = new BaseColor(135, 206, 250);
                cell4.HorizontalAlignment = 1;
                cell4.BackgroundColor = new BaseColor(135, 206, 250);
                cell4.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell5.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cell6.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                tabela2.AddCell(cell3);//Cabeçalho
                tabela2.AddCell(cell4);//Cabeçalho
                tabela2.AddCell(cell5);
                tabela2.AddCell(cell6);

                doc.Add(tabela2);

                doc.Add(new Paragraph(" ")); //Quebra de Linha

                //Terceira Tabela
                //
                //Contato Cliente - Nome
                Chunk c1 = new Chunk("NOME: ", fonte3);
                Chunk c2 = new Chunk($"{NomeEmpresa}\n", fonte2);

                //Contato Cliente - Telefone
                Chunk c3 = new Chunk("TELEFONE: ", fonte3);
                Chunk c4 = new Chunk($"{Telefone}\n", fonte2);

                //Contato Cliente - E-mail
                Chunk c5 = new Chunk("E-MAIL: ", fonte3);
                Chunk c6 = new Chunk($"{Email}\n", fonte2);

                Phrase phc = new Phrase();
                phc.Add(c1);
                phc.Add(c2);
                phc.Add(e0); //Espaço
                phc.Add(c3);
                phc.Add(c4);
                phc.Add(e0); //Espaço
                phc.Add(c5);
                phc.Add(c6);
                phc.Add(e0); //Espaço

                PdfPTable tabela3 = new PdfPTable(2);
                PdfPCell cell7 = new PdfPCell(new Phrase("CONTATO CLIENTE", fonte1));
                PdfPCell cell8 = new PdfPCell(phc);

                tabela3.WidthPercentage = 100;

                //Formatação
                cell7.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell7.HorizontalAlignment = 1;
                cell7.BackgroundColor = new BaseColor(135, 206, 250);
                cell8.VerticalAlignment = Element.ALIGN_LEFT;

                tabela3.AddCell(cell7);
                tabela3.AddCell(cell8);
                doc.Add(tabela3);

                doc.Add(new Paragraph(" ")); //Quebra de Linha

                //Quarta Tabela
                //
                //Dados de Serviço - Referência
                Chunk d1 = new Chunk("REFERÊNCIA: ", fonte1);
                Chunk d2 = new Chunk("\n", fonte2);

                //Dados de Serviço - Data
                Chunk d3 = new Chunk("DATA NOTA: ", fonte1);
                Chunk d4 = new Chunk($"{DataSolicitacao}\n", fonte2);

                //Dados de Serviço - Solicitação
                Chunk d5 = new Chunk("SOLICITAÇÃO: ", fonte1);
                Chunk d6 = new Chunk($"{Solicitacao}\n", fonte2);

                //Dados de Serviço - Código Fornecedor
                Chunk d7 = new Chunk("CÓDIGO FORNECEDOR: ", fonte1);
                Chunk d8 = new Chunk($"{CodEquipamento}\n", fonte2);

                //Dados de Serviço - Responsável MENPLAN
                Chunk d9 = new Chunk("RESPONSÁVEL MENPLAN: ", fonte1);
                Chunk d10 = new Chunk($"{Responsavel}\n", fonte2);

                //Dados de Serviço - Área
                Chunk d11 = new Chunk("ÁREA: ", fonte1);
                Chunk d12 = new Chunk($"{Area}\n", fonte2);

                //Dados de Serviço - Equipamento
                Chunk d13 = new Chunk("EQUIPAMENTO: ", fonte1);
                Chunk d14 = new Chunk($"{Equipamento}\n", fonte2);

                //Junção do textos Dados de Serviço
                Phrase ph1 = new Phrase();
                ph1.Add(d1);
                ph1.Add(d2);
                ph1.Add(e0); //Espaço
                ph1.Add(d3);
                ph1.Add(d4);
                ph1.Add(e0); //Espaço
                ph1.Add(d5);
                ph1.Add(d6);
                ph1.Add(e0); //Espaço
                ph1.Add(d7);
                ph1.Add(d8);
                ph1.Add(e0); //Espaço
                ph1.Add(d9);
                ph1.Add(d10);
                ph1.Add(e0); //Espaço
                ph1.Add(d11);
                ph1.Add(d12);
                ph1.Add(e0); //Espaço
                ph1.Add(d13);
                ph1.Add(d14);
                ph1.Add(e0); //Espaço

                PdfPTable tabela4 = new PdfPTable(2);
                PdfPCell cell9 = new PdfPCell(new Phrase("DADOS SERVIÇO", fonte0));
                PdfPCell cell10 = new PdfPCell(ph1);

                tabela4.WidthPercentage = 100;
                tabela4.TotalWidth = 412f;
                float[] larguraTab4 = new float[] { 60f, 105f };
                tabela4.SetWidths(larguraTab4);

                //Formatação
                cell9.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell9.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cell9.BackgroundColor = new BaseColor(25, 25, 112);
                cell10.VerticalAlignment = Element.ALIGN_LEFT;

                tabela4.AddCell(cell9);
                tabela4.AddCell(cell10);
                doc.Add(tabela4);

                doc.Add(new Paragraph(" ")); //Quebra de Linha

                //Quinta Tabela - 5º
                //
                PdfPTable tabela5 = new PdfPTable(2);
                PdfPCell cell11 = new PdfPCell(new Phrase("CONDIÇÕES\nPAGAMENTO", fonte1));
                PdfPCell cell12 = new PdfPCell(new Phrase("45 DIAS APÓS LANÇAMENTO DA NOTA FISCAL           MOEDA: BRL", fonte5));

                tabela5.WidthPercentage = 100;
                tabela5.TotalWidth = 412f;
                float[] larguraTab5 = new float[] { 60f, 105f };
                tabela5.SetWidths(larguraTab5);


                //Formatação
                cell11.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cell11.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell11.BackgroundColor = new BaseColor(135, 206, 250);
                cell12.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cell12.VerticalAlignment = Element.ALIGN_MIDDLE;

                tabela5.AddCell(cell11);
                tabela5.AddCell(cell12);
                doc.Add(tabela5);

                doc.Add(new Paragraph(" ")); //Quebra de Linha

                //Sexta Tabela - 6º
                //
                Chunk r1 = new Chunk("Cotação referente a: ", fonte3);
                Chunk r2 = new Chunk($"{Descricao}\n\n\n", fonte2);

                Phrase phr = new Phrase();
                phr.Add(r1);
                phr.Add(r2);

                PdfPTable tabela6 = new PdfPTable(1);
                PdfPCell cell13 = new PdfPCell(new Phrase("RESUMO DA PROPOSTA", fonte1));
                PdfPCell cell14 = new PdfPCell(phr);

                tabela6.WidthPercentage = 100;

                cell13.HorizontalAlignment = 1;
                cell13.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell13.BackgroundColor = new BaseColor(135, 206, 250);
                cell14.HorizontalAlignment = PdfPCell.ALIGN_JUSTIFIED;

                tabela6.AddCell(cell13);
                tabela6.AddCell(cell14);
                doc.Add(tabela6);

                doc.Add(new Paragraph(" "));

                //Setima Tabela - 7º
                //
                PdfPTable tabela7 = new PdfPTable(1);
                PdfPCell cell15 = new PdfPCell(new Phrase("VALOR DA PROPOSTA", fonte1));

                tabela7.WidthPercentage = 100;

                cell15.BackgroundColor = new BaseColor(135, 206, 250);
                cell15.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell15.HorizontalAlignment = 1;

                tabela7.AddCell(cell15);
                doc.Add(tabela7);

                //Oitava Tabela - 8º
                //
                PdfPTable tabela8 = new PdfPTable(5);
                PdfPCell cell16 = new PdfPCell(new Phrase("DESCRIÇÃO DO SERVIÇO", fonte2));
                PdfPCell cell17 = new PdfPCell(new Phrase("QUANT.", fonte2));
                PdfPCell cell18 = new PdfPCell(new Phrase("PERÍODO", fonte2));
                PdfPCell cell19 = new PdfPCell(new Phrase("VALOR UNIT.", fonte2));
                PdfPCell cell20 = new PdfPCell(new Phrase("VALOR TOTAL", fonte2));
                PdfPCell descricao = new PdfPCell(new Phrase(Descricao, fonte2));
                PdfPCell quantidade = new PdfPCell(new Phrase("1", fonte2));
                PdfPCell periodo = new PdfPCell(new Phrase("TBD", fonte2));
                PdfPCell valorUnit = new PdfPCell(new Phrase("R$ " + ValorUnit, fonte2));
                PdfPCell valorTotal = new PdfPCell(new Phrase("R$ " + ValorTotal, fonte0));

                tabela8.WidthPercentage = 100;
                tabela8.TotalWidth = 412f; //Tamanho atual das tabelas
                //tabela8.LockedWidth = true;
                float[] largura = new float[] { 60f, 15f, 20f, 20f, 25f };
                tabela8.SetWidths(largura);

                cell16.HorizontalAlignment = 1;
                cell17.HorizontalAlignment = 1;
                cell18.HorizontalAlignment = 1;
                cell19.HorizontalAlignment = 1;
                cell20.HorizontalAlignment = 1;
                valorTotal.BackgroundColor = new BaseColor(25, 25, 112);
                descricao.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                valorUnit.HorizontalAlignment = 1;
                valorUnit.VerticalAlignment = Element.ALIGN_MIDDLE;
                quantidade.HorizontalAlignment = 1;
                quantidade.VerticalAlignment = Element.ALIGN_MIDDLE;
                periodo.HorizontalAlignment = 1;
                periodo.VerticalAlignment = Element.ALIGN_MIDDLE;
                valorTotal.HorizontalAlignment = 1;
                valorTotal.VerticalAlignment = Element.ALIGN_MIDDLE;


                tabela8.AddCell(cell16);
                tabela8.AddCell(cell17);
                tabela8.AddCell(cell18);
                tabela8.AddCell(cell19);
                tabela8.AddCell(cell20);

                tabela8.AddCell(descricao);
                tabela8.AddCell(quantidade);
                tabela8.AddCell(periodo);
                tabela8.AddCell(valorUnit);
                tabela8.AddCell(valorTotal);
                doc.Add(tabela8);

                //Nona Tabela - 9º
                //
                //PdfPTable tabela9 = new PdfPTable(5);
                //PdfPCell cell21 = new PdfPCell(new Phrase("TOTAL:", fonte0));
                //PdfPCell cell22 = new PdfPCell(new Phrase(" "));

                //tabela9.WidthPercentage = 100;

                //tabela9.DefaultCell.Border = Rectangle.NO_BORDER;
                //tabela9.TotalWidth = 412f;
                //tabela9.DefaultCell.FixedHeight = 0.5f;
                ////tabela9.LockedWidth = true;
                //float[] larguraTb9 = new float[] { 60f, 20f, 20f, 20f, 25f };
                //tabela9.SetWidths(larguraTb9);

                //cell21.HorizontalAlignment = 2;
                //cell21.VerticalAlignment = Element.ALIGN_MIDDLE;
                //cell21.PaddingTop = 0.8f;
                //cell21.BackgroundColor = new BaseColor(25, 25, 112);

                //tabela9.AddCell(" ");
                //tabela9.AddCell(" ");
                //tabela9.AddCell(" ");
                //tabela9.AddCell(cell21);
                //tabela9.AddCell(cell22);
                //doc.Add(tabela9);

                doc.Add(new Paragraph(" "));

                //Data da Proposta
                string data = "Data Proposta: " + DateTime.Now.ToString();

                Paragraph dataProposta = new Paragraph(data, fonte2);
                dataProposta.Alignment = Element.ALIGN_LEFT;
                doc.Add(dataProposta);

                //Rodapé
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));
                //doc.Add(new Paragraph(" "));
                //doc.Add(new Paragraph(" "));
                //doc.Add(new Paragraph(" "));
                //doc.Add(new Paragraph(" "));
                //doc.Add(new Paragraph(" "));
                //doc.Add(new Paragraph(" "));

                var simbolo = FontFactory.GetFont(@"C:\Windows\Fonts\wingding.ttf", 10, cinza);

                Chunk rd1 = new Chunk("Rua Paulo Afonso, 1245, Kennedy. CEP: 48020-650, Alagoinhas - BA\n", fonteCinza);
                Chunk rd2 = new Chunk(":", simbolo);
                Chunk rd3 = new Chunk(" www.menplan.com.br | ", fonteCinza);
                Chunk rd4 = new Chunk(")", simbolo);
                Chunk rd5 = new Chunk(" (75) 9 9821-4999", fonteCinza);

                Phrase phrd = new Phrase();
                phrd.Add(rd1);
                phrd.Add(rd2);
                phrd.Add(rd3);
                phrd.Add(rd4);
                phrd.Add(rd5);

                Paragraph rodape = new Paragraph(phrd);
                rodape.Alignment = 1;
                doc.Add(rodape);

                doc.Close();
                System.Diagnostics.Process.Start(destino);
            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
            }      

        }*/
    }
}
