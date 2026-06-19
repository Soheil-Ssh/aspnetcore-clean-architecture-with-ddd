using CleanArch.Application.IQueries;
using CleanArch.Infrastructure.Queries;
using CleanArch.Infrastructure.Repositories;
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

        // Add unit of work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Add repositories
        services.AddScoped<IBookRepository, BookCommandRepository>();
        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<ILoanRepository, LoanRepository>();

        // Add queries
        services.AddScoped<IBookQueries, BookQueries>();
        services.AddScoped<IMemberQueries, MemberQueries>();

        return services;
    }
}