using CleanArch.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infrastructure;

public static class DependenciesContainer
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Add context
        services.AddDbContext<ApplicationDbContext>(options
            => options.UseSqlServer(configuration
                .GetConnectionString("DefaultConnection")));

        return services;
    }
}