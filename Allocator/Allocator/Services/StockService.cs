using Allocator.API.DAL.UnitOfWork;
using Allocator.API.Exceptions;
using Allocator.API.Models;
using Allocator.API.Services.Interfaces;

namespace Allocator.API.Services;

public class StockService : IStockService
{
    private readonly IUnitOfWork _unitOfWork;

    public StockService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<IEnumerable<Stock>> GetStocks(int accountId)
    {
        return _unitOfWork.Stocks.Find(x => x.AccountId == accountId);
    }

    public async Task<Stock> GetStock(int stockId)
    {
        var stock = await _unitOfWork.Stocks.GetById(stockId);
        if (stock.StockId == 0) throw new StockNotFoundException();
        return stock;
    }

    public async Task<Stock> Update(Stock stockToUpdate)
    {
        var stock = await _unitOfWork.Stocks.GetById(stockToUpdate.StockId);
        if (stock.StockId == 0) throw new StockNotFoundException();

        stock.Company = stockToUpdate.Company;

        var updatedStock = _unitOfWork.Stocks.Update(stock);
        await _unitOfWork.SaveChangesAsync();
        return updatedStock;
    }

    public async Task Remove(int stockId)
    {
        var stock = await _unitOfWork.Stocks.GetById(stockId);
        if (stock.StockId == 0) throw new StockNotFoundException();

        _unitOfWork.Stocks.Remove(stock);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task RemoveRange(IEnumerable<int> stockIds)
    {
        var stocks = new List<Stock>();
        foreach (var stockId in stockIds)
        {
            var stock = await _unitOfWork.Stocks.GetById(stockId);
            if (stock.StockId == 0) throw new StockNotFoundException();
            stocks.Add(stock);
        }

        _unitOfWork.Stocks.RemoveRange(stocks);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<Stock> Create(Stock stock)
    {
        var createdStock = await _unitOfWork.Stocks.Add(stock);
        await _unitOfWork.SaveChangesAsync();
        return createdStock;
    }
}