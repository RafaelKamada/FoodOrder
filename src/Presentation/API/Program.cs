using FoodOrder.Api.Services;
using FoodOrder.Application.Features;
using FoodOrder.Application.UseCases;
using FoodOrder.Data.Configurations;
using FoodOrder.Data.Context;
using FoodOrder.Data.Repositorio;
using FoodOrder.Domain.Interface;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        builder.Services.AddTransient<IConnectionStringProvider, ConnectionStringProvider>();
        builder.Services.AddDbContext<NpgsqlContext>(
            options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(AddClienteCommand).Assembly));
        builder.Services.AddTransient<IClienteUseCase, ClienteUseCase>();
        builder.Services.AddTransient<IClienteRepository, ClienteRepository>();

        builder.Services.AddLogging(configure => {
            configure.AddConsole();
            configure.AddDebug();
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.ApplyMigrations();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
                
    }
}
