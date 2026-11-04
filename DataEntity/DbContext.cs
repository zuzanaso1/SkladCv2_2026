using DataEntity.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataEntity
{
    // Classu pojmenovat : DbContext - Dědí z Microsoft.EntityFrameworkCore.DbContext
    public class SkladContext : DbContext
    {
        public DbSet<Material> Material => Set<Material>();
        public DbSet<MernaJednotka> MernaJednotka => Set<MernaJednotka>();

        public DbSet<Paleta> Paleta => Set<Paleta>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseSqlServer(
                        "Data Source=(localdb)\\MSSQLLocalDB;" +
                        "Database=SkladCv2_20261;" +
                        "Integrated Security=True;" +
                        "TrustServerCertificate=True;")
                    .UseLazyLoadingProxies();
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MernaJednotka>().HasData(
                new MernaJednotka
                {
                    MernaJednotkaID = 1,
                    Popis = "ks"
                },
                new MernaJednotka
                {
                    MernaJednotkaID = 2,
                    Popis = "kg"
                },
                new MernaJednotka
                {
                    MernaJednotkaID = 3,
                    Popis = "m3"
                });
        }
    }
}
