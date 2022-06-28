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

        public DbSet<TypePerson>  TypePerson{ get; set; }
        public DbSet<TypeIdentification> TypeIdentifications{ get; set; }
        public DbSet<Gender>  Genders{ get; set; }
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<CityEntity>  Cities{ get; set; }
        public DbSet<TypeSubscription>  Subscription{ get; set; }
        public DbSet<PersonEntity>  Person{ get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            #region MyRegion

            builder.Entity<TypePerson>(ConfigureTypePerson);
            builder.Entity<TypeIdentification>(ConfigureTypeIdentification);
            builder.Entity<Gender>(ConfigureGender);
            builder.Entity<CountryEntity>(ConfigureCountry);
            builder.Entity<CountryEntity>(ConfigureCountry);
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


        private void ConfigurePerson(EntityTypeBuilder<PersonEntity> builder)
        {
            builder.ToTable("person");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();
            builder.Property(p => p.NanmeFirst);
            builder.Property(p => p.NameSecond);
            builder.Property(p => p.SureName);
            builder.Property(p => p.LastName);
            builder.Property(p => p.FullName);
            builder.Property(p => p.IdGener)
                .IsRequired();
            builder.Property(p => p.BirthDate)
                .HasColumnType("datetime")
                .IsRequired();
            builder.Property(p => p.Address);
            builder.Property(p => p.AddressOptional);
            builder.Property(p => p.IdTypeIdentification);
            builder.Property(p => p.Identification);
            builder.Property(p => p.BusinessName);
            builder.Property(p => p.Phone);
            builder.Property(p => p.IdNationality);
            builder.Property(p => p.ProfilePhoto);
            builder.Property(p => p.State)
             .HasConversion(p => (byte)p, p => (StatePerson)p)
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




    }
}
