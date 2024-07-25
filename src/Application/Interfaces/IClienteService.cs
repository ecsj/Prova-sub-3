using Application.Requests;
using Domain.Entities;

namespace Application.Interfaces;

public interface IClienteService
{
    Cliente CadastrarCliente(ClienteRequest? cliente);
    Cliente? ObterClientePorId(int id);
}