using Allocator.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allocator.API.DAL.Context.Configuration;

public class StockHistoryRowEntityConfiguration : IEntityTypeConfiguration<StockHistoryRow>
{
    public void Configure(EntityTypeBuilder<StockHistoryRow> builder)
    {
        builder.HasKey(e => e.StockHistoryRowId);
        builder.HasIndex(e => e.StockHistoryRowId);
        builder.Property(e => e.Input).IsRequired();
        builder.Property(e => e.Profit).IsRequired();
        builder.Property(e => e.Output).IsRequired();
        builder.Property(e => e.Date).IsRequired();
    }
}
