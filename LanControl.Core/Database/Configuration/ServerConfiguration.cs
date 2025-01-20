using LanControl.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace LanControl.Core.Database.Configuration;

public class ServerConfiguration : IEntityTypeConfiguration<Server>
{
    public void Configure(EntityTypeBuilder<Server> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);
        entityBuilder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();
        
    }    
}