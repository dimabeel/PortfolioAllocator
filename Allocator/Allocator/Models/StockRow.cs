namespace Allocator.API.Models;

public class StockRow
{
    public int Id { get; set; }
    public double Input { get; set; }
    public  DateTime Date { get; set; }
    public double Profit { get; set; }
    public double Output { get; set; }
}