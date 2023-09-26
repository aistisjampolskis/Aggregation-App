using MediatR;

namespace AggregationApp.Application.Apartments.GetAllApartments;

public class GetAllApartmentsQuery : IRequest<List<ApartmentResponse>>
{
    public int Page { get; set; }
    public int PageSize { get; set; }

    public GetAllApartmentsQuery(int page, int pageSize)
    {
        Page = page;
        PageSize = pageSize;
    }
}