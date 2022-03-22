using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;
using System.Configuration;
using System.Collections.Specialized;

namespace ConsoleApp1
{
    internal class Program
    {
        internal static string password = "";
        static string menu = "";

        static void Main(string[] args)
        {        
            ConfiguracoesConsole();

            MenuDeComandos();
            
        }

        private static void MenuDeComandos()
        {
            Console.Write("Digite a senha de acesso: ");
            password = Console.ReadLine();

            if (password == "Tech15045")
            {
                string opcao;
                string path = Directory.GetCurrentDirectory();

                do
                {
                    Console.Clear();

                    Console.WriteLine("====================================");
                    Console.WriteLine("       Command Line Projeto M");
                    Console.WriteLine("====================================");
                    Console.WriteLine(""); //Quebra de Linha
                    Console.WriteLine("Diretório atual: " + path);
                    Console.WriteLine(""); //Quebra de Linha
                    Console.WriteLine("====================================");
                    Console.WriteLine(""); //Quebra de Linha
                    Console.WriteLine("1 - Limpar Banco de Dados");
                    Console.WriteLine("2 - Fazer Backup do Banco de Dados");
                    Console.WriteLine("3 - CLI");
                    Console.WriteLine("4 - Exibir Tabela");
                    Console.WriteLine(""); //Quebra de Linha
                    Console.WriteLine("====================================");

                    Console.Write("Digite uma opção: ");
                    opcao = Console.ReadLine();

                    AcaoUsuario(opcao);

                } while (menu != "0");
            }
            else
            {
                Console.WriteLine("Senha incorreta!");
                Console.ReadKey();
            }
        }

        private static void AcaoUsuario(string opcao)
        {

            switch (opcao)
            {
                case "1":
                    try
                    {
                        string senha = "";

                        Console.Write("Digite a senha de acesso: ");
                        senha = Console.ReadLine();

                        if (senha == "Tech15045")
                        {
                            OperacoeDB.LimparDatabase();
                            Console.WriteLine("Dados removidos com sucesso!");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Senha incorreta!");
                            Console.ReadKey();
                            return;
                        }                       
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();
                        Console.WriteLine(ex.Message);
                        VoltarAoMenu();
                       
                    }

                    VoltarAoMenu();
                    break;

                case "3":

                    TerminalCommand();

                    break;

                case "4":
                    try
                    {
                        string tabela = "";

                        Console.Write("Digite o nome da tabela: ");
                        tabela = Console.ReadLine();

                        Console.Clear();

                        Console.WriteLine(tabela.ToUpper());

                        foreach (System.Data.DataRow linha in OperacoeDB.ExibirDadosTabela(tabela).Rows)
                        {                        
                            Console.WriteLine( "\n" + "--- Row ---");
                            foreach (object item in linha.ItemArray)
                            {
                                Console.Write("Coluna: ");
                                Console.WriteLine(item);                              
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.Clear();
                        Console.WriteLine(ex.Message);
                        VoltarAoMenu();
                    }

                    VoltarAoMenu();
                    break;
                    

            }
        }

        private static void VoltarAoMenu()
        {
            Console.WriteLine(""); //Quebra de Linha
            Console.Write("Digite \"0\" Voltar para o menu: ");
            menu = Console.ReadLine();
        }

        private static void TerminalCommand()
        {

            Console.Clear();

            string comando = "";
                
            while (comando != "exit")
            {
         
                Console.Write("Command:> ");
                comando = Console.ReadLine();
                Comandos.Comando = comando;
                Comandos.CommandResult();
            
            }

            VoltarAoMenu();
        }

        private static void ConfiguracoesConsole()
        {
            Console.Title = "CLI Projeto M";

            Console.WindowHeight = 30;
            Console.WindowWidth = 100;

            Console.ForegroundColor = ConsoleColor.Cyan;


            Console.WriteLine("");
        }
    }
}
