using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
		public SQLiteConnection conectar()
		{
			if (con.State == System.Data.ConnectionState.Closed)
			{
				con.Open();
			}
			return con;
		}
		public void desconectar()
		{
			if (con.State == System.Data.ConnectionState.Open)
			{
				con.Close();
			}
		}	
	}
}
