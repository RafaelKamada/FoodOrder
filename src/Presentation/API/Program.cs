using API.Services;
using FoodOrder.Application.UseCases.Checkout;
using FoodOrder.Application.UseCases.Clientes;
using FoodOrder.Application.UseCases.Pagamento;
using FoodOrder.Application.UseCases.Pedidos;
using FoodOrder.Application.UseCases.Produtos;
using FoodOrder.Application.UseCases.Webhook;
using FoodOrder.Data.External.MercadoPago;
using FoodOrder.Data.Repositorio.Cliente;
using FoodOrder.Data.Repositorio.Pagamento;
using FoodOrder.Data.Repositorio.Pedido;
using FoodOrder.Data.Repositorio.Produto;
using FoodOrder.Data.Repositorio.Sacola;
using FoodOrder.Domain.Interface;
using FoodOrder.Domain.Ports;
using FoodOrder.Infra.Data.Configurations;
using FoodOrder.Infra.Data.Repository;
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
        builder.Services.AddDbContext<FoodOrder.Infra.Data.Context.NpgsqlContext>(
            options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(FoodOrder.Application.Commands.AddClienteCommand).Assembly));
        builder.Services.AddTransient<IClienteUseCase, ClienteUseCase>();
        builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
        builder.Services.AddTransient<IProdutoUseCase, ProdutoUseCase>();
        builder.Services.AddTransient<ICategoriaUseCase, CategoriaUseCase>();
        builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
        builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
        builder.Services.AddTransient<IPedidoUseCase, PedidoUseCase>();
        builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
        builder.Services.AddTransient<ICheckoutUseCase, CheckoutUseCase>();
        builder.Services.AddTransient<ISacolaRepository, SacolaRepository>();
        builder.Services.AddTransient<ISacolaProdutoRepository, SacolaProdutoRepository>();
        builder.Services.AddTransient<IPagamentoUseCase, PagamentoUseCase>();
        builder.Services.AddTransient<IPagamentoRepository, PagamentoRepository>();
        builder.Services.AddTransient<IPagamentoStatusRepository, PagamentoStatusRepository>();
        builder.Services.AddTransient<IPedidoStatusRepository, PedidoStatusRepository>(); 

        builder.Services.AddTransient<IPagtoWebhookUseCase, PagtoWebhookUseCase>();
        builder.Services.AddHttpClient<IMercadoPagoExternalService, MercadoPagoExternalService>();

        builder.Services.AddHealthChecks();

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

        //endpoint de health check
        app.MapHealthChecks("/health");

        app.Run();
                
    }
}
