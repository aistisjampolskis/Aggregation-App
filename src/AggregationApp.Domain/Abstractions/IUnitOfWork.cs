namespace AggregationApp.Domain.Abstractions;

public interface IUnitOfWork : IDisposable
{
    int Commit();
}
