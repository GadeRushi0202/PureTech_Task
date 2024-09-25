using CRUD_App_PureTech_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_App_PureTech_Task.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> op) : base(op)
        {
            
        }
        public DbSet<Product> products { get; set; }        

    }
}
