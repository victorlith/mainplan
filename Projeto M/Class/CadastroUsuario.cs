using System;
using System.Data.SQLite;

namespace Projeto_M
{
    class CadastroUsuario
    {
        Conexao con = new Conexao();
        SQLiteCommand cmd = new SQLiteCommand();

        public String mensagem = "";

        public CadastroUsuario(String matricula, String senha, String nivel, String nome, String especialidade, String funcao, String dataNascimento, String sexo, String rg, String cpf, String celular, String telefone, String email, String linkedin)
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "INSERT INTO TABELA_USUARIO (MATRICULA, SENHA, NIVEL_ACESSO, NOME, ESPECIALIDADE, FUNCAO, DATA_NASCIMENTO, SEXO, RG, CPF, CELULAR, TELEFONE, EMAIL, LINKEDIN) " +
                    "VALUES (@MATRICULA, @SENHA, @NIVEL_ACESSO, @NOME, @ESPECIALIDADE, @FUNCAO, @DATA_NASCIMENTO, @SEXO, @RG, @CPF, @CELULAR, @TELEFONE, @EMAIL, @LINKEDIN)";


                cmd.Parameters.AddWithValue("@MATRICULA", matricula);
                cmd.Parameters.AddWithValue("@SENHA", senha);
                cmd.Parameters.AddWithValue("@NIVEL_ACESSO", nivel);
                cmd.Parameters.AddWithValue("@NOME", nome);
                cmd.Parameters.AddWithValue("@ESPECIALIDADE", especialidade);
                cmd.Parameters.AddWithValue("@FUNCAO", funcao);
                cmd.Parameters.AddWithValue("@DATA_NASCIMENTO", dataNascimento);
                cmd.Parameters.AddWithValue("@SEXO", sexo);
                cmd.Parameters.AddWithValue("@RG", rg);
                cmd.Parameters.AddWithValue("@CPF", cpf);
                cmd.Parameters.AddWithValue("@CELULAR", celular);
                cmd.Parameters.AddWithValue("@TELEFONE", telefone);
                cmd.Parameters.AddWithValue("@EMAIL", email);
                cmd.Parameters.AddWithValue("@LINKEDIN", linkedin);
                cmd.ExecuteNonQuery();

                this.mensagem = "Cadastro realizado com sucesso!";
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
