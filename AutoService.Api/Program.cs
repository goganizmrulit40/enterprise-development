using AutoService.Api.Middlewares;
using AutoService.Application.Services;
using AutoService.Contracts.Interfaces;
using AutoService.Domain.Interfaces;
using AutoService.Infrastructure.Persistence;
using AutoService.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(System.IO.Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var connectionString = builder.Configuration.GetConnectionString("autoservice-db")
    ?? "Host=localhost;Port=5432;Database=autoservice;Username=postgres;Password=postgres";

builder.Services.AddDbContext<AutoServiceDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<ICarRepository, EfCarRepository>();
builder.Services.AddScoped<IClientRepository, EfClientRepository>();
builder.Services.AddScoped<IMechanicRepository, EfMechanicRepository>();
builder.Services.AddScoped<IOrderRepository, EfOrderRepository>();
builder.Services.AddScoped<IWorkTypeRepository, EfWorkTypeRepository>();

builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IMechanicService, MechanicService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IWorkTypeService, WorkTypeService>();
builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseRouting();
app.MapControllers();

await using (var scope = app.Services.CreateAsyncScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AutoServiceDbContext>();
    var retries = 0;
    while (true)
    {
        try
        {
            await dbContext.Database.MigrateAsync();
            break;
        }
        catch (Exception) when (++retries < 15)
        {
            await Task.Delay(1000);
        }
    }
}

app.Run();

public partial class Program { }
