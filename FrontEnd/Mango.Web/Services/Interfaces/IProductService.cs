using Mango.Web.Models;

namespace Mango.Web.Services.Interfaces
{
    public interface IProductService: IBaseService
    {
        Task<T> GetAllProductsAsync<T>();
        Task<T> GetProductByIdAsync<T>(int productId);
        Task<T> InsertProductAsync<T>(ProductDto item);
        Task<T> UpdateProductAsync<T>(ProductDto item);
        Task<T> DeleteProductAsync<T>(int productId);

    }
}
