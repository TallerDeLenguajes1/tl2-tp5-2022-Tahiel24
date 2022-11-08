using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
namespace TP5.ViewModels;

public class PedidosViewModels
{
    public int Nro { get; private set; }

    [Required][StringLength(100)][Display(Name="Observaciones del Pedido")]
    public string Obs{ get; set;}

    [Required][Display(Name="IDCliente del Pedido")]
    public int Cliente {get;set;}

    [Required][Display(Name="Cadete del Pedido")]
    public int Cadete {get;set;}

    public bool Estado {get;set;}

    public PedidosViewModels(int nro, string obs,int cliente, int cadete){
        Nro = nro;
        Obs = obs;
        Cliente = cliente;
        Cadete = cadete;
        Estado = true;
    }

    public PedidosViewModels(){
        string[]lineas=File.ReadAllLines(@"CSV/Pedidos.csv");
        if(lineas.Length==0)
        {
            this.Nro=0;
        }else{
            string[] lineaSeparada= lineas[lineas.Length-1].Split(",");
            this.Nro=(Convert.ToInt32(lineaSeparada[0]))+1;
        }
    }
}