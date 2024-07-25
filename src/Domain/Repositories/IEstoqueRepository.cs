using Domain.Entities;

namespace Domain.Repositories;

public interface IEstoqueRepository
{
    void Adicionar(Estoque? estoque);
    void Atualizar(Estoque? estoque);
    Estoque? ObterPorVeiculoId(int veiculoId);
}