using Allocator.API.DAL.Context.Configuration;
using Allocator.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Allocator.API.DAL.Context;

public class AllocatorContext : DbContext
{
    public AllocatorContext(DbContextOptions<AllocatorContext> options) : base(options) {}

    public DbSet<User>? Users { get; set; }
    public DbSet<Account>? Accounts { get; set; }
    public DbSet<Stock>? Stocks { get; set; }
    public  DbSet<StockHistoryRow>? StockHistoryRows { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new AccountEntityConfiguration());
        modelBuilder.ApplyConfiguration(new StockEntityConfiguration());
        modelBuilder.ApplyConfiguration(new StockHistoryRowEntityConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}