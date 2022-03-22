using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Projeto_M.Class
{
    internal class GeraNovoID
    {     
        public string GerarCodigoCliente()
        {
            Conexao con = new Conexao();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader dr;

            string novoID;

            novoID = GerarID();

            cmd.Connection = con.Conectar();

            cmd.CommandText = "select * from tabela_cliente where cod_cliente = '" + novoID + "'";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                novoID = GerarID();
            }
            dr.Close();

            return novoID;
        }

        private string GerarID()
        {
            Random rand = new Random();
            List<int> listNumeros = new List<int>();

            int numberID;

            while (listNumeros.Count < 5)
            {
                numberID = rand.Next(0, 10);
                listNumeros.Add(numberID);
            }

            numberID = int.Parse(string.Concat(listNumeros));

            return numberID.ToString();
        }
    }
}
