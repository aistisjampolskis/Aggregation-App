namespace AggregationApp.Domain.Apartments;

public interface IApartmentRepository
{
    Task<Apartment> GetByIdAsync(int id);
    Task<List<Apartment>> GetAllAsync();
    Task AddAsync(Apartment item);

}
