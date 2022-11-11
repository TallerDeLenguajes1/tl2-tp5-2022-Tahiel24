using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP5.Models;
using Microsoft.Extensions.Logging;
using TP5.ViewModels;
using AutoMapper;

public class CadeteController : Controller
{
    private readonly ILogger<CadeteController> _logger;
    private readonly IMapper _mapper;

    public CadeteController(ILogger<CadeteController> logger, IMapper mapper)
    {
        _logger = logger;
        _mapper=mapper;
    }

    public IActionResult CadeteRecibir()
    {  
        return View();
    }

    public IActionResult MostrarCadetesPrincipal()
    {
        FuncionesDB funciones= new FuncionesDB();
        List<Cadete>listaCadetes=new List<Cadete>();
        listaCadetes=funciones.DevolverListadoCadetes();
        return View(listaCadetes);
    }

    public IActionResult IntermedioBorrar()
    {
        Ayuda nuevaAyuda=new Ayuda();
        List<Cadete>listaCadetes=new List<Cadete>();
        listaCadetes=nuevaAyuda.DevolverCadetes();
        return View(listaCadetes);
    }
    
    [HttpGet]
    public RedirectToActionResult EliminarCadetes(string Id)
    {   
        int idC=Convert.ToInt32(Id);
        Ayuda nuevaAyuda=new Ayuda();
        nuevaAyuda.EliminarCadetes(idC);
        return RedirectToAction("MostrarCadetesPrincipal");
    }

    [HttpPost]
    public RedirectToActionResult AgregarCadetes(CadetesViewModels cadeteView)
    {
        if(ModelState.IsValid){
            Cadete nuevoCadete= _mapper.Map<Cadete>(cadeteView);
            FuncionesDB funciones=new FuncionesDB();
            funciones.SubirDatosBD(nuevoCadete);
        }
        
        return RedirectToAction("MostrarCadetesPrincipal");
    }

    [HttpPost]
    public RedirectToActionResult EditCad(CadetesViewModels cadeteView)
    {
        if(ModelState.IsValid){
           Cadete cadeteEditado=_mapper.Map<Cadete>(cadeteView);
           Ayuda nuevaAyuda=new Ayuda();
           nuevaAyuda.EscribirEnCSV(cadeteEditado);
           return RedirectToAction("MostrarCadetesPrincipal");
        }else{
            return RedirectToAction("Error");
        }
        
        
    }

    [HttpGet]
    [Route("/Cadete/EditarCadetes/{Id}")]    
    public IActionResult EditarCadetes(string Id)
    {
        int idC=Convert.ToInt32(Id);
        Ayuda nuevaAyuda=new Ayuda();
        Cadete nuevoCadete=nuevaAyuda.devolverCadetePorID(Id);
        CadetesViewModels cadeteView=_mapper.Map<CadetesViewModels>(nuevoCadete);
        return View(cadeteView);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
