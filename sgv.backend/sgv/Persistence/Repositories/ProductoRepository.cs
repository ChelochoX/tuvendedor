using Dapper;
using sgv.Core.Entities;
using sgv.Core.Exceptions;
using sgv.Core.Services.Interfaces;

namespace sgv.Persistence.Repositories;

public class ProductoRepository : IProductosRepository
{
    private readonly DbConnections _conexion;
    private readonly ILogger<ProductoRepository> _logger;

    public ProductoRepository(DbConnections conexion, ILogger<ProductoRepository> logger)
    {
        _conexion = conexion;
        _logger = logger;
    }
    
    public async Task<Articulo> ObtenerArticuloporCodigo(string codigo)
    {
        _logger.LogInformation("Inicio de Proceso para obtener datos del articulo por codigo");

        string query = @"SELECT idarticulo
                              ,codigo
                              ,nombre
                              ,descripcion
                              ,grupo
                          FROM articulo
                          WHERE grupo =@Codigo";
        try
        {
            using (var connection = this._conexion.CreateSqlConnectionLocalDB())
            {
                var resultado = await connection.QueryFirstOrDefaultAsync<Articulo>(query, new { Codigo = codigo });
                _logger.LogInformation("Fin de Proceso para obtener datos del articulo por codigo");
                return resultado;
            }
        }
        catch (Exception ex)
        {
            throw new ObtenerArticuloException("Ocurrio un error al intentar obtener datos del articulo de la base de datos");
        }
    }

    public async Task<Articulo> ObtenerArticuloporGrupo(string grupo)
    {
        throw new NotImplementedException();
    }
}
