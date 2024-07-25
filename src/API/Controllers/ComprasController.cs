using Application.Interfaces;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ComprasController(ICompraService compraService) : ControllerBase
{
    [HttpPost]
    public IActionResult RegistrarCompra(int clienteId, int veiculoId)
    {
        compraService.RegistrarCompra(clienteId, veiculoId);
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult ObterCompraPorId(int id)
    {
        var compra = compraService.ObterCompraPorId(id);
        return Ok(compra);
    }

    [HttpGet("cliente/{clienteId}")]
    public IActionResult ObterComprasPorClienteId(int clienteId)
    {
        var compras = compraService.ObterComprasPorClienteId(clienteId);
        return Ok(compras);
    }
    [HttpGet]
    public IActionResult ObterTodasCompras([FromQuery] OrderBy orderDirection)
    {
        var compras = compraService.ObterTodasCompras(orderDirection);
        return Ok(compras);
    }
}