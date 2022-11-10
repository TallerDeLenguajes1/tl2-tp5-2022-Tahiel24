namespace TP5.Models;
using TP5.ViewModels;
using System;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using System.Web;

public class AuxiliarPedido{
    public AuxiliarPedido()
    {

    }

    public void AgregarPedido(Pedido pedido)
    {
        string path= @"CSV\Pedidos.csv";
        List<string>cadena=new List<string>();
        string cadenaN;
        cadenaN=pedido.Nro+","+pedido.Obs+","+pedido.Cliente+","+pedido.Estado;
        cadena.Add(cadenaN);
        File.AppendAllLines(path,cadena);
    }

    public List<Pedido> devolverListadoPedidos()
    {
        List<Pedido> ListadoPedidos = new List<Pedido>();
        string[] lineas = File.ReadAllLines(@"C:\TALLER 2\tl2-tp5-2022-Tahiel24\TP5\CSV\Pedidos.csv");

        foreach (var i in lineas)
        {
            string[] fila = i.Split(",");
            int num = Convert.ToInt32(fila[0]);
            int num2=Convert.ToInt32(fila[2]);
            if(fila[3]=="true"){
                Pedido nuevoPedido=new Pedido(num, fila[1], num2, true);
                ListadoPedidos.Add(nuevoPedido);
            }else{
                Pedido nuevoPedido=new Pedido(num, fila[1], num2, false);
                ListadoPedidos.Add(nuevoPedido);
            }
        }
        return ListadoPedidos;
    }

    public void EliminarPedidos(int id)
    {
        string path=@"CSV\Pedidos.csv";
        List<string>ListaCadenas=new List<string>();
        string[] contenidoActual = File.ReadAllLines(path);
        File.Delete(path);
        string cadena2;
        for (int i = 0; i <contenidoActual.Length; i++)
        {
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