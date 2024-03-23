using AutoMapper;
using Dapper;
using sgv.Core.Entities;
using sgv.Core.Exceptions;
using sgv.Core.Services.Interfaces;

namespace sgv.Persistence.Repositories;

public class ProductoRepository : IProductosRepository
{
    private readonly DbConnections _conexion;
    private readonly ILogger<ProductoRepository> _logger;
    private readonly IMapper _mapper;

    public ProductoRepository(DbConnections conexion, ILogger<ProductoRepository> logger, IMapper mapper)
    {
        _conexion = conexion;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<Articulo> ObtenerArticuloporCodigo(string codigo)
    {
        _logger.LogInformation("Inicio de Proceso para obtener datos del articulo por codigo");

        string query = @"SELECT a.idarticulo, a.codigo, a.nombre, a.descripcion, a.grupo,
                        p.idplandepago, p.entrega, p.cuota, p.importe, p.moneda
                        FROM articulo a
                        LEFT JOIN planesdepago p ON a.idarticulo = p.idarticulo
                        WHERE a.codigo = @Codigo";
        try
        {
            using (var connection = this._conexion.CreateSqlConnectionLocalDB())
            {
                var lookup = new Dictionary<int, Articulo>();

                var resultados = await connection.QueryAsync<Articulo, PlanDePago, Articulo>(
                    query,
                    (articulo, planDePago) =>
                    {
                        if (!lookup.TryGetValue(articulo.IdArticulo, out var articuloEncontrado))
                        {
                            articuloEncontrado = articulo;
                            articuloEncontrado.PlanesDePago = new List<PlanDePago>();
                            lookup.Add(articuloEncontrado.IdArticulo, articuloEncontrado);
                        }

                        articuloEncontrado.PlanesDePago.Add(planDePago);

                        return articuloEncontrado;
                    },
                    new { Codigo = codigo },
                    splitOn: "idplandepago");

                var articulo = resultados.FirstOrDefault();


                _logger.LogInformation("Fin de Proceso para obtener datos del articulo por codigo");
                return articulo;
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
