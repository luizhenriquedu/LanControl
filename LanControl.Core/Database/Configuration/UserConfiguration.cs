using LanControl.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanControl.Core.Database.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entityBuilder)
    {
        entityBuilder.HasKey(x=>x.Id);
        entityBuilder.Property(x => x.Email).HasMaxLength(150).IsRequired();
        entityBuilder.Property(x => x.Name).HasMaxLength(150).IsRequired();
        entityBuilder.Property(x => x.PasswordHash).HasMaxLength(150).IsRequired();
    }
}