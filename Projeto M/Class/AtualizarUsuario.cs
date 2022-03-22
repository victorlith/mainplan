using System;
using System.Data.SQLite;

namespace Projeto_M.Class01
{
    class AtualizarUsuario
    {
        Conexao con = new Conexao();
        SQLiteCommand cmd = new SQLiteCommand();

        public string mensagem = "";

        public void AtualizarUser(string matricula, string especialidade, string funcao, string nivelAcesso, string celular, string telefone, string email, string linkedin, string senha)
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "UPDATE TABELA_USUARIO SET especialidade = @especialidade, funcao = @funcao, nivel_acesso = @nivel, celular = @celular, telefone = @telefone, email = @email, linkedin = @linkedin, senha = @senha WHERE matricula = @matricula";

                cmd.Parameters.AddWithValue("@matricula", matricula);
                cmd.Parameters.AddWithValue("@especialidade", especialidade);
                cmd.Parameters.AddWithValue("@funcao", funcao);
                cmd.Parameters.AddWithValue("@nivel", nivelAcesso);
                cmd.Parameters.AddWithValue("@celular", celular);
                cmd.Parameters.AddWithValue("@telefone", telefone);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@linkedin", linkedin);
                cmd.Parameters.AddWithValue("@senha", senha);
                cmd.ExecuteNonQuery();

                this.mensagem = "Dados atualizado com sucesso!";
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
