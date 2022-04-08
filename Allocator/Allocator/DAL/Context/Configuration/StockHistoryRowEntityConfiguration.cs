using Allocator.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allocator.API.DAL.Context.Configuration;

public class StockHistoryRowEntityConfiguration : IEntityTypeConfiguration<StockHistoryRow>
{
    public void Configure(EntityTypeBuilder<StockHistoryRow> builder)
    {
        const int precision = 18;
        const int scale = 2;
        builder.HasKey(e => e.StockHistoryRowId);
        builder.HasIndex(e => e.StockHistoryRowId);
        builder.Property(e => e.Input).HasPrecision(precision, scale).IsRequired();
        builder.Property(e => e.Profit).HasPrecision(precision, scale).IsRequired();
        builder.Property(e => e.Output).HasPrecision(precision, scale).IsRequired();
        builder.Property(e => e.Date).IsRequired();
    }
}
