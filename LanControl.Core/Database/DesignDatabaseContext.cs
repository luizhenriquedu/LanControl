using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using TakasakiStudio.Lina.Database;
using TakasakiStudio.Lina.Database.Context;

namespace LanControl.Core.Database;

public class DesignDatabaseContext : IDesignTimeDbContextFactory<LinaDbContext>
{
    public LinaDbContext CreateDbContext(string[] args)
    
    {  
        var serviceBuilder = new ServiceCollection(); 

        serviceBuilder.AddLinaDbContext<DesignDatabaseContext>((optionsBuilder, assembly) =>
        {
            optionsBuilder.UseSqlite($"Data Source=./Database/Database.db", options =>
            {
                options.MigrationsAssembly(assembly);
            });
        });

        var di = serviceBuilder.BuildServiceProvider();
        return di.GetRequiredService<LinaDbContext>();
    }
}