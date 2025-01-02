using Microsoft.EntityFrameworkCore;
using Mitarbeitershop_Hydro.Models;

namespace Mitarbeitershop_Hydro.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        
        }
        public DbSet<Category> Categories { get; set; }
    }
}
