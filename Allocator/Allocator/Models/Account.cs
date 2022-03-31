namespace Allocator.API.Models;

public class Account
{
    public int Id { get; set; }
    public string Title { get; set; } = nameof(Title);
    public string Currency { get; set; } = nameof(Currency);
    public IList<Stock> Stocks { get; set; } = new List<Stock>();
}