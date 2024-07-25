using Application.Interfaces;
using Application.Requests;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services;

public class ClienteService(IClienteRepository clienteRepository) : IClienteService
{
    public Cliente CadastrarCliente(ClienteRequest request)
    {
        var cliente = request.ToEntity();

        var result = clienteRepository.Adicionar(cliente);

        return result;
    }

    public Cliente? ObterClientePorId(int id)
    {
        var cliente = clienteRepository.ObterPorId(id);

        return cliente;
    }
}