using AggregationApp.Domain.Abstractions;

namespace AggregationApp.Domain.Apartments;

public class Apartment : BaseEntity
{
    public string TINKLAS { get; private set; }
    public string OBT_PAVADINIMAS { get; private set; }
    public string OBJ_GV_TIPAS { get; private set; }
    public int OBJ_NUMERIS { get; private set; }
    public decimal? P_PLUS { get; private set; }
    public DateTime PL_T { get; private set; }
    public decimal? P_MINUS { get; private set; }

    private Apartment()
    {
        // This empty constructor is required for Dapper materialization
    }

    public Apartment(string TINKLAS, string OBT_PAVADINIMAS, string OBJ_GV_TIPAS, int OBJ_NUMERIS, decimal? P_PLUS, DateTime PL_T, decimal? P_MINUS)
    {
        this.TINKLAS = TINKLAS;
        this.OBT_PAVADINIMAS = OBT_PAVADINIMAS;
        this.OBJ_GV_TIPAS = OBJ_GV_TIPAS;
        this.OBJ_NUMERIS = OBJ_NUMERIS;
        this.P_PLUS = P_PLUS;
        this.P_MINUS = P_MINUS;
        this.PL_T = PL_T;
    }
}
