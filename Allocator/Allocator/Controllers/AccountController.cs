using Allocator.API.DTO.Account;
using Allocator.API.Models;
using Allocator.API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Allocator.API.Controllers;

[ApiController]
[Route("account")]
[Produces("application/json")]
public class AccountController : ControllerBase
{
    //private readonly ILogger<AccountController> _logger;
    private readonly IAccountService _accountService;
    private readonly IMapper _mapper;

    public AccountController(IAccountService accountService, IMapper mapper /*ILogger<AccountController> logger*/)
    {
        _accountService = accountService;
        _mapper = mapper;
        //_logger = logger;
    }

    [Route("/accounts")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AccountDTO>>> GetAll(int userId)
    {
        var accountsByUserId = await _accountService.GetAll(userId);
        var accountsDto = _mapper.Map<IEnumerable<AccountDTO>>(accountsByUserId);
        return Ok(accountsDto);
    }

    [HttpGet]
    public async Task<ActionResult<AccountDTO>> Get(int accountId)
    {
        var account = await _accountService.GetBy(accountId);
        var accountDto = _mapper.Map<AccountDTO>(account);
        return Ok(accountDto);
    }

    [HttpPost]
    public async Task<ActionResult<AccountDTO>> Create(CreateAccountDTO createAccountDto)
    {
        var account = _mapper.Map<Account>(createAccountDto);
        var createdAccount = await _accountService.Create(account);
        var createdAccountDto = _mapper.Map<AccountDTO>(createdAccount);
        return CreatedAtAction(nameof(Get), new { id = createdAccountDto.AccountId }, createdAccountDto);
    }

    [HttpPut]
    public async Task<ActionResult<AccountDTO>> Update(AccountDTO updateAccountDto)
    {
        var account = _mapper.Map<Account>(updateAccountDto);
        var updatedAccount = await _accountService.Update(account);
        var updatedAccountDto = _mapper.Map<AccountDTO>(updatedAccount);
        return Ok(updatedAccountDto);
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(int accountId)
    {
        await _accountService.Remove(accountId);
        return NoContent();
    }

    [Route("/accounts")]
    [HttpDelete]
    public async Task<ActionResult> DeleteRange(IEnumerable<int> accountIds)
    {
        await _accountService.RemoveRange(accountIds);
        return NoContent();
    }
}