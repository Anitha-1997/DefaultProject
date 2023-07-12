using BulkyWebRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWebRazor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 4, DisplayOrder = 4, Name = "Crime" },
                new Category { Id = 5, DisplayOrder = 5, Name = "Investigative" },
                new Category { Id = 6, DisplayOrder = 6, Name = "Romance" }
                );
        }
    }
}
