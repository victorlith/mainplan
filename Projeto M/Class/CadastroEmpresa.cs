using System;
using System.Data.SQLite;

namespace Projeto_M
{
    class CadastroEmpresa
    {
        Conexao con = new Conexao();
        SQLiteCommand cmd = new SQLiteCommand();

        public String mensagem = "";

        public CadastroEmpresa(String codigo, String razaoSocial, String nomeFantasia, String nomeEmpresa, String cnpj, String siglaEmpresa, String cep, String lorgadouro,
            String numeroEdereco, String complemento, String bairro, String cidade, String uf, String site, String telefoneCliente, String ramal, String email, String pessoaResponsavel, String contatoResponsavel, String setor)
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "INSERT INTO TABELA_CLIENTE (COD_CLIENTE, RAZAO_SOCIAL, NOME_FANTASIA, NOME_EMPRESA, CNPJ, SIGLA_EMPRESA, CEP, LORGRADOURO, NUMERO_ENDERECO, COMPLEMENTO, BAIRRO, CIDADE, UF, SITE, TELEFONE_CLIENTE, RAMAL, EMAIL, PESSOA_RESPONSAVEL, CONTATO_RESPONSAVEL, SETOR_CONTATO) " +
                    "VALUES (@COD_CLIENTE, @RAZAO_SOCIAL, @NOME_FANTASIA, @NOME_EMPRESA, @CNPJ, @SIGLA_EMPRESA, @CEP, @LORGRADOURO, @NUMERO_ENDERECO, @COMPLEMENTO, @BAIRRO, @CIDADE, @UF, @SITE, @TELEFONE_CLIENTE, @RAMAL, @EMAIL, @PESSOA_RESPONSAVEL, @CONTATO_RESPONSAVEL, @SETOR)";

                cmd.Parameters.AddWithValue("@COD_CLIENTE", codigo);
                cmd.Parameters.AddWithValue("@RAZAO_SOCIAL", razaoSocial);
                cmd.Parameters.AddWithValue("@NOME_FANTASIA", nomeFantasia);
                cmd.Parameters.AddWithValue("@NOME_EMPRESA", nomeEmpresa);
                cmd.Parameters.AddWithValue("@CNPJ", cnpj);
                cmd.Parameters.AddWithValue("@SIGLA_EMPRESA", siglaEmpresa);
                cmd.Parameters.AddWithValue("@CEP", cep);
                cmd.Parameters.AddWithValue("@LORGRADOURO", lorgadouro);
                cmd.Parameters.AddWithValue("@NUMERO_ENDERECO", numeroEdereco);
                cmd.Parameters.AddWithValue("@COMPLEMENTO", complemento);
                cmd.Parameters.AddWithValue("@BAIRRO", bairro);
                cmd.Parameters.AddWithValue("@CIDADE", cidade);
                cmd.Parameters.AddWithValue("@UF", uf);
                cmd.Parameters.AddWithValue("@SITE", site);
                cmd.Parameters.AddWithValue("@TELEFONE_CLIENTE", telefoneCliente);
                cmd.Parameters.AddWithValue("@RAMAL", ramal);
                cmd.Parameters.AddWithValue("@EMAIL", email);
                cmd.Parameters.AddWithValue("@PESSOA_RESPONSAVEL", pessoaResponsavel);
                cmd.Parameters.AddWithValue("@CONTATO_RESPONSAVEL", contatoResponsavel);
                cmd.Parameters.AddWithValue("@SETOR", setor);
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
