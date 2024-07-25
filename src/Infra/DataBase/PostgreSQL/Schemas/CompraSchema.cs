using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.DataBase.PostgreSQL.Schemas;

internal static class CompraSchema
{
    public static void ConfigureCompraSchema(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<Compra>(compra =>
        {
            compra.HasKey(x => x.Id);

            compra.Property(x => x.DataCompra)
                .IsRequired();

            compra.HasOne(x => x.Cliente)
                .WithMany(x => x.Compras)
                .HasForeignKey(x => x.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            compra.HasOne(x => x.Veiculo)
                .WithMany()
                .HasForeignKey(x => x.VeiculoId)
                .OnDelete(DeleteBehavior.Restrict);
        });
}