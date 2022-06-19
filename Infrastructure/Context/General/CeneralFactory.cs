using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context.General
{
    public class CeneralFactory : IDesignTimeDbContextFactory<GeneralContext>
    {
        public GeneralContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("dbconfig.json")
                .Build();
            var optionsBuilder = new DbContextOptionsBuilder<GeneralContext>();
            var connectionString = configuration.GetConnectionString("GeneralConnection");
            optionsBuilder.UseMySQL(connectionString);
            return new GeneralContext(optionsBuilder.Options);
        }
    }
}
