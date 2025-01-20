using LanControl.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace LanControl.Core.Database.Configuration;

public class PreferencesConfiguration : IEntityTypeConfiguration<Preferences>
{
    public void Configure(EntityTypeBuilder<Preferences> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);
        entityBuilder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();
        
    }    
}