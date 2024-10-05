using API.Services;
using Application.UseCases.Clientes;
using Domain.Ports;
using Infra.Data.Configurations;
using Infra.Data.Repository;
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
        builder.Services.AddDbContext<Infra.Data.Context.NpgsqlContext>(
            options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Application.Commands.AddClienteCommand).Assembly));
        builder.Services.AddTransient<IClienteUseCase, ClienteUseCase>();
        builder.Services.AddTransient<IClienteRepository, ClienteRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.ApplyMigrations();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
                
    }
}