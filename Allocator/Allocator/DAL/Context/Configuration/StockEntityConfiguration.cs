using Allocator.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allocator.API.DAL.Context.Configuration;

public class StockEntityConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        const int companyNameLength = 100;

        builder.HasKey(e => e.StockId);
        builder.HasIndex(e => e.StockId);
        builder.Property(e => e.Company)
            .HasMaxLength(companyNameLength)
            .IsRequired();
        builder.HasIndex(e => e.Company);

        builder.HasMany(e => e.StockHistory)
            .WithOne()
            .HasForeignKey(x => x.StockId);
    }
}
