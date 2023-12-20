using System.Collections.Generic;
using System.Data;
using Dapper;

public class KitchenToolsDAO
{
    private readonly IDbConnection connection;


    public KitchenToolsDAO(IDbConnection connection)
    {
        this.connection = connection;
    }

    public IEnumerable<StockRecette> GetAllStockMateriels()
    {
        string query = "EXEC RécupérerStockMateriel";
        return connection.Query<StockRecette>(query);
    }
}