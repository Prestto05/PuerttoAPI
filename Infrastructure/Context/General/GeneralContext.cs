using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context.General
{
    public class GeneralContext: DbContext
    {
        public GeneralContext(DbContextOptions<GeneralContext> options) : base(options)
        {
        }

        public DbSet<ExampleEntity> Exemplo { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            builder.Entity<ExampleEntity>(ConfigureExample);
        }

        private void ConfigureExample(EntityTypeBuilder<ExampleEntity> builder)
        {
            builder.ToTable("Ejemplo");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id);
            builder.Property(fc => fc.Number)               
                .IsRequired();
            builder.Property(fc => fc.Data)
               
                .IsRequired();
        }


    }
}
