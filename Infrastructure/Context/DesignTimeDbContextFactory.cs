using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class DesignTimeDbContextFactory<T> : IDesignTimeDbContextFactory<T>    where T : DbContext
    {
        public T CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("dbconfig.json")
                .Build();

            var builder = new DbContextOptionsBuilder<T>();
            var generalContext = configuration.GetConnectionString("GeneralConnection");
            var securitylContext = configuration.GetConnectionString("SecurityConnection");
            builder.UseMySql(generalContext, ServerVersion.AutoDetect(generalContext), b => b.MigrationsAssembly(typeof(T).Assembly.FullName));
            builder.UseMySql(securitylContext, ServerVersion.AutoDetect(securitylContext), b => b.MigrationsAssembly(typeof(T).Assembly.FullName));
            var dbContext = (T)Activator.CreateInstance( typeof(T),    builder.Options);
            return dbContext;
        }
    }
}
