using AggregationApp.Domain.Abstractions;

namespace AggregationApp.Domain.Apartments;

public class Apartment : BaseEntity
{
    public string TINKLAS { get; private set; }
    public string OBT_PAVADINIMAS { get; private set; }
    public string OBJ_GV_TIPAS { get; private set; }
    public int OBJ_NUMERIS { get; private set; }
    public decimal P_PLUS { get; private set; }
    public DateTime PL_T { get; private set; }
    public decimal P_MINUS { get; private set; }

    private Apartment()
    {
        // This empty constructor is required for Dapper materialization
    }

    public Apartment(string TINKLAS, string OBT_PAVADINIMAS, string OBJ_GV_TIPAS, int OBJ_NUMERIS, decimal P_PLUS, DateTime PL_T, decimal P_MINUS)
    {
        SET_TINKLAS(TINKLAS);
        SET_OBT_PAVADINIMAS(OBT_PAVADINIMAS);
        SET_OBJ_GV_TIPAS(OBJ_GV_TIPAS);
        SET_OBJ_NUMERIS(OBJ_NUMERIS);
        SET_PL_T(PL_T);
        this.P_PLUS = P_PLUS;
        this.P_MINUS = P_MINUS;
    }

    public void SET_TINKLAS(string TINKLAS)
    {
        if (string.IsNullOrWhiteSpace(TINKLAS))
            throw new ArgumentException("Tinklas cannot be empty.");

        this.TINKLAS = TINKLAS;
    }

    public void SET_OBT_PAVADINIMAS(string OBT_PAVADINIMAS)
    {
        if (string.IsNullOrWhiteSpace(OBT_PAVADINIMAS))
            throw new ArgumentException("OBT_PAVADINIMAS cannot be empty.");

        this.OBT_PAVADINIMAS = OBT_PAVADINIMAS;
    }

    public void SET_OBJ_GV_TIPAS(string OBJ_GV_TIPAS)
    {
        this.OBJ_GV_TIPAS = OBJ_GV_TIPAS;
    }

    public void SET_OBJ_NUMERIS(int OBJ_NUMERIS)
    {
        this.OBJ_NUMERIS = OBJ_NUMERIS;
    }
    public void SET_PL_T(DateTime dateTime)
    {
        this.PL_T = dateTime;
    }

}
