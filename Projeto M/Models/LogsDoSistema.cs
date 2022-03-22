using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projeto_M.Class01
{
    internal class LogsDoSistema
    {

        private string path = @"logs_sistema";
        private string dataEvento = $"{DateTime.Now.ToLongDateString()} - {DateTime.Now.ToLongTimeString()}"; 

        public LogsDoSistema()
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    DirectoryInfo diretorio = new DirectoryInfo(path);
                    diretorio.Create();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Log_AcessoAoSistema(string acao, string usuario, string nivelAcesso)
        {

            string caminho_Arquivo = Path.Combine(path, "log_acesso.txt");
            string textoLogin = $"{dataEvento} > Usuário:[{usuario}] Nível de Acesso:[{nivelAcesso}] > acessou o sistema." + "\n";
            string textoLogout = $"{dataEvento} > Usuário:[{usuario}] Nível de Acesso:[{nivelAcesso}] > encerrou o acesso." + "\n";

            if (!File.Exists(caminho_Arquivo))
            {
                File.Create(caminho_Arquivo).Close();
            }

            switch (acao)
            {
                case "Login":
                    try
                    {
                        File.AppendAllText(caminho_Arquivo, textoLogin);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    break;

                case "Logout":
                    try
                    {                     
                        File.AppendAllText(caminho_Arquivo, textoLogout);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    break;
            }
            
        }

        public void Log_Funcionarios(string atividade, string usuarioSistema, string usuario)
        {
            string caminho_Arquivo = Path.Combine(path, "log_funcionarios.txt");
           
            string textoCadastro = $"{dataEvento} > Usuário:[{usuarioSistema}] cadstrou o usuário {usuario}. \n";
            string textoExclusao = $"{dataEvento} > Usuário:[{usuarioSistema}] excluiu o usuário {usuario}. \n";
            string textoAltercao = $"{dataEvento} > Usuário:[{usuarioSistema}] alterou os dados do usuáro {usuario}. \n";

            switch (atividade)
            {
                case "Cadastro":
                    try
                    {
                        File.AppendAllText(caminho_Arquivo, textoCadastro);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    break;

                case "Exclusao":
                    try
                    {
                        File.AppendAllText(caminho_Arquivo, textoExclusao);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    break;

                case "Alteracao":
                    try
                    {
                        File.AppendAllText(caminho_Arquivo, textoAltercao);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    break;
            }
        }

        public void Log_Clientes(string atividade, string usuarioSistema, string cliente)
        {
            string caminho_Arquivo = Path.Combine(path, "log_clientes.txt");

            string textoCadastro = $"{dataEvento} > Usuário:[{usuarioSistema}] cadstrou o cliente {cliente}. \n";
            string textoExclusao = $"{dataEvento} > Usuário:[{usuarioSistema}] excluiu o cliente {cliente}. \n";
            string textoAltercao = $"{dataEvento} > Usuário:[{usuarioSistema}] alterou os dados do cliente {cliente}. \n";

            switch (atividade)
            {
                case "Cadastro":
                    try
                    {
                        File.AppendAllText(caminho_Arquivo, textoCadastro);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    break;

                case "Exclusao":
                    try
                    {
                        File.AppendAllText(caminho_Arquivo, textoExclusao);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    break;

                case "Alteracao":
                    try
                    {
                        File.AppendAllText(caminho_Arquivo, textoAltercao);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    break;
            }
        }

    }
}
