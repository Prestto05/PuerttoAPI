using Infrastructure.Entities;
using Infrastructure.Entities.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Context.General
{
    public class GeneralContext: DbContext
    {
        public GeneralContext(DbContextOptions<GeneralContext> options) : base(options)
        {
        }

        #region Catalog

        public DbSet<TypePerson>  TipoPersona{ get; set; }
        public DbSet<TypeIdentification> TipoIdentificacion{ get; set; }
        public DbSet<Gender>  Genero{ get; set; }
        public DbSet<CountryEntity> Paises { get; set; }
        public DbSet<CityEntity>  Ciudades{ get; set; }
        public DbSet<TypeSubscription>  Subscription{ get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            #region MyRegion

            builder.Entity<TypePerson>(ConfigureTypePerson);
            builder.Entity<TypeIdentification>(ConfigureTypeIdentification);
            builder.Entity<Gender>(ConfigureGender);
            builder.Entity<CountryEntity>(ConfigureCountry);
            builder.Entity<CityEntity>(ConfigureCity);
            builder.Entity<TypeSubscription>(ConfigureTypeSubscription);
            #endregion

        }

        #region Catalog

        private void ConfigureTypePerson(EntityTypeBuilder<TypePerson> builder)
        {
            builder.ToTable("catalogTypePerson");
            builder.HasKey(tp => tp.Id);
            builder.Property(tp => tp.Id)
                 .ValueGeneratedOnAdd();
            builder.Property(tp => tp.Name)
                .IsRequired();
            builder.Property(tp => tp.Description)
                .IsRequired();
            builder.Property(tp => tp.Alias)
                .IsRequired();
            builder.Property(tp => tp.State)
               .HasConversion(tp => (byte)tp, tp => (State)tp)
               .IsRequired();

        }

        private void ConfigureTypeIdentification(EntityTypeBuilder<TypeIdentification> builder)
        {
            builder.ToTable("catalogTypeIdentification");
            builder.HasKey(ti => ti.Id);
            builder.Property(ti => ti.Id)
                 .ValueGeneratedOnAdd();
            builder.Property(ti => ti.Name)
                .IsRequired();
            builder.Property(ti => ti.Description)
                .IsRequired();
            builder.Property(ti => ti.Alias)
                .IsRequired();
            builder.Property(ti => ti.State)
              .HasConversion(ti => (byte)ti, ti => (State)ti)
              .IsRequired();
        }

        private void ConfigureGender(EntityTypeBuilder<Gender> builder)
        {
            builder.ToTable("catalogGender");
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Id)
                 .ValueGeneratedOnAdd();
            builder.Property(g => g.Name)
                .IsRequired();
            builder.Property(g => g.Description)
                .IsRequired();
            builder.Property(g => g.Alias)
                .IsRequired();
            builder.Property(g => g.State)
              .HasConversion(g => (byte)g, g => (State)g)
              .IsRequired();
        }

        private void ConfigureCountry(EntityTypeBuilder<CountryEntity> builder)
        {
            builder.ToTable("catalogCountry");
            builder.HasKey(ct => ct.Id);
            builder.Property(ct => ct.Id)
                 .ValueGeneratedOnAdd();
            builder.Property(ct => ct.Code)
                .IsRequired();
            builder.Property(ct => ct.CodeIso);
            builder.Property(ct => ct.CodePhone);               
            builder.Property(ct => ct.CountryName)
                .IsRequired();
        }

        private void ConfigureCity(EntityTypeBuilder<CityEntity> builder)
        {
            builder.ToTable("catalogCity");
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Id)
                 .ValueGeneratedOnAdd();
            builder.Property(g => g.CityName)
                .IsRequired();
            builder.Property(g => g.CodeCountry)           
                .IsRequired();
        }

        private void ConfigureTypeSubscription(EntityTypeBuilder<TypeSubscription> builder)
        {
            builder.ToTable("catalosSubscription");
            builder.HasKey(s=> s.Id);
            builder.Property(s=> s.Id)
                 .ValueGeneratedOnAdd();
            builder.Property(s=> s.Name)
                .IsRequired();
            builder.Property(s=> s.Description)
                .IsRequired();
            builder.Property(s=> s.Alias)
                .IsRequired();
            builder.Property(s => s.State)
              .HasConversion(s => (byte)s, s => (State)s)
              .IsRequired();
        }



        #endregion






    }
}
