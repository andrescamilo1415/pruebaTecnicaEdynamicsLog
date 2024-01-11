using Microsoft.IdentityModel.Tokens;
using pruebaTecnicaEdynamicsLog.Domain.Interfaces;

namespace pruebaTecnicaEdynamicsLog.Aplication.Middleware
{
    public class TenantResolver
    {
        private readonly RequestDelegate _next;
        public TenantResolver(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ICurrentTenantService currentTenantService)
        {

            var tenantValue = context.GetRouteValue("tenant");
            var routeName = context.GetRouteValue("name");

            //  context.Request.Headers.TryGetValue("tenant", out var tenantFromHeader);
            if (tenantValue!=null)
            {
                //aqui adiciono el tenant a un servicio
                await currentTenantService.SetTenant(tenantValue!.ToString());
            }
            await _next(context);
        }

    }
}
