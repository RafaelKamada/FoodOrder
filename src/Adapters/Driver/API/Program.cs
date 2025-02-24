using API.Services;
using Application.UseCases.Checkout;
using Application.UseCases.Clientes;
using Application.UseCases.Pedidos;
using Application.UseCases.Produtos;
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
        builder.Services.AddTransient<IProdutoUseCase, ProdutoUseCase>();
        builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
        builder.Services.AddTransient<IPedidoUseCase, PedidoUseCase>();
        builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
        builder.Services.AddTransient<ICheckoutUseCase, CheckoutUseCase>();
        builder.Services.AddTransient<ISacolaRepository, SacolaRepository>();
        builder.Services.AddTransient<ISacolaProdutoRepository, SacolaProdutoRepository>();
        builder.Services.AddTransient<IPagamentoRepository, PagamentoRepository>();
        builder.Services.AddTransient<IPagamentoStatusRepository, PagamentoStatusRepository>();
        builder.Services.AddTransient<IPedidoStatusRepository, PedidoStatusRepository>();


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
