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

    public async Task<List<Apartment>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Apartments";
        var Apartments = await _connection.QueryAsync<Apartment>(sql);
        return Apartments.ToList();
    }

    public async Task AddAsync(Apartment item)
    {
        const string sql = "INSERT INTO Apartments (Title, DueDate, IsCompleted) VALUES (@Title, @DueDate, @IsCompleted)";
        await _connection.ExecuteAsync(sql, item);
    }
}
