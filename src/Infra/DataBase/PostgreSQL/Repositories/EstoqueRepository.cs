using Domain.Entities;
using Domain.Repositories;

namespace Infra.DataBase.PostgreSQL.Repositories;

public class EstoqueRepository(ApplicationDbContext context) : IEstoqueRepository
{
    public void Adicionar(Estoque? estoque)
    {
        context.Estoque.Add(estoque);
        context.SaveChanges();
    }

    public void Atualizar(Estoque? estoque)
    {
        context.Estoque.Update(estoque);
        context.SaveChanges();
    }

    public Estoque? ObterPorVeiculoId(int veiculoId)
    {
        return context.Estoque.FirstOrDefault(e => e.VeiculoId == veiculoId);
    }
}