using TP5.ViewModels;
using Microsoft.Data.Sqlite;
using TP5.Models;
namespace TP5.Repositorios;

public interface IPedidoRepository
{
    List<Pedido>DevolverTodo();
    Pedido DevolverPedidoPorId(int ID);
    void Editar(Pedido pedido);
    void Eliminar(int ID);
    void Subir(Pedido pedido);
    
}

public class PedidoRepository: IPedidoRepository
{
    private string connectionString;

    public PedidoRepository()
    {
        connectionString= $"Data Source=BD/PedidosDB";
    }

    public List<Pedido>DevolverTodo()
    {
        SqliteConnection conexion = new SqliteConnection(connectionString);
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

    public Pedido DevolverPedidoPorId(int ID)
    {
        SqliteConnection conexion = new SqliteConnection(connectionString);
        conexion.Open();
        SqliteCommand select= new SqliteCommand("SELECT * FROM Pedidos WHERE Nro = @id", conexion);
        select.Parameters.AddWithValue("@id", ID);
        Pedido nuevoPedido= new Pedido();
        var query= select.ExecuteReader();
        while(query.Read())
        {
            nuevoPedido = new Pedido(query.GetInt32(0), query.GetString(1), query.GetInt32(2), query.GetString(3), query.GetInt32(4));
        }
        conexion.Close();
        return nuevoPedido;
    }

    public void Editar(Pedido pedido)
    {
        SqliteConnection conexion = new SqliteConnection(connectionString);
        conexion.Open();
        SqliteCommand insertar = new SqliteCommand("UPDATE Pedidos SET Obs = @obs, Cliente = @cli, Estado = @est, Id_cadete = @id_cad WHERE Nro = @num", conexion);
        insertar.Parameters.AddWithValue("@num", pedido.Nro);
        insertar.Parameters.AddWithValue("@obs", pedido.Obs);
        insertar.Parameters.AddWithValue("@cli", pedido.Cliente);
        insertar.Parameters.AddWithValue("@est", pedido.EstadoNuevo);
        insertar.Parameters.AddWithValue("@id_cad", pedido.id_cadete);
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

    public void Eliminar(int ID)
    {
        SqliteConnection conexion = new SqliteConnection(connectionString);
        conexion.Open();
        SqliteCommand delete = new SqliteCommand("DELETE FROM Pedidos WHERE Nro = @id", conexion);
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

    public  void Subir(Pedido pedidoSubir)
    {
        SqliteConnection conexion = new SqliteConnection(connectionString);
        conexion.Open();
        SqliteCommand insertar = new SqliteCommand("INSERT INTO Pedidos (Obs, Cliente, Estado, Id_cadete) VALUES (@obs, @cli, @est, @id_cad)", conexion);
        insertar.Parameters.AddWithValue("@obs", pedidoSubir.Obs);
        insertar.Parameters.AddWithValue("@cli", pedidoSubir.Cliente);
        insertar.Parameters.AddWithValue("@est", pedidoSubir.EstadoNuevo);
        insertar.Parameters.AddWithValue("@id_cad", pedidoSubir.id_cadete);
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