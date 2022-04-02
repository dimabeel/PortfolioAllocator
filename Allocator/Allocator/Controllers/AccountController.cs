using Allocator.API.DTO.Account;
using Allocator.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Allocator.API.Controllers;

[ApiController]
[Route("account")]
[Produces("application/json")]
public class AccountController : ControllerBase
{
    //private readonly ILogger<AccountController> _logger;
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService /*ILogger<AccountController> logger*/)
    {
        _accountService = accountService;
        //_logger = logger;
    }

    [Route("by-user")]
    [HttpGet]
    public IEnumerable<AccountDTO> GetAll(int userId)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public ActionResult<AccountDTO> Get(GetAccountDTO request)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult<AccountDTO> Create(CreateAccountDTO request)
    {
        //Redirect to get user with created Id.
        throw new NotImplementedException();
    }

    [HttpPut]
    public ActionResult<AccountDTO> Update(AccountDTO request)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public ActionResult Delete(GetAccountDTO request)
    {
        throw new NotImplementedException();
    }
}