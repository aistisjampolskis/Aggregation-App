using MediatR;
using AggregationApp.Domain.Apartments;

namespace AggregationApp.Application.Apartments.GetApartment;

public class GetApartmentByIdQueryHandler : IRequestHandler<GetApartmentByIdQuery, ApartmentResponse>
{
    private readonly IApartmentRepository _repository;

    public GetApartmentByIdQueryHandler(IApartmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<ApartmentResponse> Handle(GetApartmentByIdQuery query, CancellationToken cancellationToken)
    {
        var apartment = await _repository.GetByIdAsync(query.Id);
        if (apartment == null) return null;

        return new ApartmentResponse()
        {
            Id = apartment.Id,
            TINKLAS = apartment.TINKLAS,
        };
    }
}