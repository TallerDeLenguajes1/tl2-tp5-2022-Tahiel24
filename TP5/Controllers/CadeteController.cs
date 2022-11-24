using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP5.Models;
using Microsoft.Extensions.Logging;
using TP5.ViewModels;
using AutoMapper;
using TP5.Repositorios;

public class CadeteController : Controller
{
    private readonly ILogger<CadeteController> _logger;
    private readonly IMapper _mapper;
    private readonly ICadeteRepository _cadeteRepository;

    public CadeteController(ILogger<CadeteController> logger, IMapper mapper, ICadeteRepository cadeteRepo)
    {
        _logger = logger;
        _mapper = mapper;
        _cadeteRepository=cadeteRepo;
    }

    public IActionResult CadeteRecibir()
    {
        return View();
    }

    public IActionResult MostrarCadetesPrincipal()
    {
        return View(_cadeteRepository.DevolverTodo());
    }


    [HttpGet]
    public RedirectToActionResult EliminarCadetes(string Id)
    {
        int idC = Convert.ToInt32(Id);
        FuncionesDB funciones = new FuncionesDB();
        funciones.EliminarDatosBD(idC);
        return RedirectToAction("MostrarCadetesPrincipal");
    }

    [HttpPost]
    public RedirectToActionResult AgregarCadetes(CadetesViewModels cadeteView)
    {
        if (ModelState.IsValid)
        {
            Cadete nuevoCadete = _mapper.Map<Cadete>(cadeteView);
            FuncionesDB funciones = new FuncionesDB();
            funciones.SubirDatosBD(nuevoCadete);
        }

        return RedirectToAction("MostrarCadetesPrincipal");
    }

    [HttpPost]
    public RedirectToActionResult EditCad(CadetesViewModels cadeteView)
    {
        if (ModelState.IsValid)
        {
            Cadete cadeteEditado = _mapper.Map<Cadete>(cadeteView);
            FuncionesDB funciones = new FuncionesDB();
            funciones.EditarCadetes(cadeteEditado);
            return RedirectToAction("MostrarCadetesPrincipal");
        }
        else
        {
            return RedirectToAction("Error");
        }


    }

    [HttpGet]
    [Route("/Cadete/EditarCadetes/{Id}")]
    public IActionResult EditarCadetes(string Id)
    {
        int idC = Convert.ToInt32(Id);
        FuncionesDB funciones = new FuncionesDB();
        Cadete nuevoCadete = funciones.DevolverCadetePorId(idC);
        CadetesViewModels cadeteView = _mapper.Map<CadetesViewModels>(nuevoCadete);
        return View(cadeteView);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
