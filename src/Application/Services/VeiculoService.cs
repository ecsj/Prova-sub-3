using Application.Interfaces;
using Application.Requests;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;

namespace Application.Services;

public class VeiculoService(IVeiculoRepository veiculoRepository, IClienteService clienteService) : IVeiculoService
{
    public Veiculo CadastrarVeiculo(VeiculoRequest request)
    {
        var veiculo = request.ToEntity();

        veiculoRepository.Adicionar(veiculo);

        return veiculo;
    }

    public void EditarVeiculo(int veiculoId, VeiculoUpdateRequest request)
    {
        var veiculo = veiculoRepository.ObterPorId(veiculoId);
        if (veiculo == null)
        {
            throw new VeiculoException("Veículo não encontrado.");
        }

        veiculo.Editar(request.Marca, request.Modelo, request.Ano, request.Cor, request.Preco);
        veiculoRepository.Atualizar(veiculo);
    }

    public void VenderVeiculo(int veiculoId, int clienteId)
    {
        var veiculo = veiculoRepository.ObterPorId(veiculoId);
        if (veiculo == null)
        {
            throw new VeiculoException("Veículo não encontrado.");
        }

        var cliente = clienteService.ObterClientePorId(clienteId);
        veiculo.VenderPara(cliente);
        veiculoRepository.Atualizar(veiculo);
    }

    public Veiculo ObterVeiculoPorId(int id)
    {
        var veiculo = veiculoRepository.ObterPorId(id);
        if (veiculo == null)
        {
            throw new VeiculoException("Veículo não encontrado.");
        }
        return veiculo;
    }

    public List<Veiculo> ListarVeiculosDisponiveis()
    {
        return veiculoRepository.ListarDisponiveis();
    }

    public List<Veiculo> ListarTodosVeiculos()
    {
        return veiculoRepository.ListarTodos();
    }
}