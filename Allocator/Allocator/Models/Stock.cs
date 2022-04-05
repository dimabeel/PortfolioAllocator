#pragma warning disable CS8618
namespace Allocator.API.Models;

public class Stock
{
    public int StockId { get; set; }
    public string Company { get; set; } = nameof(Company);
    public IList<StockHistoryRow> StockHistory { get; set; } = new List<StockHistoryRow>();

    public int AccountId { get; set; }
    public Account Account { get; set; }
}