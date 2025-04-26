namespace FoodOrder.Data.Configurations;

public interface IConnectionStringProvider
{
    string GetConnectionString(string name);
}
