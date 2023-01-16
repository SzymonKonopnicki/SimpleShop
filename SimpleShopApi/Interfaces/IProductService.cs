using SimpleShopApi.Models.DtoModels;

namespace SimpleShopApi.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDto>> ProductsGetAsync();
        public Task<ProductDto> ProductGetAsync(int id);
        public Task<ProductDto> ProductGetAsync(string name);

        public Task<IEnumerable<ProductDto>> ProductsCreateAsync(IEnumerable<ProductAddDto> addProductsDto);
        public Task<ProductDto> ProductCreateAsync(ProductAddDto ProductAddDto);

        public Task<IEnumerable<ProductDto>> ProductsUpdateAsync(IEnumerable<ProductUpdataDto> updateProductsDto);
        public Task<ProductDto> ProductUpdateAsync(ProductUpdataDto ProductUpdateDto);


        public Task ProductDeleteAsync(IEnumerable<string> names);
        public Task ProductDeleteAsync(string name);

    }
}
