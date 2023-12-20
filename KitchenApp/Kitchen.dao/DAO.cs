using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class DAO
{
    private readonly string connectionString;

    public DAO()
    {
        // Récupérer la chaîne de connexion depuis le fichier de configuration
        connectionString = ConfigurationManager.ConnectionStrings["BDD_RESTAUConnectionString"].ConnectionString;
    }

    public IDbConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }
}