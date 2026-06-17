using CleanArch.Application.IQueries;
using CleanArch.Domain.Book;
using CleanArch.Domain.IRepositories;
using CleanArch.Infrastructure.Queries;
using CleanArch.Infrastructure.Repositories;
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

        // Add unit of work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Add repositories
        services.AddScoped<IBookRepository, BookCommandRepository>();
        services.AddScoped<IMemberRepository, MemberRepository>();

        // Add queries
        services.AddScoped<IBookQueries, BookQueries>();
        services.AddScoped<IMemberQueries, MemberQueries>();

        return services;
    }
}