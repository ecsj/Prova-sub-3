using Domain.Entities;

namespace Domain.Repositories;

public interface IClienteRepository
{
    Cliente Adicionar(Cliente? cliente);
    Cliente? ObterPorId(int id);
}