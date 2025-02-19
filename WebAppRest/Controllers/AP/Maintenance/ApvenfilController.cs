using BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common.ViewModels;
using BusinessEntity.Data.Models;


namespace WebAppRest.Controllers.AP.Maintenance
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApvenfilController : ControllerBase
    {
        private readonly ApvenfilService _apvenfilService;
        public ApvenfilController(ApvenfilService apvenfilService)
        {
            _apvenfilService = apvenfilService;
        }

        [HttpPost]
        public async Task<IActionResult> InsertarProveedor([FromBody] InsertarProveedor request)
        {
            if (request.Apvenfil == null || request.Apvenext == null)
                return BadRequest("Los datos del proveedor y son obligatorios.");

            var resultado = await _apvenfilService.F_InsertarProveedor(request.Apvenfil, request.Apvenext);

            if (resultado <= 0)
                return StatusCode(500, "Error al insertar el proveedor.");

            return Ok("Proveedor insertado correctamente.");
        }
    }
}
