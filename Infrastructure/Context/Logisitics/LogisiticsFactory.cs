using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context.Logisitics
{
    public class LogisticsFactory : IDesignTimeDbContextFactory<LogisticsContext>
    {
        public LogisticsContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("dbconfig.json")
                .Build();
            var optionsBuilder = new DbContextOptionsBuilder<LogisticsContext>();
            var connectionString = configuration.GetConnectionString("LogisticsConnection");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), b => b.MigrationsAssembly(typeof(LogisticsContext).Assembly.FullName));
            return new LogisticsContext(optionsBuilder.Options);
        }
    }
}
