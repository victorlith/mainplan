using System.Data.SQLite;
using System.IO;

namespace ConsoleApp1
{
    static class Conexao
    {
        static SQLiteConnection con = new SQLiteConnection();

        static string path = Directory.GetCurrentDirectory();

        static string file = Path.Combine(path, "banco_menplan.db");

        static Conexao()
        {
            con.ConnectionString = "Data Source=banco_menplan.db;Version=3;New=False;Compress=True";
        }
        public static SQLiteConnection Conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        public static void Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
