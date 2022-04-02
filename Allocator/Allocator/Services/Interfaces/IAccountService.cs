using Allocator.API.Models;

namespace Allocator.API.Services.Interfaces;

public interface IAccountService
{
    public Task<IEnumerable<Account>> GetUserAccounts(int userId);
    public Task<Account> GetUserAccount(int userId, int accountId);
    public Account Update(int userId, Account account);
    public void Remove(int userId, Account account);
    public void RemoveRange(int userId, IEnumerable<Account> accounts);
    public Task<Account> Create(int userId, Account account);
}