using FoodOrder.Data.Configurations;

namespace FoodOrder.Api.Services;

public class ConnectionStringProvider(IConfiguration configuration) : IConnectionStringProvider
{
    private readonly IConfiguration _configuration = configuration;

    public string GetConnectionString(string name)
    {
        var connectionString = _configuration.GetConnectionString(name);
        return connectionString ?? throw new InvalidOperationException($"Connection string '{name}' not found.");
    }
}
