using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context.Logisitics
{
    public class LogisticsContext : DbContext
    {
        public LogisticsContext(DbContextOptions<LogisticsContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
          //  builder.Entity<ExampleEntity>(ConfigureExample);
        }
    }
}
