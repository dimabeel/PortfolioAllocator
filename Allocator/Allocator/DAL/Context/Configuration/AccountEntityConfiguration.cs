using Allocator.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allocator.API.DAL.Context.Configuration;

public class AccountEntityConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        const int currencyLength = 3;
        const int titleLength = 100;

        builder.HasKey(e => e.AccountId);
        builder.HasIndex(e => e.AccountId);
        builder.Property(e => e.Currency)
            .HasMaxLength(currencyLength)
            .IsRequired();
        builder.Property(e => e.Title)
            .HasMaxLength(titleLength)
            .IsRequired();
        builder.HasIndex(e => e.Title);

        builder.HasMany(e => e.Stocks)
            .WithOne(x => x.Account)
            .HasForeignKey(x => x.AccountId);
    }
}
