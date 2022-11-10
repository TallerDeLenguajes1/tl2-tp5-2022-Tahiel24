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

public class CadeteListado
{
    public List<Cadete> listadoCadete {get; set;}
    public CadeteListado()
    {
        Ayuda nuevaAyuda= new Ayuda();
        listadoCadete=nuevaAyuda.DevolverCadetes();
    }

    public Cadete devolverCadetePorID(string id){
        int ID=Convert.ToInt32(id);
        List<Cadete>listado=new List<Cadete>();
        Ayuda nuevaAyuda=new Ayuda();
        listado=nuevaAyuda.DevolverCadetes();
        IEnumerable<Cadete> busqueda=from d in listado where d.Id==ID select d; 
        List<Cadete> asList= busqueda.ToList();
        Cadete nuevo=asList[0];
        return nuevo;
    }
}



