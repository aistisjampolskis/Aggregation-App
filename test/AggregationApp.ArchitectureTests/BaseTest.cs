using System.Reflection;
using AggregationApp.Application.Context;
using AggregationApp.Infrastructure.Data;
using AggregationApp.Domain.Abstractions;

namespace AggregationApp.ArchitectureTests;

public class BaseTest
{
    protected static Assembly ApplicationAssembly => typeof(DapperUnitOfWork).Assembly;
    protected static Assembly DomainAssembly => typeof(BaseEntity).Assembly;
    protected static Assembly InfrastructureAssembly => typeof(MySqlConnectionFactory).Assembly;
}