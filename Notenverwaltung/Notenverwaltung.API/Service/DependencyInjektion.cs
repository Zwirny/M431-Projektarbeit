using DataAccess;
using Notenverwaltung.API.Service.Services;
using Notenverwaltung.API.Service.Services.Abstract;

namespace Notenverwaltung.API.Service
{
    public static class DependencyInjektion
    {
        public static void AddLogicServices(this IServiceCollection services, IConfiguration config)
        {
            // First, register the data access layer that the logic services depend on.
            services.AddDataAccess(config);

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IGradeService, GradeService>();

        }
    }
}
