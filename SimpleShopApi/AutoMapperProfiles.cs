namespace SimpleShopApi
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductAddDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductUpdataDto>().ReverseMap();
            CreateMap<ProductDto, ProductAddDto>().ReverseMap();
        }
    }
}
