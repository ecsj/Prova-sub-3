using Application.Interfaces;
using Application.Responses;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Repositories;

namespace Application.Services;

public class CompraService(ICompraRepository compraRepository, IVeiculoRepository veiculoRepository,
        IClienteRepository clienteRepository)
    : ICompraService
{
    public void RegistrarCompra(int clienteId, int veiculoId)
    {
        var veiculo = veiculoRepository.ObterPorId(veiculoId);
        if (veiculo == null)
        {
            throw new VeiculoException("Veículo não encontrado.");
        }

        var cliente = clienteRepository.ObterPorId(clienteId);
        if (cliente == null)
        {
            throw new ClienteException("Cliente não encontrado.");
        }

        var compra = new Compra(clienteId, veiculoId, veiculo.Preco);
        veiculo.Estoque.DecrementarEstoque(1);

        compraRepository.Adicionar(compra);
        veiculoRepository.Atualizar(veiculo);
    }

    public Compra ObterCompraPorId(int id)
    {
        return compraRepository.ObterPorId(id);
    }

    public List<Compra> ObterComprasPorClienteId(int clienteId)
    {
        return compraRepository.ObterComprasPorClienteId(clienteId);
    }
    public List<CompraResponse> ObterTodasCompras(OrderBy orderDirection)
    {
        var compras = compraRepository.ObterTodasCompras(orderDirection);

        var response = compras.Select(x => new CompraResponse(x)).ToList();

        return response;
    }
}