using MeraRakshak.Models;
using Microsoft.EntityFrameworkCore;

namespace MeraRakshak.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.EmailAddress).IsUnique();
                entity.HasIndex(e => e.MobileNo).IsUnique();
            });
        }
    }
}
