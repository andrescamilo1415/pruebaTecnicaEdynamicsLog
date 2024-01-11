using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using pruebaTecnicaEdynamicsLog.Domain.DTOs;
using pruebaTecnicaEdynamicsLog.Domain.Entities.OrgsYUsers;
using pruebaTecnicaEdynamicsLog.Domain.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace pruebaTecnicaEdynamicsLog.Infrastructure.Servicios
{
    public class CurrentTenantService : ICurrentTenantService
    {
        public string? TenantId { get; set; }
        public string? TenantSlug { get; set; }

        private readonly DbContextOrgsYUsers _contexto;

        public CurrentTenantService(DbContextOrgsYUsers contexto)
        {

            this._contexto = contexto;
        }

        public async Task<bool> SetTenant(string tenant)
        {
            var tenantInfo = await _contexto.Organizaciones.FirstOrDefaultAsync(x => x.SlugTenant == tenant);
            if (tenantInfo != null)
            {
                TenantId=tenantInfo.Id.ToString();
                TenantSlug = tenantInfo.SlugTenant;
                return true;

            }
            else
            {
            throw new Exception("Tenant invalido");
            }
        }

    }
}
