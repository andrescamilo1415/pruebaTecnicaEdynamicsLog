using pruebaTecnicaEdynamicsLog.Domain.DTOs;

namespace pruebaTecnicaEdynamicsLog.Domain.Interfaces
{
    public interface ISeguridadService
    {
        Task<string> Autenticar(AutenticarRqst obj);
    }
}
