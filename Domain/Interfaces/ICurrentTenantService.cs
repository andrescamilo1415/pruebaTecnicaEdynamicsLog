using pruebaTecnicaEdynamicsLog.Domain.DTOs;

namespace pruebaTecnicaEdynamicsLog.Domain.Interfaces
{
    public interface ICurrentTenantService
    {
        string? TenantId { get; set; }
        string? TenantSlug { get; set; }
        Task<bool> SetTenant(string tenant);
    }
}
