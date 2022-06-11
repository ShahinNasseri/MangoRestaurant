using Mango.Services.ProductAPI.Model.Dto;
using Mango.Services.ProductAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        protected ResponseDto _response;
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _response = new ResponseDto();
        }
        [Authorize]
        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                var productDtos = await _productRepository.GetProducts();
                _response.Result = productDtos;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(e.ToString());
            }

            return _response;
        }

        [Authorize]
        [HttpGet]
        [Route("{productId:int}")]
        public async Task<ResponseDto> Get(int productId)
        {
            try
            {
                var productDtos = await _productRepository.GetProductById(productId);
                _response.Result = productDtos;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(e.ToString());
            }

            return _response;
        }


        [Authorize]
        [HttpPost]
        public async Task<ResponseDto> Post([FromBody] ProductDto request)
        {
            try
            {
                var productDtos = await _productRepository.SaveProduct(request);
                _response.Result = productDtos;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(e.ToString());
            }

            return _response;
        }

        [Authorize]
        [HttpPut]
        public async Task<ResponseDto> Put([FromBody] ProductDto request)
        {
            try
            {
                var productDtos = await _productRepository.SaveProduct(request);
                _response.Result = productDtos;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(e.ToString());
            }

            return _response;
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<ResponseDto> Delete(int id)
        {
            try
            {
                var isSuccess = await _productRepository.DeleteProduct(id);
                _response.IsSuccess = isSuccess;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(e.ToString());
            }

            return _response;
        }
    }
}
