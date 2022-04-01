using Allocator.API.DTO.User;
using Microsoft.AspNetCore.Mvc;

namespace Allocator.API.Controllers;

[ApiController]
[Route("user")]
[Produces("application/json")]
public class UserController : ControllerBase
{

    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [Route("all")]
    [HttpGet]
    public IEnumerable<UserDTO> GetAll()
    {
        throw new NotImplementedException();
    }

    [HttpGet(Name = "{id}:int:min(1)")]
    public ActionResult<UserDTO> Get(int id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult<UserDTO> Create(CreateUserDTO request)
    {
        //Redirect to get user with created Id.
        throw new NotImplementedException();
    }

    [HttpPut]
    public ActionResult<UserDTO> Update(UserDTO user)
    {
        throw new NotImplementedException();
    }

    [HttpDelete(Name = "{id}:int:min(1)")]
    public ActionResult Delete(int id)
    {
        throw new NotImplementedException();
    }
}
