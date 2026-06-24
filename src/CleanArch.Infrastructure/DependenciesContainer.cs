using CleanArch.Application.IQueries;
using CleanArch.Infrastructure.Data.Interceptors;
using CleanArch.Infrastructure.Queries;
using CleanArch.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infrastructure;

public static class DependenciesContainer
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Add interceptors
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();

        // Add context
        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

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