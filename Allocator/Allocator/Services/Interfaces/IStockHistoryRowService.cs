using Allocator.API.Models;

namespace Allocator.API.Services.Interfaces;

public interface IStockHistoryRowService
{
    public Task<IEnumerable<StockHistoryRow>> GetStocks(int userId, int accountId);
    public Task<StockHistoryRow> GetStock(int userId, int accountId, int stockId);
    // TODO: Take stock history by range of dates AND last X rows, etc.
    public Stock Update(int userId, int accountId, int stockId, StockHistoryRow stockHistoryRow);
    public void Remove(int userId, int accountId, int stockId, StockHistoryRow stockHistoryRow);
    public void RemoveRange(int userId, int accountId, int stockId, IEnumerable<StockHistoryRow> stockHistoryRows);
    public Task<StockHistoryRow> Create(int userId, int accountId, int stockId, StockHistoryRow stockHistoryRow);
    public Task<IEnumerable<StockHistoryRow>> CreateRange(int userId, int accountId, int stockId,
        IEnumerable<StockHistoryRow> stockHistoryRows);
}