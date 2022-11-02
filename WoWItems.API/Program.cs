using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WoWItems.API.DbContexts;
using WoWItems.API.Middleware;
using WoWItems.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson();

builder.Services.AddDbContext<WoWItemsContext>(
    dbContextOptions => dbContextOptions.UseSqlServer(builder.Configuration.GetConnectionString("WoWItemsDBConnectionString")));


builder.Services.AddScoped<IWoWItemsRepository, WoWItemsRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseWhen(context => context.Request.Path.StartsWithSegments("/api/item"), appBuilder =>
{
    appBuilder.UseMiddleware<WoWItemsSecurityHeadersMiddleware>();
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
