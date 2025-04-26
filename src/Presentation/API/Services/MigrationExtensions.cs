using FoodOrder.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FoodOrder.Presentation.Api.Services;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using NpgsqlContext dbContext =
            scope.ServiceProvider.GetRequiredService<NpgsqlContext>();

        dbContext.Database.Migrate();
    }
}
