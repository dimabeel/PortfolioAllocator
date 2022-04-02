using Allocator.API.Models;

namespace Allocator.API.Services.Interfaces;

public interface IStockService
{
    public Task<IEnumerable<Stock>> GetStocks(int userId, int accountId);
    public Task<Stock> GetStock(int userId, int accountId, int stockId);
    public Stock Update(int userId, int accountId, Stock stock);
    public void Remove(int userId, int accountId, Stock stock);
    public void RemoveRange(int userId, int accountId, IEnumerable<Stock> stocks);
    public Task<Stock> Create(int userId, int accountId, Stock stock);
}