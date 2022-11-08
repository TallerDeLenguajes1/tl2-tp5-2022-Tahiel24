namespace TP5.Models;
using TP5.ViewModels;
using System;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using System.Web;


class Ayuda
{
    public Ayuda()
    {
        
    }

    public List<Cadete> DevolverCadetes()
    {
        List<Cadete> ListadoCadetes = new List<Cadete>();
        string[] lineas = File.ReadAllLines(@"CSV\Cadetes.csv");

        foreach (var i in lineas)
        {
            string[] fila = i.Split(",");
            int num = Convert.ToInt32(fila[0]);
            Cadete nuevoCadete = new Cadete(num, fila[1], fila[2], fila[3]);
            ListadoCadetes.Add(nuevoCadete);
        }

        return ListadoCadetes;
    }

    public void GuardarCadete(Cadete cadete){
        string path= @"CSV\Cadetes.csv";
        List<string>cadena=new List<string>();
        cadena.Add(cadete.Id+","+cadete.Nombre+","+cadete.Direccion+","+cadete.Telefono1);
        File.AppendAllLines(path,cadena);
    }

    public void EliminarCadetes(int id){
        string path= @"C:\TALLER 2\tl2-tp5-2022-Tahiel24\TP5\CSV\Cadetes.csv";
        List<string>ListaCadenas=new List<string>();
        string[] contenidoActual = File.ReadAllLines(path);
        File.Delete(path);
        /*
        string cadena1=cadete.Id+","+cadete.Nombre+","+cadete.Direccion+","+cadete.Telefono1;*/
        string cadena2;
        for (int i = 0; i <contenidoActual.Length; i++)
        {
            //Hacer un split de contenidoactual[i]
            //Tomar el primer casillero
            cadena2=contenidoActual[i];
            string[]lineaSeparada=contenidoActual[i].Split(",");
            int idC= Convert.ToInt32(lineaSeparada[0]);
            if(id==idC){
                continue;
            }else{
                ListaCadenas.Add(cadena2);
            }
        }
        File.AppendAllLines(path,ListaCadenas);
    }

    public void EliminarLinea(int id){
        string path=@"CSV/Cadetes.csv";
        List<Cadete> ListadoCadetes = new List<Cadete>();
        ListadoCadetes = DevolverCadetes();
        File.Delete(path);
        StreamWriter sw = new StreamWriter(path);
        foreach (var cad in ListadoCadetes)
        {
            if(cad.Id==id)
            {
                sw.WriteLine(cad.Id + "," + cad.Nombre + "," + cad.Direccion + "," + cad.Telefono1);
            }
        }
        sw.Close();
    }

    public void EscribirEnCSV(Cadete cadete){
        string path=@"C:\TALLER 2\tl2-tp5-2022-Tahiel24\TP5\CSV\Cadetes.csv";
        List<Cadete>listado=new List<Cadete>();
        List<string>listadoNuevo=new List<string>();
        listado=DevolverCadetes();
        File.Delete(path);
        foreach(var item in listado){
            if(cadete.Id==item.Id){
                listadoNuevo.Add(cadete.Id+","+cadete.Nombre+","+cadete.Direccion+","+cadete.Telefono1);
            }else{
                listadoNuevo.Add(item.Id+","+item.Nombre+","+item.Direccion+","+item.Telefono1);
            }
        }
        File.AppendAllLines(path,listadoNuevo);
    }

    public void EditarCadete(string cadena)
    {
        string path=@"CSV/Cadetes.csv";
        List<string>ListaCadenas=new List<string>();
        string[] contenidoActual = File.ReadAllLines(path);
        File.Delete(path);
        string[]cadenaSeparada= cadena.Split(",");
        int idC=Convert.ToInt32(cadenaSeparada[0]);
        for (int i = 0; i < contenidoActual.Length ; i++)
        {
            string[] lineSepar=contenidoActual[i].Split(",");
            int id=Convert.ToInt32(lineSepar[0]);
            if(idC==id){
                ListaCadenas.Add(cadenaSeparada[0]+","+cadenaSeparada[1]+","+cadenaSeparada[2]+","+cadenaSeparada[3]);
            }else{
                ListaCadenas.Add(lineSepar[0]+","+lineSepar[1]+","+lineSepar[2]+","+lineSepar[3]);
            }
        }
        File.AppendAllLines(path,ListaCadenas);
    }

    public Cadete devolverCadetePorID(string id){
        int ID=Convert.ToInt32(id);
        List<Cadete>listado=new List<Cadete>();
        listado=DevolverCadetes();
        IEnumerable<Cadete> busqueda=from d in listado where d.Id==ID select d; 
        List<Cadete> asList= busqueda.ToList();
        Cadete nuevo=asList[0];
        return nuevo;
    }
}

