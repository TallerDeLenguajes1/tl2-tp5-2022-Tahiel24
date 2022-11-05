namespace TP5.Models;
using System;
using System.Collections.Generic;
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
        string[] lineas = File.ReadAllLines(@"C:\TALLER 2\tl2-tp4-2022-Tahiel24\TP4\CSV\Cadetes.csv");

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
        string path= @"C:\TALLER 2\tl2-tp4-2022-Tahiel24\TP4\CSV\Cadetes.csv";
        List<string>cadena=new List<string>();
        cadena.Add(cadete.Id+","+cadete.Nombre+","+cadete.Direccion+","+cadete.Telefono1);
        File.AppendAllLines(path,cadena);
    }

    public void EliminarCadetes(int id){
        string path= @"C:\TALLER 2\tl2-tp4-2022-Tahiel24\TP4\CSV\Cadetes.csv";
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
}

