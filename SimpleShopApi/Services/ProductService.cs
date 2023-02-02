

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
            List<Product> productsDb = await _dbContext.Products.ToListAsync();
            if (productsDb == null)
                throw new NotFoundException("Product not found.");

            return _mapper.Map<IEnumerable<ProductDto>>(productsDb);
        }
        public async Task<ProductDto> ProductGetByIdAsync(int id)
        {
            Product productDb = await _dbContext.Products
                .Where(x => x.ProductId == id)
                .FirstOrDefaultAsync();

            if (productDb == null)
                throw new NotFoundException("Product not found.");

            return _mapper.Map<ProductDto>(productDb);
        }
        public async Task<ProductDto> ProductGetByNameAsync(string name)
        {
            Product productDb = await _dbContext.Products
                .Where(x => x.Name == name)
                .FirstOrDefaultAsync();

            if (productDb == null)
                throw new NotFoundException("Product not found.");

            return _mapper.Map<ProductDto>(productDb);
        }

        public async Task<IEnumerable<ProductDto>> ProductsCreateAsync(IEnumerable<ProductAddDto> productsAddDto)
        {
            var products = new List<Product>();
            foreach (var addProductDto in productsAddDto)
            {
                var productDb = await _dbContext.Products
                    .Where(x => x.Name == addProductDto.Name)
                    .FirstOrDefaultAsync();
                if (productDb == null)
                    products.Add(_mapper.Map<Product>(addProductDto));
            }

            if (products.IsNullOrEmpty())
                throw new NotFoundException("Product not found.");

            await _dbContext.Products.AddRangeAsync(products);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<IEnumerable<ProductDto>> ProductsUpdataAsync(IEnumerable<ProductUpdataDto> productsUpdateDto)
        {
            var products = new List<Product>();
            foreach (var updateProductDto in productsUpdateDto)
            {
                var productDb = await _dbContext.Products
                    .Where(x => x.Name == updateProductDto.Name)
                    .FirstOrDefaultAsync();
                if (productDb != null)
                    products.Add(_mapper.Map<Product>(updateProductDto));
            }

            if (products.IsNullOrEmpty())
                throw new NotFoundException("Product not found.");

            await _dbContext.Products.AddRangeAsync(products);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task ProductsDeleteAsync(IEnumerable<string> names)
        {
            var products = new List<Product>();
            foreach (var name in names)
            {
                var productDb = await _dbContext.Products
                    .Where(x => x.Name == name)
                    .FirstOrDefaultAsync();
                if (name != null)
                    products.Add(productDb);
            }

            if (products.IsNullOrEmpty())
                throw new NotFoundException("Product not found.");

            await _dbContext.Products.AddRangeAsync(products);
            await _dbContext.SaveChangesAsync();
        }
    }
}

