namespace TP5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data;
using Microsoft.Data.Sqlite;


public class FuncionesDB
{
    public FuncionesDB(){}

    //Cadetes
    //Funcion para recuperar los id de cadeteria de la tabla cadeteria
    static string connectionString= $"Data Source=BD/PedidosDB";
    static public SqliteConnection conexion= new SqliteConnection(connectionString);

    public List<int> recuperarIDcadeteria()
    {
        List<int>listaID=new List<int>();
        conexion.Open();
        SqliteCommand select=new SqliteCommand("SELECT Id_cadeteria FROM Cadeteria",conexion);
        var query=select.ExecuteReader();
        while(query.Read())
        {
                        //ID
            listaID.Add(query.GetInt32(0));
        }
        conexion.Close();
        return listaID;
    }
}