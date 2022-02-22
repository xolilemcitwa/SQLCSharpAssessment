using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Roulette.Api.Data;
using Roulette.Api.Repositories;
using Roulette.Api.Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContextPool<RouletteDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("RouletteDBConnection"))
);

builder.Services.AddScoped<IBetRepository, BetRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
}

app.UseCors(policy =>
    policy.WithOrigins("http://localhost:7060", "https://localhost:7060")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType)
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();