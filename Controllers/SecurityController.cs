using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using pruebaTecnicaEdynamicsLog.Domain.DTOs;
using pruebaTecnicaEdynamicsLog.Domain.Interfaces;

namespace pruebaTecnicaEdynamicsLog.Controllers
{
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private ISeguridadService _seguridadService;
        public SecurityController(ISeguridadService seguridadService)
        {
            _seguridadService = seguridadService;
        }


        [AllowAnonymous]
        [Route("api/[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> Autenticar([FromBody] AutenticarRqst usrPass)
        {
            var q = await _seguridadService.Autenticar(usrPass);
            if (q == string.Empty)
            {
                return BadRequest("Usuario o pass incorrectos");
            }
            return Ok(q);
        }
    }
}
