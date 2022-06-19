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
            optionsBuilder.UseMySQL(connectionString);
            return new GeneralContext(optionsBuilder.Options);
        }
    }
}
