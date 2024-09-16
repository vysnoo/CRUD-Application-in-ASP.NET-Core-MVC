using CRUD_Application.Models;
using Microsoft.EntityFrameworkCore;
namespace CRUD_Application.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {   
        }
        public DbSet<Name> Names { get; set; }
    }
}
