using SimpleShopApi.Models.DtoModels;

namespace SimpleShopApi.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDto>> ProductsGetAllAsync();
        public Task<ProductDto> ProductGetByIdAsync(int id);
        public Task<ProductDto> ProductGetByNameAsync(string name);

        public Task<IEnumerable<ProductDto>> ProductsCreateAsync(IEnumerable<ProductAddDto> addProductsDto);
        public Task<ProductDto> ProductCreateAsync(ProductAddDto ProductAddDto);

        public Task<IEnumerable<ProductDto>> ProductsUpdataAsync(IEnumerable<ProductUpdataDto> updateProductsDto);
        public Task<ProductDto> ProductUpdataAsync(ProductUpdataDto ProductUpdateDto);


        public Task ProductsDeleteAsync(IEnumerable<string> names);
        public Task ProductDeleteAsync(string name);

    }
}
