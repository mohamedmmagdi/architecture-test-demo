using ArchTestDemo.BusinessLayer.DTO;
using ArchTestDemo.DataLayer.Domain;

namespace ArchTestDemo.BusinessLayer.Service.Interfaces
{
    public interface IProductService
    {
        Task AddProductAsync(ProductDto productDto);
        Task DeleteProductAsync(int productId);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<ProductDto> GetProductByIdAsync(int productId);
        Task UpdateProductAsync(ProductDto productDto);
    }
}
