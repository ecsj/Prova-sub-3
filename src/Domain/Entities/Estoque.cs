using Domain.Exceptions;

namespace Domain.Entities;

public class Estoque
{
    public int Id { get; private set; }
    public int VeiculoId { get; private set; }
    public Veiculo Veiculo { get; private set; } = null!;
    public int Quantidade { get; private set; }

    public Estoque()
    {
        
    }
    public Estoque(Veiculo veiculo)
    {
        Veiculo = veiculo ?? throw new EstoqueException("Veículo não pode ser nulo.");

        VeiculoId = veiculo.Id;
        Quantidade = 0;
    }

    public void IncrementarEstoque(int quantidade)
    {
        if (quantidade <= 0) throw new EstoqueException("Quantidade deve ser maior que zero.");


        Quantidade += quantidade;
    }

    public void DecrementarEstoque(int quantidade)
    {
        if (quantidade <= 0) throw new EstoqueException("Quantidade deve ser maior que zero.");
        if (Quantidade < quantidade) throw new EstoqueException("Quantidade em estoque insuficiente.");


        Quantidade -= quantidade;
    }
}