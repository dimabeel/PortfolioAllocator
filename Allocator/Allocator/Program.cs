using Allocator.API.Extensions.Middlewares;
using Allocator.API.Extensions.Services;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog();
    builder.Services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddAutoMapper();
    builder.Services.AddDbContext(builder.Configuration.GetConnectionString("DbConnection"));
    builder.Services.AddUnitOfWorkWithRepositories();
    builder.Services.AddDataAccessServices();

    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .CreateLogger();

    var app = builder.Build();
    app.UseHttpsRedirection();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseSerilogRequestLogging();

    app.UseCustomExceptionMiddleware();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
catch(Exception ex)
{
    Log.Fatal(ex, "The application failed to start correctly.");
}
finally
{
    Log.CloseAndFlush();
}
