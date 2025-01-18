using Config.Net;
using LanControl.Core.Database.Configuration;
using LanControl.Core.Errors;
using LanControl.Core.Models;
using LanControl.Shared.ViewModels.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanControl.Core.Database;

public class DatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder<IConfig>().UseEnvironmentVariables().UseDotEnvFile().Build();
        if (config.DatabaseConnectionString is null) throw new DatabaseError("CONNECTION_STRING_NOT_PROVIDED");
        optionsBuilder.UseSqlite(config.DatabaseConnectionString);
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}