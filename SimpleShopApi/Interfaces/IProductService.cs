
namespace SimpleShopApi.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDto>> ProductsGetAllAsync();
        public Task<ProductDto> ProductGetByIdAsync(int id);
        public Task<ProductDto> ProductGetByNameAsync(string name);

        public Task<IEnumerable<ProductDto>> ProductsCreateAsync(IEnumerable<ProductAddDto> addProductsDto);

        public Task<IEnumerable<ProductDto>> ProductsUpdataAsync(IEnumerable<ProductUpdataDto> updateProductsDto);

        public Task ProductsDeleteAsync(IEnumerable<string> names);

    }
}
