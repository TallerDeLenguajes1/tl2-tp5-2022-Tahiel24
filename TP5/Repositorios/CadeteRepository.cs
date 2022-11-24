using TP5.ViewModels;
using Microsoft.Data.Sqlite;

public interface ICadeteRepository
{
    List<Cadete>DevolverTodo();
    List<int>DevolverIDCadetes();
    void Subir(Cadete cadete);
    void Eliminar(int id);
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
}