using AggregationApp.Infrastructure.Data;

namespace AggregationApp.Infrastructure.Repositories;

using Dapper;
using System.Data;
using AggregationApp.Domain.Apartments;

public class ApartmentRepository : IApartmentRepository
{
    private readonly IDbConnection _connection;

    public ApartmentRepository(MySqlConnectionFactory connectionFactory)
    {
        _connection = connectionFactory.CreateConnection();
    }

    public async Task<Apartment> GetByIdAsync(int id)
    {
        const string sql = "SELECT * FROM Apartments WHERE Id = @Id";
        return await _connection.QuerySingleOrDefaultAsync<Apartment>(sql, new { Id = id });
    }

    public async Task<List<Apartment>> GetAllAsyncPaginated(int skipAmount, int pageSize)
    {
        const string sql = "SELECT * FROM Apartments GROUP BY Id ORDER BY TINKLAS LIMIT @SkipAmount, @PageSize";
        var parameters = new { SkipAmount = skipAmount, PageSize = pageSize };
        var apartments = await _connection.QueryAsync<Apartment>(sql, parameters);
        return apartments.ToList();
    }
}
