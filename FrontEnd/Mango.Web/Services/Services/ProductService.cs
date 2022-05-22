using Mango.Web.Models;
using Mango.Web.Services.Interfaces;

namespace Mango.Web.Services.Services
{
    public class ProductService : BaseService, IProductService
    {
        private string _productAddress = "/api/product";
        public ProductService(IHttpClientFactory httpClient) : base(httpClient)
        {}

        public async Task<T> DeleteProductAsync<T>(int productId)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                apiType = SD.ApiType.DELETE,
                Url = SD.ProductAPIBase + $"{_productAddress}/{productId}",
                AccessToken = ""

            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await SendAsync<T>(new ApiRequest()
            {
                apiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + _productAddress,
                AccessToken = ""
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int productId)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                apiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + $"{_productAddress}/{productId}",
                AccessToken = ""
            });
        }

        public async Task<T> InsertProductAsync<T>(ProductDto item)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                apiType= SD.ApiType.POST,
                Data = item,
                Url = SD.ProductAPIBase + _productAddress,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto item)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                apiType = SD.ApiType.PUT,
                Data = item,
                Url = SD.ProductAPIBase + _productAddress,
                AccessToken = ""
            });
        }
    }
}
