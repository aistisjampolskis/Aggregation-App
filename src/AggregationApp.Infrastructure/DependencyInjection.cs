using System.Reflection;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AggregationApp.Application.Context;
using AggregationApp.Domain.Abstractions;
using AggregationApp.Infrastructure.Data;
using AggregationApp.Infrastructure.Repositories;

namespace AggregationApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("DefaultConnection") ??
            throw new ArgumentNullException(nameof(configuration));

        var repositoryTypes = Assembly.GetAssembly(typeof(ApartmentRepository))
            ?.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Repository"))
            .ToList();

        foreach (var type in repositoryTypes)
        {
            var interfaceType = type.GetInterfaces().FirstOrDefault(i => i.Name == "I" + type.Name);
            if (interfaceType != null)
            {
                services.AddScoped(interfaceType, type);
            }
        }

        services.AddTransient<IUnitOfWork, DapperUnitOfWork>(c => new DapperUnitOfWork(connectionString));
        services.AddSingleton(new MySqlConnectionFactory(connectionString));
        SqlMapper.AddTypeHandler(new DateOnlyHandler());

        return services;
    }
}