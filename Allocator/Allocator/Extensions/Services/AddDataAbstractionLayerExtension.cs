using Allocator.API.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace Allocator.API.Extensions.Services;

public static class AddDataAbstractionLayerExtension
{
    private const int RetryCount = 5;
    private const int TimeoutInS = 10;

    public static void AddDataAbstractionLayer(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        services.AddDbContext<AllocatorContext>(options =>
        {
            options.UseSqlServer(configurationManager.GetConnectionString("DbConnection"),
                b =>
                {
                    b.MigrationsAssembly((typeof(AllocatorContext).Assembly.FullName));
                    b.EnableRetryOnFailure(RetryCount);
                    b.CommandTimeout(TimeoutInS);
                });
        });
    }
}
