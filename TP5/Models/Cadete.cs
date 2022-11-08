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




