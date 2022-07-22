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
        public DbSet<AdnTiendaEntity> TiendaAdn { get; set; }
        public DbSet<AdnPagoEntity> PagoAdn { get; set; }
        public DbSet<AdnTiendaCategoriaEntity> TiendaCategoria { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
             builder.Entity<PersonEntity>(ConfigurePerson);
             builder.Entity<UserEntity>(ConfigureUser);
             builder.Entity<AdnTiendaEntity>(ConfigureTiendaAnd);
             builder.Entity<AdnPagoEntity>(ConfigurePagoAdn);
             builder.Entity<AdnTiendaCategoriaEntity>(ConfigureTiendaCategoria);
        }

        private void ConfigurePerson(EntityTypeBuilder<PersonEntity> builder)
        {
            builder.ToTable("persona");
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
            builder.Property(p => p.Identificacion);
            builder.Property(p => p.RazonSocial);
            builder.Property(p => p.Telefono);
            builder.Property(p => p.IdPais);
            builder.Property(p => p.FotoPerfil);
            builder.Property(p => p.DescripcionPersona);
            builder.Property(p => p.Estado)
             .HasConversion(p => (byte)p, p => (EstadoPersona)p)
             .IsRequired();
            builder.Property(p => p.IdUserRegisterAudit);
            builder.Property(p => p.CreateOnAudit)
                .HasColumnType("datetime")
                .IsRequired();
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
            builder.ToTable("usuario");
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
                .HasColumnType("datetime")
                .IsRequired();
            builder.Property(us => us.IdUserModifyAudit);
            builder.Property(us => us.ModifyOnAudit)
                .HasColumnType("datetime");
            builder.Property(us => us.IpPublicAudit);
            builder.Property(us => us.MacAddressAudit);
            builder.Property(us => us.LatitudeAudit);
            builder.Property(us => us.LongitudeAudit);
            builder.Property(us => us.Comment);

        }

        private void ConfigureTiendaAnd(EntityTypeBuilder<AdnTiendaEntity> builder)
        {
            builder.ToTable("adntienda");
            builder.HasKey(at => at.Id);
            builder.Property(at => at.Id)
                .ValueGeneratedOnAdd();
            builder.Property(at => at.Tienda)
                .IsRequired();
            builder.Property(at => at.DescripcionTienda)
                .IsRequired();
            builder.Property(at => at.Pais)
                .IsRequired();
            builder.Property(at => at.Ciudad)
                .IsRequired();
            builder.Property(at => at.Direccion)
                .IsRequired();
            builder.Property(at => at.InicioActividades)
                .HasColumnType("datetime")
                .IsRequired();
            builder.Property(at => at.FotoTienda);
            builder.Property(at => at.IdPersona)
                .IsRequired();
            builder.Property(at => at.Estado)
             .HasConversion(at => (byte)at, at => (EstadoTienda)at)
             .IsRequired();
            builder.Property(at => at.IpPublicAudit);
            builder.Property(at => at.MacAddressAudit);
            builder.Property(at => at.LatitudeAudit);
            builder.Property(at => at.LongitudeAudit);
            builder.Property(at => at.Comment);
        }

        private void ConfigurePagoAdn(EntityTypeBuilder<AdnPagoEntity> builder)
        {
            builder.ToTable("adnpago");
            builder.HasKey(ap => ap.Id);
            builder.Property(ap => ap.Id)
                .ValueGeneratedOnAdd();
            builder.Property(ap => ap.Titular)
                .IsRequired();
            builder.Property(ap => ap.Identificacion)
                .IsRequired();
            builder.Property(ap => ap.Correo)
                .IsRequired();
            builder.Property(ap => ap.IdBanco)
                .IsRequired();
            builder.Property(ap => ap.TipoCuenta)
                .IsRequired();
            builder.Property(ap => ap.Cuenta)
                .IsRequired();
            builder.Property(ap => ap.IdPersona)
                .IsRequired();
            builder.Property(ap => ap.CodigoTelefono)
                .IsRequired();
            builder.Property(ap => ap.Telefono)
                .IsRequired();
            builder.Property(ap => ap.Estado)
                .HasConversion(ap => (byte)ap, ap => (EstadoPagoAdn)ap)
                .IsRequired();
            builder.Property(ap => ap.IpPublicAudit);
            builder.Property(ap => ap.MacAddressAudit);
            builder.Property(ap => ap.LatitudeAudit);
            builder.Property(ap => ap.LongitudeAudit);
            builder.Property(ap => ap.Comment);
        }

        private void ConfigureTiendaCategoria(EntityTypeBuilder<AdnTiendaCategoriaEntity> builder)
        {
            builder.ToTable("tiendacategoria");
            builder.HasKey(tc => tc.Id);
            builder.Property(tc => tc.Id)
                .ValueGeneratedOnAdd();
            builder.Property(tc => tc.IdCategoria)
                .IsRequired();
            builder.Property(tc => tc.IdAdnTienda)
                .IsRequired();
        }


    }
}
