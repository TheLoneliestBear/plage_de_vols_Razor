using Microsoft.EntityFrameworkCore;
using VolsWebApp.Models;

namespace VolsWebApp.Data
{
    public class VolContext : DbContext
    {
        public VolContext(DbContextOptions<VolContext> options) :base(options) { 
        }
        public DbSet<Vol> Vols { get; set; } = default;
    }
    
}
