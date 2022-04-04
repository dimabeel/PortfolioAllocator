using Allocator.API.DAL.UnitOfWork;
using Allocator.API.Exceptions;
using Allocator.API.Models;
using Allocator.API.Services.Interfaces;

namespace Allocator.API.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<IEnumerable<User>> GetAll()
    {
        return _unitOfWork.Users.GetAll();
    }

    public async Task<User> GetBy(int userId)
    {
        var user = await _unitOfWork.Users.GetById(userId);
        if (user.Id == 0) throw new HttpResponseException(404, userId); //Replace to UserNotFoundException;

        return user;
    }

    public async Task<User> Update(User userForUpdate)
    {
        var user = await _unitOfWork.Users.GetById(userForUpdate.Id);
        if (user.Id == 0) throw new HttpResponseException(404, userForUpdate); //Replace to UserNotFoundException;

        user.Name = userForUpdate.Name;
        user.Surname = userForUpdate.Surname;

        var updatedUser = _unitOfWork.Users.Update(user);
        await _unitOfWork.SaveChangesAsync();
        return updatedUser;
    }

    public async Task Remove(int id)
    {
        var user = await _unitOfWork.Users.GetById(id);
        if (user.Id == 0) throw new HttpResponseException(404, id); //Replace to UserNotFoundException;

        _unitOfWork.Users.Remove(user);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<User> Create(User user)
    {
        var createdUser = await _unitOfWork.Users.Add(user);
        await _unitOfWork.SaveChangesAsync();
        return createdUser;
    }
}
