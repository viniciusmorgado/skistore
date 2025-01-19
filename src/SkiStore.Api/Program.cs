using Microsoft.EntityFrameworkCore;
using SkiStore.Api.Middleware;
using SkiStore.Core.Base.Interfaces;
using SkiStore.Core.Interfaces;
using SkiStore.Infrastructure.Data;
using SkiStore.Infrastructure.Data.Base.Repositories;
using SkiStore.Infrastructure.Data.Repositories;
using StackExchange.Redis;

// Configure Services that Start with the Application (order don't matter)
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddSingleton<IConnectionMultiplexer>(opt =>
{
    return ConnectionMultiplexer.Connect(
        ConfigurationOptions.Parse(
            builder.Configuration.GetConnectionString("Redis"), true
        )
    );
});
builder.WebHost.ConfigureKestrel(options => { options.ConfigureEndpointDefaults(defaults => {});});
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddCors();

// Configure Application middlewares (order does matter)
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        services.GetRequiredService<StoreContext>().Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
    }
}
app.UseMiddleware<ExceptionMiddleware>();
app.UseCors(x => x
   .AllowAnyHeader()
   .AllowAnyMethod()
   .WithOrigins("http://localhost:5001","https://localhost:5001","https://api-skistore.donatto.dev.br")); // TODO: Move to appsettings.json
app.MapControllers();
app.Run();
