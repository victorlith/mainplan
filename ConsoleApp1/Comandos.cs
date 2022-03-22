using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Diagnostics;

namespace ConsoleApp1
{
    static class Comandos
    {
        private static string _comando;

        private static string path = Directory.GetCurrentDirectory();

        public static string Comando
        {
            get {  return _comando; }
            set { _comando = value; }
        }

        public static void CommandResult()
        {
            switch (_comando)
            {
                case "teste":                   
                    Console.WriteLine(TesteCommand());
                    break;

                case "txt":
                    CriarDocumentoTXT();
                    break;

                case "clear":
                    Console.Clear();
                    break;

                case "":
                    break;

                default:
                    Console.WriteLine("Comando Desconhecido");
                    break;
            }
        }

       internal static string TesteCommand()
        {
            string nome = "Comando Teste";
            return nome;
        }

        private static void CriaDocumentoXML()
        {
            try
            {
                string arquivo = Path.Combine(path, "comandos.xml");

                XmlTextWriter xWriter = new XmlTextWriter(arquivo, Encoding.UTF8);

                //Inicia o Documento XML
                xWriter.WriteStartDocument();

                xWriter.WriteStartElement("Comandos");

                xWriter.WriteStartElement("txt");
                xWriter.WriteElementString("comando", "txt");
                xWriter.WriteElementString("descricao", "Cria um documento de texto no local especificado.");
                xWriter.WriteEndElement();

                xWriter.WriteStartElement("clear");
                xWriter.WriteElementString("comando", "clear");
                xWriter.WriteElementString("descricao", "Limpa a tela do console");
                xWriter.WriteEndElement();

                xWriter.WriteStartElement("");
                xWriter.WriteElementString("comando", "");
                xWriter.WriteElementString("descricao", "");
                xWriter.WriteEndElement();

                xWriter.WriteStartElement("");
                xWriter.WriteElementString("comando", "");
                xWriter.WriteElementString("descricao", "");
                xWriter.WriteEndElement();

                xWriter.WriteStartElement("");
                xWriter.WriteElementString("comando", "");
                xWriter.WriteElementString("descricao", "");
                xWriter.WriteEndElement();

                xWriter.WriteEndElement();

                //Finaliza o Documento XML
                xWriter.WriteEndDocument();

                xWriter.Close();
            }
            catch (Exception)
            {
                throw;
            }       
        }

        private static void CriarDocumentoTXT()
        {
            try
            {
                string caminho, arquivo, pathArquivo, texto = "";
                
                Console.Write("Digite o caminho do arquivo: ");
                caminho = Console.ReadLine();

                Console.Write("Digite o nome do arquivo: ");
                arquivo = Console.ReadLine();

                pathArquivo = Path.Combine(caminho, $"{arquivo}.txt");

                if (!File.Exists(caminho))
                {

                    File.Create(pathArquivo).Close();

                    Console.Write("Digite o texto: ");
                    texto = Console.ReadLine();

                    File.WriteAllText(pathArquivo, texto);
                }

                Console.WriteLine("Arquivo criado com sucesso!");
                Process.Start(pathArquivo);           
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AjustaHoraDoSistema()
        {
            
        }
    }
}
