using Microsoft.EntityFrameworkCore;
using Notenverwaltung.API.DataAccess;
using Notenverwaltung.API.DataAccess.Repositories;
using Notenverwaltung.API.DataAccess.Repositories.Abstract;

namespace DataAccess;

public static class DataDependency
{
    public static void AddDataAccess(this IServiceCollection services, IConfiguration config)
    {
        string? connectionString = config.GetConnectionString("DefaultConnection");

        services.AddDbContext<DBContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        services.AddScoped<IUserRepository, UserRepository>();

    }
}
