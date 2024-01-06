using Microsoft.EntityFrameworkCore;
using Product_Tutorial.Models;

namespace Product_Tutorial.Services
{
    public class ApplicationDbContext:DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions) : base(contextOptions)
        { }
        public DbSet<ProductTable> productTables { get; set;  }
    }
}
