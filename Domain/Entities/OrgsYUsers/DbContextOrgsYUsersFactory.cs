using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace pruebaTecnicaEdynamicsLog.Domain.Entities.OrgsYUsers
{
    public class DbContextOrgsYUsersFactory : IDesignTimeDbContextFactory<DbContextOrgsYUsers>
    {
        public DbContextOrgsYUsers CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Retrieve the connection string from the configuration
            string connectionString = configuration.GetConnectionString("OrgsYUsersConectionString");
            DbContextOptionsBuilder<DbContextOrgsYUsers> optionsBuilder = new();
            _ = optionsBuilder.UseSqlServer(connectionString);
            return new DbContextOrgsYUsers(optionsBuilder.Options);
        }
    }
}
