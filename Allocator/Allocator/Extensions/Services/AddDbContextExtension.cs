using Allocator.API.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace Allocator.API.Extensions.Services;

public static class AddDbContextExtension
{
    private const int RetryCount = 5;
    private const int TimeoutInS = 10;

    public static void AddDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AllocatorContext>(options =>
        {
            options.UseSqlServer(connectionString,
                b =>
                {
                    b.MigrationsAssembly((typeof(AllocatorContext).Assembly.FullName));
                    b.EnableRetryOnFailure(RetryCount);
                    b.CommandTimeout(TimeoutInS);
                });
        });
    }
}
