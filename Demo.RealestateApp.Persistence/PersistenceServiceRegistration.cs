using Demo.RealestateApp.Application.Contracts.Persistence;
using Demo.RealestateApp.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.RealestateApp.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddDbContext<RealestateAppDbContext>(options =>
               options.UseSqlServer("Server=.;Database=RealestateAppDemo;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"));

            services.AddScoped(typeof(IAsyncBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IProjectRepository, ProjectRepository>();

            services.AddScoped<IBuildingRepository, BuildingRepository>();

            services.AddScoped<IPropertyRepository, PropertyRepository>();

            services.AddScoped<IOrderProductRepository, OrderProductRepository>();


            return services;

        }


    }
}
