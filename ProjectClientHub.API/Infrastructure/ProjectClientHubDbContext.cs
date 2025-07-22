using Microsoft.EntityFrameworkCore;
using ProjectClientHub.API.Entities;

namespace ProjectClientHub.API.Infrastructure
{
    public class ProjectClientHubDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=D:\\Workspace\\ProductClientHubDB.db");
        }

    }
}
