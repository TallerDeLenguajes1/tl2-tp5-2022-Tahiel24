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

    public IActionResult mostrarPedidosPrincipal(){
        FuncionesDB funciones= new FuncionesDB();
        List<Pedido>listaPedido= funciones.DevolverListadoPedidos();
        return View(listaPedido);
    }

    [HttpPost]
    public RedirectToActionResult AgregarPedidos(PedidosViewModels pedidoView)
    {
        if(ModelState.IsValid){
            Pedido nuevoPedido= _mapper.Map<Pedido>(pedidoView);
            FuncionesDB funciones= new FuncionesDB();
            funciones.subirPedidosBD(nuevoPedido);
            return RedirectToAction("mostrarPedidosPrincipal");
        }else{
            return RedirectToAction("Error");
        }
        
        
    }

    public IActionResult AltaPedido()
    {
        return View();
    }

    [HttpGet]
    public RedirectToActionResult EliminarPedidos(string id)
    {
        int idC=Convert.ToInt32(id);
        AuxiliarPedido aux= new AuxiliarPedido();
        aux.EliminarPedidos(idC);
        return RedirectToAction("mostrarPedidosPrincipal");
    }
}