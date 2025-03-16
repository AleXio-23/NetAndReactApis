using AuroraFlow.Persistance.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace AuroraFlow.Persistance;

public static class PersistanceServices
{
    public static IServiceCollection RegisterPersistanceServices(this IServiceCollection services)
    {
        services.AddScoped<IAuroraFlowUnitOfWork,  AuroraFlowUnitOfWork>();


        return services;
    }
}