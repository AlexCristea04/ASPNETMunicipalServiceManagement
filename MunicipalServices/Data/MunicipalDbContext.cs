using Microsoft.EntityFrameworkCore;
using MunicipalServices.Models;

namespace MunicipalServices.Data
{
    public class MunicipalDbContext : DbContext
    {
        public MunicipalDbContext(DbContextOptions<MunicipalDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<WaterSupply> WaterSupplies { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Park> Parks { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}