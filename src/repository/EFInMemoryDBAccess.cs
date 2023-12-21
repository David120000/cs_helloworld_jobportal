using Bredex1.controller.model;
using Bredex1.src.model;
using Microsoft.EntityFrameworkCore;

namespace Bredex1.src.repository
{
    public class EFInMemoryDBAccess : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "jobportaldb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApiKeyCached>().HasKey(key => key.ApiKey);
            modelBuilder.Entity<PositionDBData>().HasKey(key => key.Id);
        }

        public DbSet<ApiKeyCached> AuthenticatedClients { get; set; }
        public DbSet<PositionDBData> AvailablePositions { get; set; }
    }
}