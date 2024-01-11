using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace pruebaTecnicaEdynamicsLog.Domain.Entities.OrgsYUsers
{
    public class DbContextOrgsYUsers : DbContext
    {

        public DbContextOrgsYUsers(DbContextOptions<DbContextOrgsYUsers> options) : base(options)
        {
        }

        public DbSet<Organizacion> Organizaciones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
