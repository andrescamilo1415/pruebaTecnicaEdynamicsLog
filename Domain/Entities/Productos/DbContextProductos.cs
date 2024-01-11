using Microsoft.EntityFrameworkCore;
using pruebaTecnicaEdynamicsLog.Domain.Interfaces;
using System.Collections.Generic;

namespace pruebaTecnicaEdynamicsLog.Domain.Entities.Productos
{
    public class DbContextProductos : DbContext
    {
        private readonly ICurrentTenantService tenantService;
        public string CurrentTenantId { get; set; }
       public string TenantSlug { get; set; }
        public DbContextProductos(DbContextOptions<DbContextProductos> options, ICurrentTenantService currentTenantService) : base(options)
        {

            tenantService = currentTenantService;
            CurrentTenantId = tenantService.TenantId;
            TenantSlug = tenantService.TenantSlug;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //Esta cadena de conexion tiene los parametros de conexio quemados, porque el servidor de base de datos es el mismo.
            string tenantConnectionString = $"Data Source=localhost;Initial Catalog={TenantSlug};User ID=sa;Password=andrescamilo1415!;TrustServerCertificate=True;";
            if (!string.IsNullOrEmpty(tenantConnectionString)) // use tenant db if one is specified
            {
                _ = optionsBuilder.UseSqlServer(tenantConnectionString);
            }
        }

        public DbSet<Producto> Productos { get; set; }


    }
}
