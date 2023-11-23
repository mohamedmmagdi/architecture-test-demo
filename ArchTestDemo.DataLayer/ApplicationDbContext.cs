using ArchTestDemo.DataLayer.Domain;
using Microsoft.EntityFrameworkCore;

namespace ArchTestDemo.DataLayer
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = default!;
    }
}
