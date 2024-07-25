using Domain.Entities;
using Infra.DataBase.PostgreSQL.Schemas;
using Microsoft.EntityFrameworkCore;

namespace Infra.DataBase.PostgreSQL;

public class ApplicationDbContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Veiculo> Veiculos { get; set; }
    public DbSet<Estoque?> Estoque { get; set; }
    public DbSet<Compra> Compras { get; set; }



    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureClienteSchema();
        modelBuilder.ConfigureVeiculoSchema();
        modelBuilder.ConfigureEstoqueSchema();
        modelBuilder.ConfigureCompraSchema();
    }
}