using System.Collections.Generic;
using System.Data;
using Dapper;

public class FoodStuffsDAO
{
    private readonly IDbConnection connection;

    public FoodStuffsDAO(IDbConnection connection)
    {
        this.connection = connection;
    }

    public IEnumerable<StockRecette> GetAllAlimentsStockes()
    {
        string query = "EXEC RécupérerStockAliments";
        return connection.Query<StockRecette>(query);
    }
}