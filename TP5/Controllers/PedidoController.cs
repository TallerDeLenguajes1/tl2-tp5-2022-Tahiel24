using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP5.Models;
using Microsoft.Extensions.Logging;
using TP5.ViewModels;
using AutoMapper;
using TP5.Repositorios;

public class PedidoController: Controller
{
    private readonly ILogger<PedidoController> _logger;
    private readonly IMapper _mapper;
    private readonly IPedidoRepository _pedidoRepository;

    public PedidoController(ILogger<PedidoController> logger, IMapper mapper, IPedidoRepository pedidoRepo)
    {
        _logger = logger;
        _mapper=mapper;
        _pedidoRepository=pedidoRepo;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult mostrarPedidosPrincipal(){
        return View(_pedidoRepository.DevolverTodo());
    }

    
    [HttpPost]
    public RedirectToActionResult AgregarPedidos(PedidosViewModels pedidoView)
    {
        if(ModelState.IsValid){
            Pedido nuevoPedido= _mapper.Map<Pedido>(pedidoView);
            _pedidoRepository.Subir(nuevoPedido);
        }

        return RedirectToAction("mostrarPedidosPrincipal");
        
        
    }

    public IActionResult AltaPedido()
    {
        return View();
    }

    [HttpGet]
    public RedirectToActionResult EliminarPedidos(string id)
    {
        int idC=Convert.ToInt32(id);
        _pedidoRepository.Eliminar(idC);
        return RedirectToAction("mostrarPedidosPrincipal");
    }

    [HttpGet]
    [Route("/Pedido/EditarPedidos/{Id}")]
    public IActionResult EditarPedidos(string id)
    {
        int idC = Convert.ToInt32(id);
        Pedido nuevoPedido=_pedidoRepository.DevolverPedidoPorId(idC);
        PedidosViewModels pedidosView=_mapper.Map<PedidosViewModels>(nuevoPedido);
        return View(pedidosView);
    }

    [HttpPost]
    public RedirectToActionResult EditPed(PedidosViewModels pedidoView)
    {
        if(ModelState.IsValid){
            Pedido pedidoEditado= _mapper.Map<Pedido>(pedidoView);
            _pedidoRepository.Editar(pedidoEditado);
            return RedirectToAction("mostrarPedidosPrincipal");
        }else{
            return RedirectToAction("Error");
        }
    }
}