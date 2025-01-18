using LanControl.Shared.ViewModels.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Config.Net;
namespace LanControl.Core.Database;

public class DesignDatabaseContext : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
        var config = new ConfigurationBuilder<IConfig>().UseEnvironmentVariables().UseDotEnvFile().Build();
        optionsBuilder.UseSqlite($"Data Source={config.DatabaseConnectionString}");
        return new DatabaseContext(optionsBuilder.Options);
    }
}