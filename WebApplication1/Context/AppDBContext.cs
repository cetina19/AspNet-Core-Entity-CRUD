using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> contextOptions) 
            : base(contextOptions) { }

        public DbSet<DataViewModel> ? Books { get; set; }
    }
}
