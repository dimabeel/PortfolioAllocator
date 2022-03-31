using Allocator.API.DAL.Repositories;
using Allocator.API.Models;

namespace Allocator.API.DAL.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Account> Accounts { get; }
    IGenericRepository<User> Users { get; }
    IGenericRepository<Stock> Stocks { get; }
    IGenericRepository<StockRow> StockHistories { get; }

    Task<bool> SaveChangesAsync();
}