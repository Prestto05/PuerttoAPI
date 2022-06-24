using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context.Financial
{
    public class FinancialFactory : IDesignTimeDbContextFactory<FinancialContext>
    {
        public FinancialContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("dbconfig.json")
                .Build();
            var optionsBuilder = new DbContextOptionsBuilder<FinancialContext>();
            var connectionString = configuration.GetConnectionString("FinancialConnection");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), b => b.MigrationsAssembly(typeof(FinancialContext).Assembly.FullName));
            return new FinancialContext(optionsBuilder.Options);
        }
    }
}
