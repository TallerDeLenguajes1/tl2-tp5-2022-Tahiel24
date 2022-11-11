namespace TP5.Models;
using TP5.ViewModels;
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

    public List<Cadete> DevolverListadoCadetes(){
        List<Cadete>listado=new List<Cadete>();
        conexion.Open();
        SqliteCommand select= new SqliteCommand("SELECT * FROM Cadete", conexion);
        var query=select.ExecuteReader();
        while(query.Read())
        {
                                    //ID                //Nombre        //Direccion         //Telefono      //ID_cadeteria
            Cadete nuevo= new(query.GetInt32(0), query.GetString(1), query.GetString(2),query.GetString(3),Convert.ToInt32(query.GetString(4)));
            listado.Add(nuevo);
        }
        conexion.Close();
        return listado;
    }

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

    //Funcion para agregar datos a la BD
    public void SubirDatosBD(Cadete cadete){
        conexion.Open();
        SqliteCommand insertar= new SqliteCommand("INSERT INTO Cadete (Nombre, Direccion, Telefono, id_cadeteria) VALUES (@nom, @dire, @tel, @id_cad)",conexion);
        insertar.Parameters.AddWithValue("@nom", cadete.Nombre);
        insertar.Parameters.AddWithValue("@dire", cadete.Direccion );
        insertar.Parameters.AddWithValue("@tel", cadete.Telefono1);
        insertar.Parameters.AddWithValue("@id_cad", cadete.Id_Cadeteria);
        try{
            insertar.ExecuteReader();
            conexion.Close();
        }catch(Exception ex)
        {
            Console.WriteLine("Error: "+ex.Message);
            conexion.Close();
        }
    }
}