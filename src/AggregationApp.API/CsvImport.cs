using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration.Attributes;
using CsvHelper.Configuration;
using AggregationApp.Domain.Apartments;



public static class CsvImport
{


    public static async Task ImportCsvAsync(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException(nameof(configuration));

        string csvUrl = "https://data.gov.lt/dataset/1975/download/10743/2020-06.csv";

        using (HttpClient httpClient = new HttpClient())
        {
            string csvData = await httpClient.GetStringAsync(csvUrl);

            using (TextReader reader = new StringReader(csvData))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                var records = csv.GetRecords<ApartmentMapped>().ToList();

                using (IDbConnection dbConnection = new MySqlConnection(connectionString))
                {
                    dbConnection.Open();

                    //Clear Database on Init
                    await dbConnection.ExecuteAsync("DELETE FROM Apartments");

                    // Create the "Apartments" table if it doesn't exist
                    await dbConnection.ExecuteAsync(@"
                    CREATE TABLE IF NOT EXISTS Apartments (
                        Id INT AUTO_INCREMENT PRIMARY KEY,
                        TINKLAS VARCHAR(255) NOT NULL,
                        OBT_PAVADINIMAS VARCHAR(255) NOT NULL,
                        OBJ_GV_TIPAS ENUM('G', 'N', 'Ne GV') NOT NULL,
                        OBJ_NUMERIS VARCHAR(255) NOT NULL,
                        P_PLUS DECIMAL(10, 4),
                        PL_T DATETIME NOT NULL,
                        P_MINUS DECIMAL(10, 4)
                    );"
                    );

                    Console.WriteLine("Loading CSV");
                    Console.WriteLine(records.Count);

                    // We set max concurrent don't exceed maximum database connections
                    var maxConcurrentTasks = 10;
                    var semaphore = new SemaphoreSlim(maxConcurrentTasks);

                    // Use Parallel.ForEach to insert records concurrently
                    Parallel.ForEach(records, async record =>
                    {
                        await semaphore.WaitAsync();
                        try
                        {
                            using (IDbConnection dbConnection = new MySqlConnection(connectionString))
                            {
                                await dbConnection.ExecuteAsync(@"
                            INSERT INTO Apartments (TINKLAS, OBT_PAVADINIMAS, OBJ_GV_TIPAS, OBJ_NUMERIS, P_PLUS, PL_T, P_MINUS)
                            VALUES (@TINKLAS, @OBT_PAVADINIMAS, @OBJ_GV_TIPAS, @OBJ_NUMERIS, @P_PLUS, @PL_T, @P_MINUS)
                             ", record);
                            }
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    });

                    Console.WriteLine("Loaded CSV!");
                }
            }
        }
    }
}


public class ApartmentMapped
{
    public string TINKLAS { get; set; }
    public string OBT_PAVADINIMAS { get; set; }
    public string OBJ_GV_TIPAS { get; set; }
    public string OBJ_NUMERIS { get; set; }
    [Name("P+")]  // Use the CsvField attribute to map the "P+" column
    public decimal? P_PLUS { get; set; }

    public DateTime PL_T { get; set; }

    [Name("P-")]  // Use the CsvField attribute to map the "P-" column
    public decimal? P_MINUS { get; set; }
}
