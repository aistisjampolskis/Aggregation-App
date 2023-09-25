using MediatR;

namespace AggregationApp.Application.Apartments.CreateApartment;

public class CreateApartmentCommand : IRequest<int>
{
    public string TINKLAS { get; private set; }
    public string OBT_PAVADINIMAS { get; private set; }
    public string OBJ_GV_TIPAS { get; private set; }
    public int OBJ_NUMERIS { get; private set; }
    public decimal P_PLUS { get; private set; }
    public DateTime PL_T { get; private set; }
    public decimal P_MINUS { get; private set; }

}
