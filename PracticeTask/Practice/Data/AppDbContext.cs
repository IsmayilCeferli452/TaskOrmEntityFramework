using Microsoft.EntityFrameworkCore;
using Practice.Models;

namespace Practice.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Setting> Settings { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Victus\\SQLEXPRESS;Database=EntityFrameworkExample;Trusted_Connection=true;TrustServerCertificate=True");
        }
    }
}
