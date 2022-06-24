using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Context.General
{
    public class GeneralContext: DbContext
    {
        public GeneralContext(DbContextOptions<GeneralContext> options) : base(options)
        {
        }

       // public DbSet<ExampleEntity> Ejemplo { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            //builder.Entity<ExampleEntity>(ConfigureExample);
        }

        //private void ConfigureExample(EntityTypeBuilder<ExampleEntity> builder)
        //{
                    
        //}


    }
}
