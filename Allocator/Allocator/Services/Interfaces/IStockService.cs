using Allocator.API.Models;

namespace Allocator.API.Services.Interfaces;

public interface IStockService
{
    public Task<IEnumerable<Stock>> GetStocks(int accountId);
    public Task<Stock> GetStock(int stockId);
    public Task<Stock> Update(Stock stock);
    public Task Remove(int stockId);
    public Task RemoveRange(IEnumerable<int> stockIds);
    public Task<Stock> Create(Stock stock);
}