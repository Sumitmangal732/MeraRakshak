using MeraRakshak.DTOs;
using MeraRakshak.Models;
using Microsoft.EntityFrameworkCore;

namespace MeraRakshak.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;


        public DbSet<Contact> Contacts { get; set; }

        public DbSet<CallLog> CallLogs { get; set; }

    }
}
