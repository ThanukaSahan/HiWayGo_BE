using Microsoft.Extensions.DependencyInjection;

namespace HiwayGo_API.Repository
{
    public static class RepositoryServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IBusModelRepository, BusModelRepository>();
            services.AddScoped<IBusRouteRepository, BusRouteRepository>();
            services.AddScoped<IBusRouteFareRepository, BusRouteFareRepository>();
            services.AddScoped<IBusDetailRepository, BusDetailRepository>();
            services.AddScoped<IBusBookingRepository, BusBookingRepository>();

            return services;
        }
    }
}
