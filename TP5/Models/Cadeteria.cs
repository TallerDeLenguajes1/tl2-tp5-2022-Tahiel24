namespace TP5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP5.ViewModels;

public class Cadeteria
{
    public int id_Cadeteria{get; set;}
    public string Nombre{get; set;}
    public Cadeteria(int id, string nom)
    {
        id_Cadeteria=id;
        Nombre=nom;
    }

    public Cadeteria()
    {
        
    }
}