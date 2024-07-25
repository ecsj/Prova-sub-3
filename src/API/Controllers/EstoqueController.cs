using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EstoqueController(IEstoqueService estoqueService) : ControllerBase
{
    [HttpPost("incrementar/{veiculoId}/{quantidade}")]
    public IActionResult IncrementarEstoque(int veiculoId, int quantidade)
    {
        estoqueService.IncrementarEstoque(veiculoId, quantidade);
        return Ok();
    }

    [HttpPost("decrementar/{veiculoId}/{quantidade}")]
    public IActionResult DecrementarEstoque(int veiculoId, int quantidade)
    {
        estoqueService.DecrementarEstoque(veiculoId, quantidade);
        return Ok();
    }

    [HttpGet("{veiculoId}")]
    public IActionResult ObterQuantidadeEstoque(int veiculoId)
    {
        var quantidade = estoqueService.ObterQuantidadeEstoque(veiculoId);
        return Ok(quantidade);
    }
}