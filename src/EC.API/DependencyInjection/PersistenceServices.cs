using EC.Domain.Interfaces;
using EC.Persistence.Context;
using EC.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EC.API.DependencyInjection;

public static class PersistenceServices
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IBrandRepository, BrandRepository>();
    }

    public static void AddAppDbContext(this IServiceCollection services)
    {
        string connectionString = Environment.GetEnvironmentVariable("SqlConnection__TiaanoCloud") ?? string.Empty;

        if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException("Database connection string is not set in environment variables.");
        
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
    }
}