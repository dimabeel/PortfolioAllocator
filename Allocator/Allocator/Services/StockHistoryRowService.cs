using Allocator.API.DAL.UnitOfWork;
using Allocator.API.Exceptions;
using Allocator.API.Models;
using Allocator.API.Services.Interfaces;

namespace Allocator.API.Services;

public class StockHistoryRowService : IStockHistoryRowService
{
    private readonly IUnitOfWork _unitOfWork;

    public StockHistoryRowService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<IEnumerable<StockHistoryRow>> GetStockHistoryRows(int stockId)
    {
        return _unitOfWork.StockHistories.Find(x => x.StockId == stockId);
    }

    public async Task<IEnumerable<StockHistoryRow>> GetStockHistoryRows(int stockId, DateTime from, DateTime till)
    {
        return await _unitOfWork.StockHistories
            .Find(x => x.StockId == stockId && x.Date > from && x.Date < till);
    }

    public async Task<StockHistoryRow> GetStockHistoryRow(int stockHistoryRowId)
    {
        var stockHistoryRow = await _unitOfWork.StockHistories.GetById(stockHistoryRowId);
        if (stockHistoryRow.StockHistoryRowId == 0) throw new StockHistoryRowNotFoundException();

        return stockHistoryRow;
    }

    public async Task<StockHistoryRow> Update(StockHistoryRow stockHistoryRowToUpdate)
    {
        var stockHistoryRow = await _unitOfWork.StockHistories.GetById(stockHistoryRowToUpdate.StockHistoryRowId);
        if (stockHistoryRow.StockId == 0) throw new StockHistoryRowNotFoundException();

        stockHistoryRow.Profit = stockHistoryRowToUpdate.Profit;
        stockHistoryRow.Date = stockHistoryRowToUpdate.Date;
        stockHistoryRow.Input = stockHistoryRowToUpdate.Input;
        stockHistoryRow.Output = CalculateOutput(stockHistoryRow.Profit, stockHistoryRow.Input);

        var updatedStockHistoryRow = _unitOfWork.StockHistories.Update(stockHistoryRow);
        await _unitOfWork.SaveChangesAsync();
        return updatedStockHistoryRow;
    }

    public async Task Remove(int stockHistoryRowId)
    {
        var stockHistoryRow = await _unitOfWork.StockHistories.GetById(stockHistoryRowId);
        if (stockHistoryRow.StockId == 0) throw new StockHistoryRowNotFoundException();

        _unitOfWork.StockHistories.Remove(stockHistoryRow);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task RemoveRange(IEnumerable<int> stockHistoryRowIds)
    {
        var stocksHistory = new List<StockHistoryRow>();
        foreach (var stockHistoryRowId in stockHistoryRowIds)
        {
            var stockHistoryRow = await _unitOfWork.StockHistories.GetById(stockHistoryRowId);
            if (stockHistoryRow.StockHistoryRowId == 0) throw new StockHistoryRowNotFoundException();
            stocksHistory.Add(stockHistoryRow);
        }

        _unitOfWork.StockHistories.RemoveRange(stocksHistory);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<StockHistoryRow> Create(StockHistoryRow stockHistoryRow)
    {
        stockHistoryRow.Output = CalculateOutput(stockHistoryRow.Profit, stockHistoryRow.Input);
        var createdStock = await _unitOfWork.StockHistories.Add(stockHistoryRow);
        await _unitOfWork.SaveChangesAsync();
        return createdStock;
    }

    public async Task<IEnumerable<StockHistoryRow>> CreateRange(IEnumerable<StockHistoryRow> stockHistoryRows)
    {
        var rows = new List<StockHistoryRow>();
        foreach (var stockHistoryRow in stockHistoryRows)
        {
            stockHistoryRow.Output = CalculateOutput(stockHistoryRow.Profit, stockHistoryRow.Input);
            var createdStock = await _unitOfWork.StockHistories.Add(stockHistoryRow);
            rows.Add(createdStock);
        }

        await _unitOfWork.SaveChangesAsync();
        return rows;
    }

    private double CalculateOutput(double profit, double input)
    {
        return input * (1 + (profit / 100));
    }
}