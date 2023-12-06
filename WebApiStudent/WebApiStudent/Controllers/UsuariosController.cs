using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiLibrary.Models.Custom;
using WebApiLibrary.Services;



namespace WebApiLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IAutorizacionService _autorizacionService;

        public UsuariosController(IAutorizacionService autorizacionService)
        {
            _autorizacionService = autorizacionService;
        }

        [HttpPost]
        [Route("Autenticar")]
        public async Task<IActionResult> Autenticar([FromBody]AutorizacionRequest autorizacion)
        {
            var resultado_autorizacion = await _autorizacionService.DevolverToken(autorizacion);

            if (resultado_autorizacion == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(resultado_autorizacion);
            }
            

        }

    }
}
