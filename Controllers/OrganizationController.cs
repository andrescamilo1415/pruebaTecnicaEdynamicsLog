using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using pruebaTecnicaEdynamicsLog.Domain.DTOs;
using pruebaTecnicaEdynamicsLog.Domain.Interfaces;

namespace pruebaTecnicaEdynamicsLog.Controllers
{
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private IOrganizacionService _orgService;
        public OrganizationController(IOrganizacionService orgService)
        {
            _orgService = orgService;
        }


        [AllowAnonymous]
        [Route("api/[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> CrearOrganizacion([FromBody] Domain.DTOs.CreateOrgRequest obj)
        {
            try
            {


                var result = await _orgService.CrearOrganizacion(obj);

                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
