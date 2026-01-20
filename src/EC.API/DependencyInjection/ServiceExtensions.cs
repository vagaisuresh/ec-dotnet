namespace EC.API.DependencyInjection;

public static class ServiceExtensions
{
    public static void AddCorsPolicies(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("Cors", builder =>
            {
                builder.WithOrigins("http://localhost:5284")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
    }
}