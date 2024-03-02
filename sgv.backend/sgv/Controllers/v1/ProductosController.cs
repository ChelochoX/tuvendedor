using Microsoft.AspNetCore.Mvc;
using sgv.Core.DTOs;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace sgv.Controllers.v1;

[Route("api/v1/[controller]")]
[ApiController]

public class ProductosController : ControllerBase
{

    [HttpGet]
    //[AuthorizeResource("LeerTodos")]
    [SwaggerOperation(
     Summary = "Nos permite obtener informacion de los Usuarios de la BBDD del Poder Judicial",
     Description = "Obtiene información de Usuarios que pertenecen a la BBDD del Poder Judicial.")]
        public async Task<ActionResult<ArticuloDTO>> ObtenerArticuloPorCodigo()
        {


            var listado = await _service.ObtenerDatosdeUsuariosPoderJudicial();
            if (listado.Any())
            {
                return Ok(new ApiResponse<List<UsuarioBBDDPoderJudicialDTO>>
                {
                    Success = true,
                    Data = (List<UsuarioBBDDPoderJudicialDTO>)listado,
                    StatusCode = (int)HttpStatusCode.OK
                });
            }
            else
            {
                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Data = null,
                    StatusCode = (int)HttpStatusCode.OK,
                    Errors = new List<string> { "La lista de elementos está vacía" }
                });
            }
        }
}
