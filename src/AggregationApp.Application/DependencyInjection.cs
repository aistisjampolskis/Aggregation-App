using Microsoft.Extensions.DependencyInjection;
using AggregationApp.Application.Context;
using AggregationApp.Domain.Abstractions;
using AggregationApp.Domain.Apartments;

namespace AggregationApp.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });

        return services;
    }
}