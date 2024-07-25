using Application.Interfaces;
using Application.Requests;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ClientesController(IClienteService clienteService) : ControllerBase
{
    [HttpPost]
    public IActionResult CadastrarCliente([FromBody] ClienteRequest request)
    {
        var result = clienteService.CadastrarCliente(request);
        return CreatedAtAction(nameof(ObterClientePorId), new { id = result.Id }, result);
    }

    [HttpGet("{id}")]
    public IActionResult ObterClientePorId(int id)
    {
        var cliente = clienteService.ObterClientePorId(id);

        if (cliente == null) return NotFound();

        return Ok(cliente);
    }
}