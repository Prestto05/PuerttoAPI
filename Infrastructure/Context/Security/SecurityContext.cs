using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context.Security
{
    public class SecurityContext :DbContext
    {
        public SecurityContext(DbContextOptions<SecurityContext> options): base(options)
        {

        }

       // public DbSet<ValueEntity> Valor { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           // builder.Entity<ValueEntity>(ConfigureExample);
        }

        //private void ConfigureExample(EntityTypeBuilder<ValueEntity> builder)
        //{
        //    builder.ToTable("Valor");
        //    builder.HasKey(s => s.Id);
        //    builder.Property(s => s.Id);
        //    builder.Property(fc => fc.precios)
        //        .IsRequired();
        //    builder.Property(fc => fc.CreateOn)
        //        .HasColumnType("datetime")
        //        .IsRequired();
        //    builder.Property(fc => fc.IdExample)
        //        .IsRequired();

        //}
    }
}
