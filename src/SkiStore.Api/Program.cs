using Microsoft.EntityFrameworkCore;
using SkiStore.Core.Interfaces;
using SkiStore.Infrastructure.Data;
using SkiStore.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.WebHost.ConfigureKestrel(options => { options.ConfigureEndpointDefaults(defaults => {});});
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

app.MapControllers();
app.Run();
