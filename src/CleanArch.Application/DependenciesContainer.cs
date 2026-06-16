using CleanArch.Application.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Application;

public static class DependenciesContainer
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // add MediatR
        services.AddMediatR(options =>
            options.RegisterServicesFromAssemblyContaining(typeof(DependenciesContainer)));

        // add Fluent validation
        services.AddValidatorsFromAssembly(typeof(DependenciesContainer).Assembly);

        // add mapster configs
        TypeAdapterConfig.GlobalSettings.Scan(typeof(DependenciesContainer).Assembly);

        // add Validation behavior
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}