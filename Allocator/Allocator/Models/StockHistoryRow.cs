#pragma warning disable CS8618
namespace Allocator.API.Models;

public class StockHistoryRow
{
    public int StockHistoryRowId { get; set; }
    public double Input { get; set; }
    public  DateTime Date { get; set; }
    public double Profit { get; set; }
    public double Output { get; set; }

    public int StockId { get; set; }
    public Stock Stock { get; set; }
}