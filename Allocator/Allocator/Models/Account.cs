#pragma warning disable CS8618
namespace Allocator.API.Models;

public class Account
{
    public int AccountId { get; set; }
    public string Title { get; set; } = nameof(Title);
    public string Currency { get; set; } = nameof(Currency);
    public IList<Stock> Stocks { get; set; } = new List<Stock>();

    public int UserId { get; set; }
}