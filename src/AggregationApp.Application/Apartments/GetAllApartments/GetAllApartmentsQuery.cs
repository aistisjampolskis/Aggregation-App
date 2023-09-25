using MediatR;

namespace AggregationApp.Application.Apartments.GetAllApartments;

public class GetAllApartmentsQuery : IRequest<List<ApartmentResponse>>
{
}