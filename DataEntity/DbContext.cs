using DataEntity.Data;
using Microsoft.EntityFrameworkCore;

namespace DataEntity
{
    public class SkladContext : DbContext
    {
        public DbSet<Material> Material => Set<Material>();
        public DbSet<MernaJednotka> MernaJednotka => Set<MernaJednotka>();   
                protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            { optionsBuilder.UseSqlServer("Server=localhost;Database=SkladCv2_2026;Trusted_Connection=True;TrustServerCertificate=True;")
                    .UseLazyLoadingProxies();
            }
               
        }
    }
}
