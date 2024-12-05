namespace FoodOrder.Infra.Data.Configurations
{
    public interface IConnectionStringProvider
    {
        string GetConnectionString(string name);
    }
}
