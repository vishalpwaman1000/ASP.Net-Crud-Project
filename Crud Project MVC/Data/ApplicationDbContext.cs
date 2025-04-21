using Crud_Project_MVC.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crud_Project_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {            
        }

        public DbSet<Student> Students { get; set; }
    }
}
