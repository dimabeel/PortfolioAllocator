using System.Reflection;
using Allocator.API.DAL.Context;
using Allocator.API.Mapping;

namespace Allocator.API.Extensions.Services;

public static class AddAutoMapperExtension
{
    public static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfile(typeof(AllocatorContext).Assembly));
        });
    }
}
