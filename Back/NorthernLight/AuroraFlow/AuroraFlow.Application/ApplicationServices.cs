using AuroraFlow.Application.Infrastructure.Settings;
using AuroraFlow.Application.Services.Auth.SignIn;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuroraFlow.Application;

public static class ApplicationServices
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration )
    {
        services.Configure<ConnectedApis>(configuration.GetSection("ConnectedApis"));
        
        services.AddScoped<ISignInService, SignInService>();
        return services;
    }
}