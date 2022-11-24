using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
namespace TP5.ViewModels;

public class PedidosViewModels
{
    public int Nro { get; set; }

    [Required][StringLength(100)][Display(Name="Observaciones del Pedido")]
    public string Obs{ get; set;}

    [Required][Display(Name="IDCliente del Pedido")]
    public int Cliente {get;set;}

    [Required]
    public int id_cadete{get; set;}

    [Required][StringLength(100)][Display(Name ="Estado del pedido")]
    public string EstadoNuevo{get; set;}

    public PedidosViewModels(int nroPed,string obs, int idCliente,string est, int id_cad){
        Nro = nroPed;
        Obs = obs;
        Cliente = idCliente;
        EstadoNuevo = est;
        id_cadete=id_cad;
    }

    public PedidosViewModels(string obs, int idCliente,string est, int id_cad)
    {
        Obs = obs;
        Cliente = idCliente;
        EstadoNuevo = est;
        id_cadete=id_cad;
    }


    public PedidosViewModels()
    {

    }
}