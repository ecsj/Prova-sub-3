using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.DataBase.PostgreSQL.Repositories;
public class VeiculoRepository(ApplicationDbContext context) : IVeiculoRepository
{
    public void Adicionar(Veiculo veiculo)
    {
        context.Veiculos.Add(veiculo);
        context.SaveChanges();
    }

    public void Atualizar(Veiculo veiculo)
    {
        context.Veiculos.Update(veiculo);
        context.SaveChanges();
    }

    public Veiculo ObterPorId(int id)
    {
        return context.Veiculos.Include(v => v.Estoque).FirstOrDefault(v => v.Id == id);
    }

    public List<Veiculo> ListarDisponiveis()
    {
        return context.Veiculos
            .Include(v => v.Estoque)
            .Where(v => v.Estoque.Quantidade > 0)
            .OrderBy(v => v.Preco)
            .ToList();
    }
    public List<Veiculo> ListarTodos()
    {
        return context.Veiculos
            .Include(v => v.Estoque)
            .OrderBy(v => v.Preco)
            .ToList();
    }
}