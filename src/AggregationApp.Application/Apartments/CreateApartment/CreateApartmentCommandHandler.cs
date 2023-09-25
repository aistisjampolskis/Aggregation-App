using MediatR;
using AggregationApp.Domain.Abstractions;
using AggregationApp.Domain.Apartments;

namespace AggregationApp.Application.Apartments.CreateApartment;

public class CreateApartmentCommandHandler : IRequestHandler<CreateApartmentCommand, int>
{
    private readonly IApartmentRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateApartmentCommandHandler(IApartmentRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateApartmentCommand command, CancellationToken cancellationToken)
    {
        var apartment = new Apartment(command.TINKLAS, command.OBT_PAVADINIMAS, command.OBJ_GV_TIPAS, command.OBJ_NUMERIS, command.P_PLUS, command.PL_T, command.P_MINUS);

        await _repository.AddAsync(apartment);
        _unitOfWork.Commit();

        return apartment.Id;
    }
}