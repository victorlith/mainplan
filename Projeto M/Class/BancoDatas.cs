﻿using System;
using System.Data.SQLite;

namespace Projeto_M
{
    class BancoDatas
    {
        Conexao con = new Conexao();
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataReader dr;

        public string mensagem = "";

        private string ID_Data;
        private string Data;
        private string DiaSemana;
        private string DSemana;


        public string[] ConsultaData(string data)
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_DATA WHERE DATA = @DATA";
                cmd.Parameters.AddWithValue("@DATA", data);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ID_Data = (string)dr["id_data"];
                    Data = (string)dr["data"];
                    DiaSemana = (string)dr["dia_semana"];
                }
                dr.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Desconectar();
            }

            return new[] { ID_Data, Data, DiaSemana };

        }

        public string ConsultaDiaSemana(string id)
        {
            try
            {
                cmd.Connection = con.Conectar();

                cmd.CommandText = "SELECT * FROM TABELA_DATA WHERE ID_DATA = @ID";
                cmd.Parameters.AddWithValue("@ID", id);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    DSemana = (string)dr["dia_semana"];
                }
                dr.Close();
            }
            catch (Exception ex)
            {

                this.mensagem = ex.Message;
            }
            finally
            {
                con.Desconectar();
            }

            return DSemana;
        }


    }
}
