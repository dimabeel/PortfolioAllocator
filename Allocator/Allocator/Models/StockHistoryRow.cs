#pragma warning disable CS8618
namespace Allocator.API.Models;

public class StockHistoryRow
{
    public int StockHistoryRowId { get; set; }
    public decimal Input { get; set; }
    public  DateTime Date { get; set; }
    public decimal Profit { get; set; }
    public decimal Output { get; set; }

    public int StockId { get; set; }
}