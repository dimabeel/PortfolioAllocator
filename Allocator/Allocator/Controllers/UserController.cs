using Allocator.API.DTO.User;
using Allocator.API.Models;
using Allocator.API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Allocator.API.Controllers;

[ApiController]
[Route("user")]
[Produces("application/json")]
public class UserController : ControllerBase
{
    //private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper /*ILogger<UserController> logger*/)
    {
        _userService = userService;
        _mapper = mapper;
        //_logger = logger;
    }

    [Route("/users")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
    {
        var users = await _userService.GetAll();
        var usersDto = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
        return Ok(usersDto);
    }

    [HttpGet(Name = "{id}:int")]
    public async Task<ActionResult<UserDTO>> Get(int id)
    {
        var user = await _userService.GetBy(id);
        var userDto = _mapper.Map<User, UserDTO>(user);
        return Ok(userDto);
    }

    [HttpPost]
    public async Task<ActionResult<UserDTO>> Create(CreateUserDTO createUserDto)
    {
        var user = _mapper.Map<CreateUserDTO, User>(createUserDto);
        var createdUser = await _userService.Create(user);
        return CreatedAtAction(nameof(Get), new {id = createdUser.Id}, createdUser);
    }

    [HttpPatch]
    public async Task<ActionResult<UserDTO>> Update(UserDTO userDto)
    {
        var user = _mapper.Map<UserDTO, User>(userDto);
        var updatedUser = await _userService.Update(user);
        var updatedUserDto = _mapper.Map<User, UserDTO>(updatedUser);
        return Ok(updatedUserDto);
    }

    [HttpDelete(Name = "{id}:int")]
    public async Task<ActionResult> Delete(int id)
    {
        await _userService.Remove(id);
        return NoContent();
    }
}
