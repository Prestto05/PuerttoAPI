using Infrastructure.Entities;
using Infrastructure.Entities.Security;
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

        public DbSet<UserEntity> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
             builder.Entity<UserEntity>(ConfigureUser);
        }

        private void ConfigureUser(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("user");
            builder.HasKey(us => us.Id);
            builder.Property(us => us.Id)
                .ValueGeneratedOnAdd();
            builder.Property(us => us.Email)
                .IsRequired();
            builder.Property(us => us.Password)
                .IsRequired();
            builder.Property(us => us.KeyUnique)
                .IsRequired();
            builder.Property(us => us.IsRecoverPassword);
            builder.Property(us => us.CodeCoverPassword);
            builder.Property(us => us.IdTypeUser)
                .IsRequired();
            builder.Property(us => us.IdPerson);
            builder.Property(us => us.StateUser)
             .HasConversion(us => (byte)us, us => (StateUser)us)
             .IsRequired();
            builder.Property(us => us.IdUserRegisterAudit);
            builder.Property(us => us.CreateOnAudit)
                .HasColumnType("datetime");
            builder.Property(us => us.IdUserModifyAudit);
            builder.Property(us => us.ModifyOnAudit)
                .HasColumnType("datetime");
            builder.Property(us => us.IpPublicAudit);
            builder.Property(us => us.MacAddressAudit);
            builder.Property(us => us.LatitudeAudit);
            builder.Property(us => us.LongitudeAudit);
            builder.Property(us => us.Comment);

        }
    }
}
