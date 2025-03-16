using Microsoft.Extensions.DependencyInjection;
using NorthernLight.Auth.Persistence.Entities;
using NorthernLight.Auth.Persistence.Repository;

namespace NorthernLight.Auth.Persistence
{
    public static class PersistanceServces
    {
        public static IServiceCollection RegisterPersistanceServces(this IServiceCollection services)
        {
            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<IRepository<UserProfile>, Repository<UserProfile>>();
            services.AddScoped<IRepository<RefreshToken>, Repository<RefreshToken>>();
            services.AddScoped<IRepository<VwUserSignInResponse>, Repository<VwUserSignInResponse>>();
            services.AddScoped<IRepository<DepartmentLeads>, Repository<DepartmentLeads>>();
            services.AddScoped<IRepository<Department>, Repository<Department>>();
            services.AddScoped<IRepository<JobPosition>, Repository<JobPosition>>();
            services.AddScoped<IRepository<UserJobPosition>, Repository<UserJobPosition>>();

            return services;
        }
    }
}
