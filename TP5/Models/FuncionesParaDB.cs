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
    public FuncionesDB() { }

    //Cadetes
    static string connectionString = $"Data Source=BD/PedidosDB";
    static public SqliteConnection conexion = new SqliteConnection(connectionString);

    //Funcion para devolver un listado de cadetes
    public List<Cadete> DevolverListadoCadetes()
    {
        List<Cadete> listado = new List<Cadete>();
        conexion.Open();
        SqliteCommand select = new SqliteCommand("SELECT * FROM Cadete", conexion);
        var query = select.ExecuteReader();
        while (query.Read())
        {
            //ID                //Nombre        //Direccion         //Telefono      //ID_cadeteria
            Cadete nuevo = new(query.GetInt32(0), query.GetString(1), query.GetString(2), query.GetString(3), Convert.ToInt32(query.GetString(4)));
            listado.Add(nuevo);
        }
        conexion.Close();
        return listado;
    }

    //Funcion que recupera los id de las cadeterias
    public List<int> recuperarIDcadeteria()
    {
        List<int> listaID = new List<int>();
        conexion.Open();
        SqliteCommand select = new SqliteCommand("SELECT Id_cadeteria FROM Cadeteria", conexion);
        var query = select.ExecuteReader();
        while (query.Read())
        {
            //ID
            listaID.Add(query.GetInt32(0));
        }
        conexion.Close();
        return listaID;
    }

    public List<int> recuperarIDcadetes()
    {
        List<int> listaID = new List<int>();
        conexion.Open();
        SqliteCommand select= new SqliteCommand("SELECT Id_cadete FROM Cadete", conexion);
        var query= select.ExecuteReader();
        while(query.Read())
        {
            listaID.Add(query.GetInt32(0));
        }
        conexion.Close();
        return listaID;
    }

    public  List<int> recuperarIDclientes()
    {
        List<int> listaID = new List<int>();
        conexion.Open();
        SqliteCommand select = new SqliteCommand("SELECT Id_cliente FROM Clientes", conexion);
        var query=select.ExecuteReader();
        while(query.Read())
        {
            listaID.Add(query.GetInt32(0));
        }
        conexion.Close();
        return listaID;
    }

    //Funcion para agregar cadetes a la BD
    public void SubirDatosBD(Cadete cadete)
    {
        conexion.Open();
        SqliteCommand insertar = new SqliteCommand("INSERT INTO Cadete (Nombre, Direccion, Telefono, id_cadeteria) VALUES (@nom, @dire, @tel, @id_cad)", conexion);
        insertar.Parameters.AddWithValue("@nom", cadete.Nombre);
        insertar.Parameters.AddWithValue("@dire", cadete.Direccion);
        insertar.Parameters.AddWithValue("@tel", cadete.Telefono1);
        insertar.Parameters.AddWithValue("@id_cad", cadete.Id_Cadeteria);
        try
        {
            insertar.ExecuteReader();
            conexion.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            conexion.Close();
        }
    }

    //Funcion para eliminar cadetes de la BD
    public void EliminarDatosBD(int ID)
    {
        conexion.Open();
        SqliteCommand delete = new SqliteCommand("DELETE FROM Cadete WHERE Id_cadete=@id", conexion);
        delete.Parameters.AddWithValue("@id", ID);
        try
        {
            delete.ExecuteReader();
            conexion.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            conexion.Close();
        }
    }

    //Funcion para editar cadetes de la BD
    public void EditarCadetes(Cadete cadete)
    {
        conexion.Open();
        SqliteCommand editar = new SqliteCommand("UPDATE Cadete SET Nombre=@nom, Direccion = @dir, Telefono = @tel, id_cadeteria=@id_cad WHERE Id_Cadete = $cad", conexion);
        editar.Parameters.AddWithValue("$cad", cadete.Id);
        editar.Parameters.AddWithValue("@nom", cadete.Nombre);
        editar.Parameters.AddWithValue("@dir", cadete.Direccion);
        editar.Parameters.AddWithValue("@tel", cadete.Telefono1);
        editar.Parameters.AddWithValue("@id_cad", cadete.Id_Cadeteria);
        try
        {
            editar.ExecuteReader();
            conexion.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            conexion.Close();
        }
    }

    public Cadete DevolverCadetePorId(int ID)
    {
        conexion.Open();
        SqliteCommand select= new SqliteCommand("SELECT * FROM Cadete WHERE Id_cadete = $id", conexion);
        select.Parameters.AddWithValue("$id", ID);
        Cadete nuevoCadete = new Cadete();
        var query= select.ExecuteReader();
        while(query.Read())
        {
            nuevoCadete = new Cadete(query.GetInt32(0), query.GetString(1), query.GetString(2), query.GetString(3), Convert.ToInt32(query.GetString(4)));
        }
        conexion.Close();
        return nuevoCadete;
    }

    //Pedidos
    public List<Pedido>DevolverListadoPedidos()
    {
        List<Pedido> listado = new List<Pedido>();
        conexion.Open();
        SqliteCommand select = new SqliteCommand("SELECT * FROM Pedidos", conexion);
        var query = select.ExecuteReader();
        while (query.Read())
        {
            Pedido  nuevoPedido= new Pedido(query.GetInt32(0), query.GetString(1), query.GetInt32(2),query.GetString(3), query.GetInt32(4));
            listado.Add(nuevoPedido);
        }
        conexion.Close();
        return listado;
    }

    public void subirPedidosBD(Pedido pedido)
    {
        conexion.Open();
        SqliteCommand insertar = new SqliteCommand("INSERT INTO Pedidos (Obs, Cliente, Estado, Id_cadete) VALUES (@obs, @cli, @est, @id)", conexion);
        insertar.Parameters.AddWithValue("@obs", pedido.Obs);
        insertar.Parameters.AddWithValue("@cli", pedido.Cliente);
        insertar.Parameters.AddWithValue("@est", pedido.Estado);
        insertar.Parameters.AddWithValue("@id", pedido.id_cadete);
        try
        {
            insertar.ExecuteReader();
            conexion.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            conexion.Close();
        }
    }
}