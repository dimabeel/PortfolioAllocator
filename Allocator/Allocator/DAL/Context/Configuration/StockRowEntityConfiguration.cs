using Allocator.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allocator.API.DAL.Context.Configuration;

public class StockRowEntityConfiguration : IEntityTypeConfiguration<StockRow>
{
    public void Configure(EntityTypeBuilder<StockRow> builder)
    {
        const int doublePrecision = 2;

        builder.HasKey(e => e.Id);
        builder.HasIndex(e => e.Id);
        builder.Property(e => e.Input).HasPrecision(doublePrecision).IsRequired();
        builder.Property(e => e.Profit).HasPrecision(doublePrecision).IsRequired();
        builder.Property(e => e.Profit).HasPrecision(doublePrecision).IsRequired();
        builder.Property(e => e.Date).HasDefaultValue(DateTime.UtcNow).IsRequired();
    }
}
