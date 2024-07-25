using Infra.DataBase.PostgreSQL;
using Microsoft.EntityFrameworkCore;

namespace API.Configurations;

public static class DataContextMigrations
{
    public static void ExecuteMigrations(this IServiceScope scope)
    {
        var applicationDataContext = scope.ServiceProvider.GetService<ApplicationDbContext>();

        if (applicationDataContext.Database.GetPendingMigrations().Any())
            applicationDataContext.Database.Migrate();
    }
}

