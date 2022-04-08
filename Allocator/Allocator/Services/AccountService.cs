using Allocator.API.DAL.UnitOfWork;
using Allocator.API.Exceptions;
using Allocator.API.Models;
using Allocator.API.Services.Interfaces;

namespace Allocator.API.Services;

public class AccountService : IAccountService
{
    private readonly IUnitOfWork _unitOfWork;

    public AccountService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<IEnumerable<Account>> GetAll(int userId)
    {
        return _unitOfWork.Accounts.Find(x => x.UserId == userId);
    }

    public async Task<Account> GetBy(int accountId)
    {
        var account = await _unitOfWork.Accounts.GetById(accountId);
        if (account.AccountId == 0) throw new AccountNotFoundException();
        return account;
    }

    public async Task<Account> Update(Account accountToUpdate)
    {
        var account = await _unitOfWork.Accounts.GetById(accountToUpdate.AccountId);
        if (account.AccountId == 0) throw new AccountNotFoundException();

        account.Currency = accountToUpdate.Currency;
        account.Title = accountToUpdate.Title;
                        
        var updatedAccount = _unitOfWork.Accounts.Update(account);
        await _unitOfWork.SaveChangesAsync();
        return updatedAccount;
    }

    public async Task Remove(int accountId)
    {
        var account = await _unitOfWork.Accounts.GetById(accountId);
        if (account.AccountId == 0) throw new AccountNotFoundException();

        _unitOfWork.Accounts.Remove(account);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task RemoveRange(IEnumerable<int> accountIds)
    {
        var accounts = new List<Account>();
        foreach (var accountId in accountIds)
        {
            var account = await _unitOfWork.Accounts.GetById(accountId);
            if (account.AccountId == 0) throw new AccountNotFoundException();
            accounts.Add(account);
        }

        _unitOfWork.Accounts.RemoveRange(accounts);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<Account> Create(Account account)
    {
        var createdAccount = await _unitOfWork.Accounts.Add(account);
        await _unitOfWork.SaveChangesAsync();
        return createdAccount;
    }
}