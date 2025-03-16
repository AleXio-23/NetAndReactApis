using AuroraFlow.Persistance.Entities;
using AuroraFlow.Persistance.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace AuroraFlow.Persistance;

public static class PersistanceServices
{
    public static IServiceCollection RegisterPersistanceServices(this IServiceCollection services)
    {
        services.AddScoped<IRepository<User>, Repository<User>>();


        return services;
    }
}