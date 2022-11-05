namespace TP5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP5.ViewModels;


public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string Telefono;

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono1 { get => Telefono; set => Telefono = value; }

    public Cadete(int id, string nom, string direc, string tel)
    {
        Id = id;
        Nombre = nom;
        Direccion = direc;
        Telefono1 = tel;
    }

    public Cadete()
    {
        
    }
}

class Pedido
{
    private int nro;
    private string obs;
    private string cliente;
    private int estado;
    private string dir;

    public int Nro { get => nro; set => nro = value; }
    public string Obs { get => obs; set => obs = value; }
    public int Estado { get => estado; set => estado = value; }
    public string Cliente { get => cliente; set => cliente = value; }
    public string Dir { get => dir; set => dir = value; }

    string[] obsA = { "Sin sal", "Agregar Aderezo", "Sin Ketchup", "Agrandar pedido de papas", "Extra carne" };
    Random r = new Random();

    public Pedido(string Nom, string dirN)
    {
        Nro = r.Next(0, 101);
        Obs = obsA[r.Next(0, 5)];
        //El estado sera: 0:entregado, 1:No entregado
        Estado = r.Next(0, 2);
        Cliente = Nom;
        Dir = dirN;
    }
}


