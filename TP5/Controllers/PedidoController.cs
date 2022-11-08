using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP5.Models;
using Microsoft.Extensions.Logging;
using TP5.ViewModels;
using AutoMapper;

public class PedidoController: Controller
{
    private readonly ILogger<PedidoController> _logger;
    private readonly IMapper _mapper;

    public PedidoController(ILogger<PedidoController> logger, IMapper mapper)
    {
        _logger = logger;
        _mapper=mapper;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    
}