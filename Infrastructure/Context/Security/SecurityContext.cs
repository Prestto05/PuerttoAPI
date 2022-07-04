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
        public DbSet<PersonEntity> Persona { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
             builder.Entity<PersonEntity>(ConfigurePerson);
             builder.Entity<UserEntity>(ConfigureUser);
        }

        private void ConfigurePerson(EntityTypeBuilder<PersonEntity> builder)
        {
            builder.ToTable("person");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();
            builder.Property(p => p.NombresCompletos);
            builder.Property(p => p.IdGenero)
                .IsRequired();
            builder.Property(p => p.FechaNacimiento)
                .HasColumnType("datetime")
                .IsRequired();
            builder.Property(p => p.Direccion);
            builder.Property(p => p.DireccionSecundario);
            builder.Property(p => p.IdTipoIdentificacion);
            builder.Property(p => p.Cedula);
            builder.Property(p => p.RazonSocial);
            builder.Property(p => p.Telefono);
            builder.Property(p => p.IdNacionalidad);
            builder.Property(p => p.FotoPerfil);
            builder.Property(p => p.Estado)
             .HasConversion(p => (byte)p, p => (EstadoPersona)p)
             .IsRequired();
            builder.Property(p => p.IdUserRegisterAudit);
            builder.Property(p => p.CreateOnAudit)
                .HasColumnType("datetime");
            builder.Property(p => p.IdUserModifyAudit);
            builder.Property(p => p.ModifyOnAudit)
                .HasColumnType("datetime");
            builder.Property(p => p.IpPublicAudit);
            builder.Property(p => p.MacAddressAudit);
            builder.Property(p => p.LatitudeAudit);
            builder.Property(p => p.LongitudeAudit);
            builder.Property(p => p.Comment);
        }


        private void ConfigureUser(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("user");
            builder.HasKey(us => us.Id);
            builder.Property(us => us.Id)
                .ValueGeneratedOnAdd();
            builder.Property(us => us.Correo)
                .IsRequired();
            builder.Property(us => us.Contraseña)
                .IsRequired();
            builder.Property(us => us.ClaveUnica)
                .IsRequired();
            builder.Property(us => us.RecuperarContraseña);
            builder.Property(us => us.CodigoRecuperacion);
            builder.Property(us => us.IdTipoUsuario)
                .IsRequired();
            builder.Property(us => us.IdPersona);
            builder.Property(us => us.StateUser)
             .HasConversion(us => (byte)us, us => (EstadoUsuario)us)
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
