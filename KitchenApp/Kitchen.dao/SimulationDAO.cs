using System.Collections.Generic;
using System.Data;
using Dapper;

public class SimulationDAO
{
    private readonly IDbConnection connection;

    public SimulationDAO(IDbConnection connection)
    {
        this.connection = connection;
    }

    public IEnumerable<Simulation> AfficherInformationsSimulation()
    {
        string query = "EXEC AfficherInformationsSimulation";
        return connection.Query<Simulation>(query);
    }

    public IEnumerable<StockRecette> RécupérerStockRecettes()
    {
        string query = "EXEC RécupérerStockRecettes";
        return connection.Query<StockRecette>(query);
    }

    public IEnumerable<AlimentStocke> RécupérerStockAliments()
    {
        string query = "EXEC RécupérerStockAliments";
        return connection.Query<AlimentStocke>(query);
    }

    public IEnumerable<StockMateriel> RécupérerStockMateriel()
    {
        string query = "EXEC RécupérerStockMateriel";
        return connection.Query<StockMateriel>(query);
    }

    public void MettreAJourStockAlimentsFrais()
    {
        string query = "EXEC MettreAJourStockAliments_Frais";
        connection.Execute(query);
    }

    public void MettreAJourStockAlimentsSurgeles()
    {
        string query = "EXEC MettreAJourStockAliments_Surgelés";
        connection.Execute(query);
    }
}