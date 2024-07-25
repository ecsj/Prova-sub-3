using Domain.Entities;

namespace Application.Responses;
public class CompraResponse(Compra compra)
{
    public int Id { get;  set; }
    public int ClienteId { get;  set; } = compra.ClienteId;
    public string NomeCliente { get;  set; } = compra.Cliente.Nome;
    public int VeiculoId { get; set; } = compra.VeiculoId;
    public VeiculoResponse Veiculo { get;  set; } = new(compra.Veiculo);
    public DateTime DataCompra { get;  set; } = compra.DataCompra;
    public decimal ValorCompra { get; set; } = compra.ValorCompra;
}