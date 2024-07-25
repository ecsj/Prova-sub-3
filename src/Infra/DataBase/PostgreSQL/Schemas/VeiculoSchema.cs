using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.DataBase.PostgreSQL.Schemas;

internal static class VeiculoSchema
{
    public static void ConfigureVeiculoSchema(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<Veiculo>(veiculo =>
        {
            veiculo.HasKey(x => x.Id);

            veiculo.Property(x => x.Marca)
                .IsRequired()
                .HasMaxLength(50);

            veiculo.Property(x => x.Modelo)
                .IsRequired()
                .HasMaxLength(50);

            veiculo.Property(x => x.Ano)
                .IsRequired();

            veiculo.Property(x => x.Cor)
                .IsRequired()
                .HasMaxLength(20);

            veiculo.Property(x => x.Preco)
                .IsRequired();

            veiculo.HasOne(x => x.Estoque)
                .WithOne(x => x.Veiculo)
                .HasForeignKey<Estoque>(x => x.VeiculoId)
                .OnDelete(DeleteBehavior.Cascade);
        });
}