using Domain.Entities;

namespace Domain.Repositories;

public interface IVeiculoRepository
{
    void Adicionar(Veiculo veiculo);
    void Atualizar(Veiculo veiculo);
    Veiculo ObterPorId(int id);
    List<Veiculo> ListarDisponiveis();
    List<Veiculo> ListarTodos();
}