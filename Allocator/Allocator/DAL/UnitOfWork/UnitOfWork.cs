using Allocator.API.DAL.Context;
using Allocator.API.DAL.Repositories;
using Allocator.API.Models;

namespace Allocator.API.DAL.UnitOfWork;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly AllocatorContext _context;

    public UnitOfWork(AllocatorContext context,
        IGenericRepository<Account> accounts,
        IGenericRepository<User> users,
        IGenericRepository<Stock> stocks,
        IGenericRepository<StockHistoryRow> stockHistories)
    {
        _context = context;
        Accounts = accounts;
        Users = users;
        Stocks = stocks;
        StockHistories = stockHistories;
    }

    public IGenericRepository<Account> Accounts { get; init; }
    public IGenericRepository<User> Users { get; init; }
    public IGenericRepository<Stock> Stocks { get; init; }
    public IGenericRepository<StockHistoryRow> StockHistories { get; init; }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;
}
