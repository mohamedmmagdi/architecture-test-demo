using ArchTestDemo.BusinessLayer.DTO;
using ArchTestDemo.BusinessLayer.Service.Interfaces;
using ArchTestDemo.DataLayer.Domain;
using ArchTestDemo.DataLayer.Repository.Interfaces;
using AutoMapper;

namespace ArchTestDemo.BusinessLayer.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var dbProducts = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<Product>>(dbProducts);
        }

        public async Task<ProductDto> GetProductByIdAsync(int productId)
        {
            var productDto = await _repository.GetByIdAsync(productId);
            return _mapper.Map<ProductDto>(productDto);
        }

        public async Task AddProductAsync(ProductDto productDto)
        {
            var dbProduct = _mapper.Map<Product>(productDto);
            await _repository.AddAsync(dbProduct);
        }

        public async Task UpdateProductAsync(ProductDto productDto)
        {
            var dbProduct = _mapper.Map<Product>(productDto);
            await _repository.UpdateAsync(dbProduct);
        }

        public async Task DeleteProductAsync(int productId)
        {
            await _repository.DeleteAsync(productId);
        }
    }

}
