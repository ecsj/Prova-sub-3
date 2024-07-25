using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.DataBase.PostgreSQL.Schemas;

internal static class EstoqueSchema
{
    public static void ConfigureEstoqueSchema(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<Estoque>(estoque =>
        {
            estoque.HasKey(x => x.Id);

            estoque.Property(x => x.Quantidade)
                .IsRequired();
        });
}