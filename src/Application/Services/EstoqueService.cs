using Application.Interfaces;
using Domain.Exceptions;
using Domain.Repositories;

namespace Application.Services;

public class EstoqueService(IEstoqueRepository estoqueRepository, IVeiculoRepository veiculoRepository) : IEstoqueService
{

    public void IncrementarEstoque(int veiculoId, int quantidade)
    {
        var veiculo = veiculoRepository.ObterPorId(veiculoId);
        if (veiculo == null)
        {
            throw new EstoqueException("Veículo não encontrado.");
        }
        veiculo.IncrementarEstoque(quantidade);
        estoqueRepository.Atualizar(veiculo.Estoque);
    }

    public void DecrementarEstoque(int veiculoId, int quantidade)
    {
        var veiculo = veiculoRepository.ObterPorId(veiculoId);
        if (veiculo == null)
        {
            throw new EstoqueException("Veículo não encontrado.");
        }
        veiculo.Estoque.DecrementarEstoque(quantidade);
        estoqueRepository.Atualizar(veiculo.Estoque);
    }

    public int ObterQuantidadeEstoque(int veiculoId)
    {
        var estoque = estoqueRepository.ObterPorVeiculoId(veiculoId);
        if (estoque == null)
        {
            throw new EstoqueException("Veículo não encontrado.");
        }
        return estoque.Quantidade;
    }
}