using Microsoft.EntityFrameworkCore;
using pruebaTecnicaEdynamicsLog.Domain.Entities.OrgsYUsers;
using pruebaTecnicaEdynamicsLog.Domain.Entities.Productos;

namespace pruebaTecnicaEdynamicsLog.Extenciones
{
    public static class MultipleDatabaseExtensions
    {
        public static IServiceCollection AddAndMigrateTenantDatabases(this IServiceCollection services, IConfiguration configuration)
        {
            using IServiceScope scopeTenant = services.BuildServiceProvider().CreateScope();
            DbContextOrgsYUsers orgsDbContext = scopeTenant.ServiceProvider.GetRequiredService<DbContextOrgsYUsers>();

            if (orgsDbContext.Database.GetPendingMigrations().Any())
            {
                orgsDbContext.Database.Migrate(); //aqui agrego las migraciones pendientes al contexto maestro
            }

            List<Organizacion> lstOrganizaciones = orgsDbContext.Organizaciones.ToList();

            string defaultConnectionString = configuration.GetConnectionString("OrgsYUsersConectionString");

            foreach (Organizacion orgTemp in lstOrganizaciones) 
            {
                string connectionString = $"Data Source=localhost;Initial Catalog={orgTemp.SlugTenant};User ID=sa;Password=andrescamilo1415!;TrustServerCertificate=True;";
                using IServiceScope scopeApplication = services.BuildServiceProvider().CreateScope();
                DbContextProductos dbContext = scopeTenant.ServiceProvider.GetRequiredService<DbContextProductos>();
                dbContext.Database.SetConnectionString(connectionString);
                if (dbContext.Database.GetPendingMigrations().Any())
                {
                    Console.WriteLine($"Ejecutando la migracion de la base de datos '{orgTemp.SlugTenant}'.");
                    dbContext.Database.Migrate();
                }
            }
            return services;
        }
    }
}
