using Mango.Services.ProductAPI.Model;
using Mango.Services.ProductAPI.Model.Dto;

namespace Mango.Services.ProductAPI.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(int productId);
        Task<ProductDto> SaveProduct(ProductDto item);
        Task<bool> DeleteProduct(int productId);
    }
}
