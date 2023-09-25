using MediatR;
using AggregationApp.Domain.Apartments;

namespace AggregationApp.Application.Apartments.GetAllApartments;

public class GetAllApartmentsQueryHandler : IRequestHandler<GetAllApartmentsQuery, List<ApartmentResponse>>
{
    private readonly IApartmentRepository _repository;

    public GetAllApartmentsQueryHandler(IApartmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ApartmentResponse>> Handle(GetAllApartmentsQuery query, CancellationToken cancellationToken)
    {
        var apartments = await _repository.GetAllAsync();

        return apartments.Select(apartment => new ApartmentResponse
        {
            Id = apartment.Id,
            TINKLAS = apartment.TINKLAS,
            OBT_PAVADINIMAS = apartment.OBT_PAVADINIMAS,
            OBJ_GV_TIPAS = apartment.OBJ_GV_TIPAS,
            OBJ_NUMERIS = apartment.OBJ_NUMERIS,
            P_PLUS = apartment.P_PLUS,
            PL_T = apartment.PL_T,
            P_MINUS = apartment.P_MINUS,

        }).ToList();
    }
}