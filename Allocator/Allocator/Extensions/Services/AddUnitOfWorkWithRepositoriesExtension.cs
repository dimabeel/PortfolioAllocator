using Allocator.API.DAL.Repositories;
using Allocator.API.DAL.UnitOfWork;

namespace Allocator.API.Extensions.Services;

public static class AddUnitOfWorkWithRepositoriesExtension
{
    public static void AddUnitOfWorkWithRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
    }
}
