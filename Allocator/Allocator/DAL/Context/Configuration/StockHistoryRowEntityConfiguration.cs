﻿using Allocator.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allocator.API.DAL.Context.Configuration;

public class StockHistoryRowEntityConfiguration : IEntityTypeConfiguration<StockHistoryRow>
{
    public void Configure(EntityTypeBuilder<StockHistoryRow> builder)
    {
        const int doublePrecision = 2;

        builder.HasKey(e => e.StockHistoryRowId);
        builder.HasIndex(e => e.StockHistoryRowId);
        builder.Property(e => e.Input).HasPrecision(doublePrecision).IsRequired();
        builder.Property(e => e.Profit).HasPrecision(doublePrecision).IsRequired();
        builder.Property(e => e.Profit).HasPrecision(doublePrecision).IsRequired();
        builder.Property(e => e.Date).IsRequired();
    }
}
