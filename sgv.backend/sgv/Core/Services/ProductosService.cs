using AutoMapper;
using sgv.Core.DTOs;
using sgv.Core.Entities;
using sgv.Core.Services.Interfaces;

namespace sgv.Core.Services;

public class ProductosService : IProductosService
{
    private readonly IProductosRepository _repository;
    private readonly IMapper _mapper;

    public ProductosService(IProductosRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ArticuloDTO> ObtenerArticuloporCodigo(string codigo)
    {
        var resultado = await _repository.ObtenerArticuloporCodigo(codigo);
        var articulo = _mapper.Map<Articulo>(resultado);
        var articuloDTO = _mapper.Map<ArticuloDTO>(articulo);
        return articuloDTO;
    }

    public async Task<Articulo> ObtenerArticuloporGrupo(string grupo)
    {
        throw new NotImplementedException();
    }
}
