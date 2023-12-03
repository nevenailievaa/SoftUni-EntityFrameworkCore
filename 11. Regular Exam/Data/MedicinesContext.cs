namespace Medicines.Data
{
    using Medicines.Data.Models;
    using Microsoft.EntityFrameworkCore;
    public class MedicinesContext : DbContext
    {
        public MedicinesContext() { }

        public DbSet<Medicine> Medicines { get; set; } = null!;
        public DbSet<PatientMedicine> PatientsMedicines { get; set; } = null!;
        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Pharmacy> Pharmacies { get; set; } = null!;

        public MedicinesContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientMedicine>(pm =>
            {
                pm.HasKey(pc => new { pc.PatientId, pc.MedicineId });
            });
        }
    }
}
