using System.Reflection;
using Allocator.API.DAL.Context;
using Allocator.API.DAL.Repositories;
using Allocator.API.DAL.UnitOfWork;
using Allocator.API.Extensions.Middlewares;
using Allocator.API.Extensions.Services;
using Allocator.API.Mapping;
using Allocator.API.Services;
using Allocator.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(AllocatorContext).Assembly));
});

builder.Services.AddDbContext(builder.Configuration.GetConnectionString("DbConnection"));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

builder.Services.AddScoped(typeof(IUserService), typeof(UserService));
builder.Services.AddScoped(typeof(IAccountService), typeof(AccountService));
builder.Services.AddScoped(typeof(IStockService), typeof(StockService));
builder.Services.AddScoped(typeof(IStockHistoryRowService), typeof(StockHistoryRowService));

var app = builder.Build();
app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptionMiddleware();
app.UseAuthorization();
app.MapControllers();
app.Run();