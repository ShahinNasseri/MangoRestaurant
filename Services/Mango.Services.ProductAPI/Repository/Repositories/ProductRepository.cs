using AutoMapper;
using Mango.Services.ProductAPI.DBContext;
using Mango.Services.ProductAPI.Model;
using Mango.Services.ProductAPI.Model.Dto;
using Mango.Services.ProductAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.Repository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext db , IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == productId);

                if (product == null)
                {
                    return false;
                }

                _db.Products.Remove(product);
                var modifiedCount = await _db.SaveChangesAsync();
                return modifiedCount == 0 ? false : true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product product = await _db.Products.AsNoTracking().Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> products = await _db.Products.AsNoTracking().ToListAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> SaveProduct(ProductDto item)
        {
            var product = _mapper.Map<Product>(item);
            if (product.ProductId > 0)
            {
                _db.Products.Update(product);
            }
            else
            {
               await _db.Products.AddAsync(product);
            }
            await _db.SaveChangesAsync();

            return _mapper.Map<ProductDto>(product);
        }


    }
}
