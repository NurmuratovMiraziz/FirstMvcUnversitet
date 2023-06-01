using FirstMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMvc.DbContexts
{
    public class AppDbContexts : DbContext
    {
        public AppDbContexts(DbContextOptions options) : base(options) { }
        public DbSet<Talaba> Talabas { get; set; }
        public DbSet<Unversitet> Unversitetlar { get; set;}
    }
}
