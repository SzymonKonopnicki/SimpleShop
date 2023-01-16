using AutoMapper;
using SimpleShopApi.Interfaces;
using SimpleShopApi.Models.DtoModels;
using SimpleShopApi.Models;

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

        public async Task<IEnumerable<ProductDto>> ProductsGetAsync()
        {
            List<Product> productsDb = _dbContext.Products.ToList();
            if (productsDb == null)
                throw new Exception("Middleware - w8 in progress.\tNot Found");

            return _mapper.Map<IEnumerable<ProductDto>>(productsDb);
        }
        public async Task<ProductDto> ProductGetAsync(int id)
        {
            Product productDb = _dbContext.Products
                .Where(x => x.ProductId == id)
                .FirstOrDefault();

            if (productDb == null)
                throw new Exception("Middleware - w8 in progress.\tNot Found");

            return _mapper.Map<ProductDto>(productDb);
        }
        public async Task<ProductDto> ProductGetAsync(string name)
        {
            Product productDb = _dbContext.Products
                .Where(x => x.Name == name)
                .FirstOrDefault();

            if (productDb == null)
                throw new Exception("Middleware - w8 in progress.\tNot Found");

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

                if (addProductDto.Name != productDb.Name)
                    products.Add(_mapper.Map<Product>(addProductDto));
            }

            if (products == null)
                throw new Exception("Middleware - w8 in progress.\tWrong product");

            _dbContext.Products.AddRange(products);
            _dbContext.SaveChanges();

            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }
        public async Task<ProductDto> ProductCreateAsync(ProductAddDto productAddDto)
        {
            Product productDb = _dbContext.Products
                .Where(x => x.Name == productAddDto.Name)
                .FirstOrDefault();

            if (productDb.Name == productAddDto.Name)
                throw new Exception("Middleware - w8 in progress.\tWrong product");

            Product product = _mapper.Map<Product>(productAddDto);
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            return _mapper.Map<ProductDto>(productAddDto);
        }

        public async Task<IEnumerable<ProductDto>> ProductsUpdateAsync(IEnumerable<ProductUpdataDto> productsUpdateDto)
        {
            var products = new List<Product>();
            foreach (var updateProductDto in productsUpdateDto)
            {
                var productDb = _dbContext.Products
                    .Where(x => x.Name == updateProductDto.Name)
                    .FirstOrDefault();
                if (updateProductDto.Name == productDb.Name)
                    products.Add(_mapper.Map<Product>(updateProductDto));
            }

            if (products == null)
                throw new Exception("Middleware - w8 in progress.\tWrong product");

            foreach (var prod in products)
            {
                _dbContext.Products.Update(prod);
                _dbContext.SaveChanges();
            }

            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }
        public async Task<ProductDto> ProductUpdateAsync(ProductUpdataDto productUpdateDto)
        {
            var productDb = _dbContext.Products
                .Where(x => x.Name == productUpdateDto.Name)
                .FirstOrDefault();

            if (productDb.Name != productUpdateDto.Name)
                throw new Exception("Middleware - w8 in progress.\tNot Found");

            productDb.Name = productUpdateDto.Name;
            productDb.Price = productUpdateDto.Price;
            productDb.Category = productUpdateDto.Category;

            _dbContext.Products.Update(productDb);
            _dbContext.SaveChanges();

            return _mapper.Map<ProductDto>(productDb);
        }

        public async Task ProductDeleteAsync(IEnumerable<string> names)
        {
            var products = new List<Product>();
            foreach (var name in names)
            {
                var productDb = _dbContext.Products
                    .Where(x => x.Name == name)
                    .FirstOrDefault();

                if (name == productDb.Name)
                    products.Add(productDb);
            }

            if (products == null)
                throw new Exception("Middleware - w8 in progress.\tNot Found");

            _dbContext.Products.RemoveRange(products);
            _dbContext.SaveChanges();
        }
        public async Task ProductDeleteAsync(string name)
        {
            var product = _dbContext.Products
                .Where(x => x.Name == name)
                .FirstOrDefault();

            if (product.Name != name)
                throw new Exception("Middleware - w8 in progress.\tNot Found");

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }
    }
}

