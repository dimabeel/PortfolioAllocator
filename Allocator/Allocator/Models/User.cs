namespace Allocator.API.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = nameof(Name);
    public string Surname { get; set; } = nameof(Surname);
    public IList<Account> Accounts { get; set; } = new List<Account>();
}