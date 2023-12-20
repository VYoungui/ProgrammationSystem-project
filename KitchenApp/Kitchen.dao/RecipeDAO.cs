using System.Collections.Generic;
using System.Data;
using Dapper;

public class RecipeDAO
{
    private readonly IDbConnection connection;

    public RecipeDAO(IDbConnection connection)
    {
        this.connection = connection;
    }

    public IEnumerable<StockRecette> GetAllStockRecettes()
    {
        string query = "EXEC RécupérerStockRecettes";
        return connection.Query<StockRecette>(query);
    }
}