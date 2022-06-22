using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Context.General
{
    public class GeneralFactory : IDesignTimeDbContextFactory<GeneralContext>
    {
        public GeneralContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("dbconfig.json")
                .Build();
            var optionsBuilder = new DbContextOptionsBuilder<GeneralContext>();
            var connectionString = configuration.GetConnectionString("GeneralConnection");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), b => b.MigrationsAssembly(typeof(GeneralContext).Assembly.FullName));
            return new GeneralContext(optionsBuilder.Options);
        }
    }
}
