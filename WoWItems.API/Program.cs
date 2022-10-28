using Microsoft.EntityFrameworkCore;
using WoWItems.API.DbContexts;
using WoWItems.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson();

builder.Services.AddDbContext<WoWItemsContext>(
    dbContextOptions => dbContextOptions.UseSqlServer("Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog = WoWItemsDatabase"));


builder.Services.AddScoped<IWoWItemsRepository, WoWItemsRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
