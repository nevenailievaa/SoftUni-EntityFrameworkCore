namespace Cadastre.Data
{
    using Cadastre.Data.Models;
    using Microsoft.EntityFrameworkCore;
    public class CadastreContext : DbContext
    {
        //Constructors
        public CadastreContext() { }

        public CadastreContext(DbContextOptions options) : base(options) { }

        //Properties (Tables)
        public DbSet<Citizen> Citizens { get; set; } = null!;
        public DbSet<PropertyCitizen> PropertiesCitizens { get; set; } = null!;
        public DbSet<Property> Properties { get; set; } = null!;
        public DbSet<District> Districts { get; set; } = null!;

        //Configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        //Models Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //PropertiesCitizens
            modelBuilder.Entity<PropertyCitizen>(pc =>
                pc.HasKey(pc => new
                {
                    pc.PropertyId,
                    pc.CitizenId
                }));
        }
    }
}
