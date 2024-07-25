using Application.Interfaces;
using Application.Requests;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class VeiculosController(IVeiculoService veiculoService) : ControllerBase
{
    [HttpPost]
    public IActionResult CadastrarVeiculo([FromBody] VeiculoRequest veiculo)
    {
        var result = veiculoService.CadastrarVeiculo(veiculo);
        return CreatedAtAction(nameof(ObterVeiculoPorId), new { id = result.Id }, result);
    }

    [HttpPatch("{id}")]
    public IActionResult EditarVeiculo(int id, [FromBody] VeiculoUpdateRequest request)
    {
        veiculoService.EditarVeiculo(id, request);
        return NoContent();
    }

    [HttpPost("vender/{veiculoId}/{clienteId}")]
    public IActionResult VenderVeiculo(int veiculoId, int clienteId)
    {
        veiculoService.VenderVeiculo(veiculoId, clienteId);
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult ObterVeiculoPorId(int id)
    {
        var veiculo = veiculoService.ObterVeiculoPorId(id);
        return Ok(veiculo);
    }

    [HttpGet("todos")]
    public IActionResult ListarTodosVeiculos()
    {
        var veiculos = veiculoService.ListarTodosVeiculos();
        return Ok(veiculos);
    }
    [HttpGet("disponiveis")]
    public IActionResult ListarVeiculosDisponiveis()
    {
        var veiculos = veiculoService.ListarVeiculosDisponiveis();
        return Ok(veiculos);
    }
}