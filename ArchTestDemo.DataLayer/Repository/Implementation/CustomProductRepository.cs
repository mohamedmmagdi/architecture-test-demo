using ArchTestDemo.DataLayer.Domain;
using ArchTestDemo.DataLayer.Repository.Interfaces;

namespace ArchTestDemo.DataLayer.Repository.Implementation
{
    public sealed class CustomProductRepository : GenericRepository<Product>, IRepository<Product>
    {
        public CustomProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
