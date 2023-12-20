using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class DAO
{
    private readonly string connectionString;

    public DAO()
    {
        // Récupérer la chaîne de connexion depuis le fichier de configuration
        connectionString = "Server=LEONARD\\LEONARD;Database=BDD_RESTAU;Trusted_Connection=True";
    }

    public IDbConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }
}