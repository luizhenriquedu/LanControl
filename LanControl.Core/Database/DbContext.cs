using Config.Net;
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
        optionsBuilder.UseSqlite(config.DatabaseConnectionString);
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().Property(x => x.Id).ValueGeneratedOnAdd();
        base.OnModelCreating(modelBuilder);
    }
}