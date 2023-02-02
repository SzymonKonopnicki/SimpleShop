using AutoMapper;
using SimpleShopApi.Interfaces;
using SimpleShopApi.Models.DtoModels;
using SimpleShopApi.Models;
using Microsoft.IdentityModel.Tokens;
using SimpleShopApi.Exceptions;

namespace SimpleShopApi.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductsDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductService(ProductsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> ProductsGetAllAsync()
        {
            List<Product> productsDb = _dbContext.Products.ToList();
            if (productsDb == null)
                throw new NotFoundException("Product not found.");

            return _mapper.Map<IEnumerable<ProductDto>>(productsDb);
        }
        public async Task<ProductDto> ProductGetByIdAsync(int id)
        {
            Product productDb = _dbContext.Products
                .Where(x => x.ProductId == id)
                .FirstOrDefault();

            if (productDb == null)
                throw new NotFoundException("Product not found.");

            return _mapper.Map<ProductDto>(productDb);
        }
        public async Task<ProductDto> ProductGetByNameAsync(string name)
        {
            Product productDb = _dbContext.Products
                .Where(x => x.Name == name)
                .FirstOrDefault();

            if (productDb == null)
                throw new NotFoundException("Product not found.");

            return _mapper.Map<ProductDto>(productDb);
        }

        public async Task<IEnumerable<ProductDto>> ProductsCreateAsync(IEnumerable<ProductAddDto> productsAddDto)
        {
            var products = new List<Product>();
            foreach (var addProductDto in productsAddDto)
            {
                var productDb = _dbContext.Products
                    .Where(x => x.Name == addProductDto.Name)
                    .FirstOrDefault();
                if (productDb == null)
                    products.Add(_mapper.Map<Product>(addProductDto));
            }

            if (products.IsNullOrEmpty())
                throw new NotFoundException("Product not found.");

            _dbContext.Products.AddRange(products);
            _dbContext.SaveChanges();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<IEnumerable<ProductDto>> ProductsUpdataAsync(IEnumerable<ProductUpdataDto> productsUpdateDto)
        {
            var products = new List<Product>();
            foreach (var updateProductDto in productsUpdateDto)
            {
                var productDb = _dbContext.Products
                    .Where(x => x.Name == updateProductDto.Name)
                    .FirstOrDefault();
                if (productDb != null)
                    products.Add(_mapper.Map<Product>(updateProductDto));
            }

            if (products.IsNullOrEmpty())
                throw new NotFoundException("Product not found.");

            _dbContext.Products.UpdateRange(products);
            _dbContext.SaveChanges();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task ProductsDeleteAsync(IEnumerable<string> names)
        {
            var products = new List<Product>();
            foreach (var name in names)
            {
                var productDb = _dbContext.Products
                    .Where(x => x.Name == name)
                    .FirstOrDefault();
                if (name != null)
                    products.Add(productDb);
            }

            if (products.IsNullOrEmpty())
                throw new NotFoundException("Product not found.");

            _dbContext.Products.RemoveRange(products);
            _dbContext.SaveChanges();
        }
    }
}

