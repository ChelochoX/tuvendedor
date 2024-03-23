using sgv.Core.DTOs;
using sgv.Core.Entities;

namespace sgv.Core.Services.Interfaces;

public interface IProductosService
{
    Task<ArticuloDTO> ObtenerArticuloporCodigo(string codigo);
    Task<Articulo> ObtenerArticuloporGrupo(string grupo);
}
