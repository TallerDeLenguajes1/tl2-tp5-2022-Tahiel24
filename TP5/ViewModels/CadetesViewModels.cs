using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
namespace TP5.ViewModels;

public class CadetesViewModels
{
    //public int Id
    public int Id{get; set;}

    [Required]
    [StringLength(100)]
    [Display(Name = "Nombre del Cadete")]
    public string Nombre { get; set; }

    [Required]
    [StringLength(100)]
    [Display(Name = "Direccion del Cadete")]
    public string Direccion { get; set; }

    [Required]
    [StringLength(100)]
    [Display(Name = "Telefono del Cadete")]
    public string Telefono1 { get; set; }

    public int Id_Cadeteria{get; set;}


    public CadetesViewModels(int id, string nombre, string dire, string tel)
    {

        Nombre = nombre;
        Direccion = dire;
        Telefono1 = tel;
        Id = id;
    }

    public CadetesViewModels(int id, string nombre, string dire, string tel, int idCad){
        Nombre = nombre;
        Direccion = dire;
        Telefono1 = tel;
        Id = id;
        Id_Cadeteria=idCad;
    }

    public CadetesViewModels(string nombre, string dire, string tel, int idCad)
    {
        Nombre = nombre;
        Direccion = dire;
        Telefono1 = tel;
        Id_Cadeteria=idCad;
    }

    public CadetesViewModels()
    {
        
    }

}

