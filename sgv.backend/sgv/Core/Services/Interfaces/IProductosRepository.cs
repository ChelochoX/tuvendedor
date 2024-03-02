using sgv.Core.Entities;

namespace sgv.Core.Services.Interfaces;

public interface IProductosRepository
{
    Task<Articulo> ObtenerArticuloporCodigo(string codigo);
    Task<Articulo> ObtenerArticuloporGrupo(string grupo);

}
