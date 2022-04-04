using Allocator.API.Models;

namespace Allocator.API.Services.Interfaces;

public interface IAccountService
{
    public Task<IEnumerable<Account>> GetAccounts(int userId);
    public Task<Account> GetAccount(int accountId);
    public Task<Account> Update(Account accountToUpdate);
    public Task Remove(int accountId);
    public Task RemoveRange(IEnumerable<int> accountIds);
    public Task<Account> Create(Account account);
}