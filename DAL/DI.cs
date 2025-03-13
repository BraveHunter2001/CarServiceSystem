using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL;

public static class DI
{
    public static void AddDAL(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<CarServiceSystemContext>(ctx =>
        {
            ctx.UseSqlServer(connectionString);
        });

        services.AddScoped<IAutomobileRepository, AutomobileRepository>();
        services.AddScoped<IMasterRepository, MasterRepository>();
    }
}
