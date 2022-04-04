using Allocator.API.Models;

namespace Allocator.API.Services.Interfaces;

public interface IUserService
{
    public Task<IEnumerable<User>> GetAll();
    public Task<User> GetBy(int userId);
    public Task<User> Update(User userForUpdate);
    public Task Remove(int id);
    public Task<User> Create(User user);
}