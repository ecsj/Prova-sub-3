using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infra.DataBase.PostgreSQL.Schemas;

internal static class ClienteSchema
{
    public static void ConfigureClienteSchema(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<Cliente>(cliente =>
        {
            cliente.HasKey(x => x.Id);

            cliente.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100);

            cliente.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);

            cliente.Property(x => x.Telefone)
                .IsRequired()
                .HasMaxLength(15);

            cliente.HasMany(x => x.Compras)
                .WithOne(x => x.Cliente)
                .HasForeignKey(x => x.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);
        });
}