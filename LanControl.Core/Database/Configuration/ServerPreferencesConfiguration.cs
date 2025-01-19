using LanControl.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace LanControl.Core.Database.Configuration;

public class ServerPreferencesConfiguration : IEntityTypeConfiguration<ServerPreferences>
{
    public void Configure(EntityTypeBuilder<ServerPreferences> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);
        entityBuilder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();
        
    }    
}