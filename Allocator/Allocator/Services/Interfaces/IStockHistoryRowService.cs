using Allocator.API.Models;

namespace Allocator.API.Services.Interfaces;

public interface IStockHistoryRowService
{
    public Task<IEnumerable<StockHistoryRow>> GetStockHistoryRows(int stockId);
    public Task<IEnumerable<StockHistoryRow>> GetStockHistoryRows(int stockId, DateTime from, DateTime till);
    public Task<IEnumerable<StockHistoryRow>> GetStockHistoryRows(IEnumerable<int> stockHistoryRowIds);
    public Task<StockHistoryRow> GetStockHistoryRow(int stockHistoryRowId);
    public Task<StockHistoryRow> Update(StockHistoryRow stockHistoryRowToUpdate);
    public Task Remove(int stockHistoryRowId);
    public Task RemoveRange(IEnumerable<int> stockHistoryRowIds);
    public Task<StockHistoryRow> Create(StockHistoryRow stockHistoryRow);
    public Task<IEnumerable<StockHistoryRow>> CreateRange(IEnumerable<StockHistoryRow> stockHistoryRows);
}