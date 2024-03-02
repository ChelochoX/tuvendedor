using Microsoft.Data.SqlClient;
using System.Data;

namespace sgv.Persistence;

public class DbConnections
{
    private readonly string _connection;

    public DbConnections(IConfiguration configuration)
    {
        _connection = configuration.GetConnectionString("Local");

    }
    //Conexion a mi base local
    public IDbConnection CreateSqlConnectionLocalDB() => new SqlConnection(_connection);

}
