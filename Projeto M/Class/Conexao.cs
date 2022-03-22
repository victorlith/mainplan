using System.Data.SQLite;

namespace Projeto_M
{
    class Conexao
    {
        SQLiteConnection con = new SQLiteConnection();



        public Conexao()
        {
            con.ConnectionString = "Data Source=banco_menplan.db;Version=3;New=False;Compress=True";
        }
        public SQLiteConnection Conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        public void Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
