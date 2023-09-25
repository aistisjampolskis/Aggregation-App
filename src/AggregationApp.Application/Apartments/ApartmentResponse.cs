namespace AggregationApp.Application.Apartments;

public class ApartmentResponse
{
    public int Id { get; set; }
    public string TINKLAS { get; set; }
    public string OBT_PAVADINIMAS { get; set; }
    public string OBJ_GV_TIPAS { get; set; }
    public int OBJ_NUMERIS { get; set; }
    public decimal P_PLUS { get; set; }
    public DateTime PL_T { get; set; }
    public decimal P_MINUS { get; set; }

}