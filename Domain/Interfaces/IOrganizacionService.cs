using pruebaTecnicaEdynamicsLog.Domain.DTOs;

namespace pruebaTecnicaEdynamicsLog.Domain.Interfaces
{
    public interface IOrganizacionService
    {
        Task<bool> CrearOrganizacion(CreateOrgRequest obj);
    }
}
