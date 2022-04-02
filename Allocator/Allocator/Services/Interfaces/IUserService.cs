using Allocator.API.Models;

namespace Allocator.API.Services.Interfaces;

public interface IUserService
{
    public Task<IEnumerable<User>> GetAll();
    public Task<User> GetBy(int userId);
    public User Update(User user);
    public void Remove(User user);
    public Task<User> Create(User user);
}