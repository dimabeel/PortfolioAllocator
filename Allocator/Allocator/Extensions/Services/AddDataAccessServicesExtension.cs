using System.Reflection;
using Allocator.API.Services;
using Allocator.API.Services.Interfaces;

namespace Allocator.API.Extensions.Services;

public static class AddDataAccessServicesExtension
{
    public static void AddDataAccessServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IUserService), typeof(UserService));
        services.AddScoped(typeof(IAccountService), typeof(AccountService));
        services.AddScoped(typeof(IStockService), typeof(StockService));
        services.AddScoped(typeof(IStockHistoryRowService), typeof(StockHistoryRowService));
    }
}
