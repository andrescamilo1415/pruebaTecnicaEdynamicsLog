using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using pruebaTecnicaEdynamicsLog.Domain.DTOs;
using pruebaTecnicaEdynamicsLog.Domain.Interfaces;

namespace pruebaTecnicaEdynamicsLog.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/{Tenant}/[controller]/[action]")]
        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            var list = await _productService.GetProductos();
            return Ok(list);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/{Tenant}/[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> AddProducto([FromBody] AddProductoDto obj)
        {
            var result = await _productService.AddProducto(obj);
            return Ok(result);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/{Tenant}/[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> EditProducto([FromBody] EditProductoDto obj)
        {
            var result = await _productService.EditProducto(obj);
            return Ok(result);
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/{Tenant}/[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> DeleteProducto([FromBody] GuidDto obj)
        {
            var result = await _productService.DeleteProducto(obj.Id);
            return Ok(result);
        }


    }
}
