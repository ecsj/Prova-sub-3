using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.DataBase.PostgreSQL.Repositories;

public class CompraRepository(ApplicationDbContext context) : ICompraRepository
{

    public void Adicionar(Compra compra)
    {
        context.Compras.Add(compra);
        context.SaveChanges();
    }

    public Compra ObterPorId(int id)
    {
        return context.Compras.Find(id);
    }

    public List<Compra> ObterComprasPorClienteId(int clienteId)
    {
        return context.Compras.Where(c => c.ClienteId == clienteId).ToList();
    }

    public List<Compra> ObterTodasCompras(OrderBy orderDirection)
    {
        var query = context.Compras.AsQueryable();
            
        query = orderDirection == OrderBy.Desc ? query.OrderByDescending(x => x.ValorCompra) : query.OrderBy(x => x.ValorCompra);

        query = query.Include(x => x.Cliente).Include(x => x.Veiculo).ThenInclude(x => x.Estoque);

        return query.ToList();
    }
}