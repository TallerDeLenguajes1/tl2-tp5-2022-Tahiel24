using TP5.ViewModels;
using Microsoft.Data.Sqlite;
using TP5.Models;
namespace TP5.Repositorios;

public interface ICadeteRepository
{
    List<Cadete>DevolverTodo();
    List<int>DevolverIDCadetes();
    void Subir(Cadete cadete);
    void Eliminar(int ID);
    void Editar(Cadete cadete);
    Cadete RetornaCadetePorID(int ID);
}

public class CadeteRepository: ICadeteRepository
{
    private string connectionString;
    public CadeteRepository()
    {
        connectionString= $"Data Source=BD/PedidosDB";
    }

    public List<Cadete>DevolverTodo(){
        List<Cadete> listado = new List<Cadete>();
        SqliteConnection conexion = new SqliteConnection(connectionString);
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

    public List<int>DevolverIDCadetes(){
        List<int> listaID = new List<int>();
        SqliteConnection conexion = new SqliteConnection(connectionString);
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

    public void Subir(Cadete cadete){
        SqliteConnection conexion = new SqliteConnection(connectionString);
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

    public void Eliminar(int ID){
        SqliteConnection conexion = new SqliteConnection(connectionString);
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

    public void Editar(Cadete cadete){
        SqliteConnection conexion = new SqliteConnection(connectionString);
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

    public Cadete RetornaCadetePorID(int ID){
        SqliteConnection conexion = new SqliteConnection(connectionString);
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
}