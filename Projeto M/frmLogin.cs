using Projeto_M.Class01;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Projeto_M
{
    public partial class frmLogin : Form
    {
        Conexao con = new Conexao();
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataAdapter da;


        private string usuario = "";
        private string nivelAcesso = "";

        public frmLogin()
        {
            InitializeComponent();

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void Login()
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_USUARIO WHERE MATRICULA = @MATRICULA AND SENHA = @SENHA";
                cmd.Parameters.AddWithValue("@MATRICULA", tb_login.Text);
                cmd.Parameters.AddWithValue("@SENHA", tb_senha.Text);
                cmd.ExecuteNonQuery();

                da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    frmTelaPrincipal menu = new frmTelaPrincipal();

                    menu.usuario = dt.Rows[0].Field<string>("NOME");
                    menu.nivel = dt.Rows[0].Field<string>("NIVEL_ACESSO");
                    usuario = dt.Rows[0].Field<string>("NOME");
                    nivelAcesso = dt.Rows[0].Field<string>("NIVEL_ACESSO");


                    menu.Show();
                    this.Hide();

                    tb_login.Clear();
                    tb_senha.Clear();

                }
                else
                {
                    MessageBox.Show("Usuário ou Senha inválidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tb_login_TextChanged(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void tb_login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Login();
            }
        }

        private void tb_senha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Login();
            }
        }

        private void tb_login_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void tb_senha_TextChanged(object sender, EventArgs e)
        {

        }

        private void pbSair_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogsDoSistema log = new LogsDoSistema();
            log.Log_AcessoAoSistema("Logout", usuario, nivelAcesso);
        }
    }
}
