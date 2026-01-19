using EC.Application.Features.Brands.Handlers;

namespace EC.API.DependencyInjection;

public static class ApplicationServices
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<CreateBrandCommandHandler>();
    }
}