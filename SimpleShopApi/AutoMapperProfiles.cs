using AutoMapper;
using SimpleShopApi.Models;
using SimpleShopApi.Models.DtoModels;

namespace SimpleShopApi
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductAddDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductUpdataDto>().ReverseMap();
        }
    }
}
