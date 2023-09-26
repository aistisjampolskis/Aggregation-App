namespace AggregationApp.Domain.Apartments;

public interface IApartmentRepository
{
    Task<Apartment> GetByIdAsync(int id);
    Task<List<Apartment>> GetAllAsyncPaginated(int skipAmount, int pageSize);

}
