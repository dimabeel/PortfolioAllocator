using Allocator.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allocator.API.DAL.Context.Configuration;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        const int nameLength = 50;
        const int surnameLength = 100;

        builder.HasQueryFilter(x => !x.IsDeleted);
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => e.Id);
        builder.Property(e => e.Name)
            .HasMaxLength(nameLength)
            .IsRequired();
        builder.Property(e => e.Surname)
            .HasMaxLength(surnameLength)
            .IsRequired();

        builder.HasMany(e => e.Accounts)
            .WithOne()
            .HasForeignKey(x => x.UserId);
    }
}
