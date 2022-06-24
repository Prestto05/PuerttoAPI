using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context.Inventario
{
    public class InventarioFactory : IDesignTimeDbContextFactory<InventarioContext>
    {
        public InventarioContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("dbconfig.json")
                .Build();
            var optionsBuilder = new DbContextOptionsBuilder<InventarioContext>();
            var connectionString = configuration.GetConnectionString("InventarioConnection");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), b => b.MigrationsAssembly(typeof(InventarioContext).Assembly.FullName));
            return new InventarioContext(optionsBuilder.Options);
        }
    }
}
