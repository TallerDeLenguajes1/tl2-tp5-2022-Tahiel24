namespace TP5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP5.ViewModels;

public class Pedido
{
    private int nro;
    private string obs;
    private int cliente;
    private bool estado;


    
    public int Nro { get => nro; set => nro = value; }
    public string Obs { get => obs; set => obs = value; }
    public int Cliente { get => cliente; set => cliente = value; }
    public bool Estado { get => estado; set => estado = value; }


    public Pedido(int nroPed,string obs, int idCliente,bool est)
    {
        Nro = nroPed;
        Obs = obs;
        Cliente = idCliente;
        Estado = true;

    }

    public Pedido()
    {

    }

    public void CambiarEstado()
    {
        Estado=false;
    }
}