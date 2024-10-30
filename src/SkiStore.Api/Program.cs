using Microsoft.EntityFrameworkCore;
using SkiStore.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.WebHost.ConfigureKestrel(options => { options.ConfigureEndpointDefaults(defaults => {});});

var app = builder.Build();

app.MapControllers();
app.Run();
