using MediatR;

namespace AggregationApp.Application.Apartments.GetApartment;

public class GetApartmentByIdQuery : IRequest<ApartmentResponse>
{
    public int Id { get; set; }
}