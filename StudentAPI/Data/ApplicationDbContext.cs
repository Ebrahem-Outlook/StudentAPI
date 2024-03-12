using Microsoft.EntityFrameworkCore;
using StudentAPI.Models;

namespace StudentAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Teacher> Teachers { get; set; }    
        public DbSet<Manager> Managers { get; set; }    
        public DbSet<HeadManager> HeadManagers { get; set; }    
        public DbSet<CEO> Ceos { get; set; }
    }
}
