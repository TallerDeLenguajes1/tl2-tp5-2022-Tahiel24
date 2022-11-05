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
        Ayuda nuevaAyuda=new Ayuda();
        List<Cadete>listaCadetes=new List<Cadete>();
        listaCadetes=nuevaAyuda.DevolverCadetes();
        return View(listaCadetes);
    }

    public IActionResult IntermedioBorrar()
    {
        Ayuda nuevaAyuda=new Ayuda();
        List<Cadete>listaCadetes=new List<Cadete>();
        listaCadetes=nuevaAyuda.DevolverCadetes();
        return View(listaCadetes);
    }
    
    [HttpPost]
    public RedirectToActionResult EliminarCadetes(int Id)
    {   
        Ayuda nuevaAyuda=new Ayuda();
        nuevaAyuda.EliminarCadetes(Id);
        return RedirectToAction("MostrarCadetesPrincipal");
    }

    [HttpPost]
    public RedirectToActionResult AgregarCadetes(CadetesViewModels cadeteView)
    {
        if(ModelState.IsValid){
            Cadete nuevoCadete= _mapper.Map<Cadete>(cadeteView);
            Ayuda nuevaAyuda=new Ayuda();
            nuevaAyuda.GuardarCadete(nuevoCadete);
        }
        
        return RedirectToAction("MostrarCadetesPrincipal");
    }

    [HttpPost]
    
    public RedirectToActionResult EditarCadetes(CadetesViewModels cadeteView)
    {
        if(ModelState.IsValid){
            Cadete nuevoCadete= _mapper.Map<Cadete>(cadeteView);
            Ayuda nuevaAyuda=new Ayuda();
            nuevaAyuda.EditarCadetes(nuevoCadete);
        }
        
        return RedirectToAction("MostrarCadetesPrincipal");
    }

    [HttpGet]
    [Route("/Cadete/EditarCadetes/{Id}")]    
    public RedirectToActionResult EditarCadetes(string Id)
    {
        
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
