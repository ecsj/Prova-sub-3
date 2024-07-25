using Application.Interfaces;
using Application.Services;
using Domain.Repositories;
using Infra.DataBase.PostgreSQL;
using Infra.DataBase.PostgreSQL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Dependencies;

internal static class DependencyInjectionConfig
{
    public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
       services.AddDbContext<ApplicationDbContext>(
           builder => builder.UseNpgsql(configuration.GetConnectionString("PostgreeConnection"),
               builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<IVeiculoRepository, VeiculoRepository>();
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IEstoqueRepository, EstoqueRepository>();
        services.AddScoped<ICompraRepository, CompraRepository>();

        services.AddScoped<IVeiculoService, VeiculoService>();
        services.AddScoped<IClienteService, ClienteService>();
        services.AddScoped<IEstoqueService, EstoqueService>();
        services.AddScoped<ICompraService, CompraService>();
    }
}