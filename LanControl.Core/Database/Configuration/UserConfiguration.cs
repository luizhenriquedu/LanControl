using LanControl.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LanControl.Core.Database.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entityBuilder)
    {
        entityBuilder.Property(x => x.Id).ValueGeneratedOnAdd();
        entityBuilder.Property(x => x.Email).HasMaxLength(150).IsRequired();
        entityBuilder.Property(x => x.Name).HasMaxLength(150).IsRequired();
        entityBuilder.Property(x => x.PasswordHash).HasMaxLength(150).IsRequired();
    }
}