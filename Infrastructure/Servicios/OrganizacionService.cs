using Azure.Core;
using Microsoft.EntityFrameworkCore;
using pruebaTecnicaEdynamicsLog.Domain.DTOs;
using pruebaTecnicaEdynamicsLog.Domain.Entities.OrgsYUsers;
using pruebaTecnicaEdynamicsLog.Domain.Entities.Productos;
using pruebaTecnicaEdynamicsLog.Domain.Interfaces;

namespace pruebaTecnicaEdynamicsLog.Infrastructure.Servicios
{
    public class OrganizacionService : IOrganizacionService
    {
        private readonly DbContextOrgsYUsers _context; // database context
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;

        public OrganizacionService(DbContextOrgsYUsers context, IConfiguration configuration, IServiceProvider serviceProvider)
        {
            _context = context;
            _configuration = configuration;
            _serviceProvider = serviceProvider;
        }


        public async Task<bool> CrearOrganizacion(CreateOrgRequest obj)
        {

            string newConnectionString = null;
            string dbName = obj.orgSlug;
            string defaultConnectionString = _configuration.GetConnectionString("productosDefaultConectionString");
            newConnectionString = defaultConnectionString.Replace("productosDefault", dbName);
            try
            {
                using IServiceScope scopeTenant = _serviceProvider.CreateScope();
                DbContextProductos dbContext = scopeTenant.ServiceProvider.GetRequiredService<DbContextProductos>();
                dbContext.Database.SetConnectionString(newConnectionString);
                if (dbContext.Database.GetPendingMigrations().Any())
                {
                    Console.WriteLine($"Aplicando las migraciones para la base de datos '{dbName}'.");
                    dbContext.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            var newOrg = new Organizacion()
            {
                Id = Guid.NewGuid(),
                Name = obj.orgName,
                SlugTenant = obj.orgSlug,
                Direccion = string.Empty,
            };

            var newUsuario = new Usuario()
            {
                Id = Guid.NewGuid(),
                Email = obj.email,
                Password = obj.password,
                OrganizacionId = newOrg.Id
            };

            _context.Organizaciones.Add(newOrg);
            _context.Usuarios.Add(newUsuario);
            await _context.SaveChangesAsync();

            return true;


        }
    }
}
