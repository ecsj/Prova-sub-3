namespace Domain.Entities;

public class Compra
{
    public int Id { get; private set; }
    public int ClienteId { get; private set; }
    public Cliente Cliente { get; private set; }
    public int VeiculoId { get; private set; }
    public Veiculo Veiculo { get; private set; }
    public DateTime DataCompra { get; private set; }
    public decimal ValorCompra { get; private set; }

    public Compra(int clienteId, int veiculoId, decimal valorCompra)
    {
        ClienteId = clienteId;
        VeiculoId = veiculoId;
        DataCompra = DateTime.UtcNow;
        ValorCompra = valorCompra;
    }
}