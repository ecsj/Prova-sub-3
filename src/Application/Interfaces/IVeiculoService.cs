using Application.Requests;
using Domain.Entities;

namespace Application.Interfaces;

public interface IVeiculoService
{
    Veiculo CadastrarVeiculo(VeiculoRequest request);
    void EditarVeiculo(int veiculoId, VeiculoUpdateRequest request);
    void VenderVeiculo(int veiculoId, int clienteId);
    Veiculo ObterVeiculoPorId(int id);
    List<Veiculo> ListarTodosVeiculos();
    List<Veiculo> ListarVeiculosDisponiveis();
}