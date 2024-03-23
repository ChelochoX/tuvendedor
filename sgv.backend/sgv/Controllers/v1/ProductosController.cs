using Microsoft.AspNetCore.Mvc;
using sgv.Core.DTOs;
using sgv.Core.Exceptions;
using sgv.Core.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;
using System.Net;
using static sgv.Middlewares.ManejadorErroresMiddleware;

namespace sgv.Controllers.v1;

[Route("api/v1/[controller]")]
[ApiController]

public class ProductosController : ControllerBase
{
    private readonly IProductosService _service;

    public ProductosController(IProductosService service)
    {
        _service = service;
    }

    [HttpGet("codigoProducto")]
    //[AuthorizeResource("LeerporCodigo")]
    [SwaggerOperation(
        Summary = "Nos permite obtener informacion de los Usuarios de la BBDD del Poder Judicial por codigo ususario",
        Description = "Obtiene información de Usuarios que pertenecen a la BBDD del Poder Judicial por codigo usuario.")]
    public async Task<ActionResult<ArticuloDTO>> ListadoUsuariosporCodigo(
        [FromQuery][Description("Código único del usuario")] string codigoProducto)
    {
        if (string.IsNullOrEmpty(codigoProducto))
        {
            throw new ReglasdeNegocioException("El código de usuario no puede estar vacío o tener valor igual a cero");
        }
        var producto = await _service.ObtenerArticuloporCodigo(codigoProducto);   

        return Ok(new ApiResponse<ArticuloDTO>
        {
            Success = true,
            Data = (ArticuloDTO)producto,
            StatusCode = (int)HttpStatusCode.OK
        });
    }
}
