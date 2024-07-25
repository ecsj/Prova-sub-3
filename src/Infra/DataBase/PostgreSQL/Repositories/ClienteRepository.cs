using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.DataBase.PostgreSQL.Repositories;

public class ClienteRepository(ApplicationDbContext context) : IClienteRepository
{
    public Cliente Adicionar(Cliente? cliente)
    {
        context.Clientes.Add(cliente);
        context.SaveChanges();

        return cliente;
    }

    public Cliente? ObterPorId(int id)
    {
        return context.Clientes.Where(x => x.Id == id)
            .Include(x => x.Compras)
            .ThenInclude(x => x.Veiculo)
            .FirstOrDefault();
    }
}