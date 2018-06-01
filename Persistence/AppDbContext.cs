using Microsoft.EntityFrameworkCore;
using AngularApp.Models;
namespace AngularApp.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> Options) : base(Options)
        {

        }
        public DbSet<Links> Links { get; set; }
    }
}